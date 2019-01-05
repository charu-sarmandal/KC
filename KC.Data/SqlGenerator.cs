using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data
{
    public enum SqlOperationType
    {
        Insert,
        Update,
        Delete,
        Get,
        GetById,
        CheckUniqueName,
        StoredProc
    }

    public class SqlQueryFormatter
    {
       

        private const string INSERT_FORMAT = "INSERT INTO [{0}] ({1}) VALUES({2}); SELECT SCOPE_IDENTITY()";
        private const string UPDATE_FORMAT = "UPDATE [{0}] SET {1} Where {2}";
        private const string DELETE_FORMAT = "UPDATE [{0}] SET isDelete=1 Where {1}";
        private const string GET_FORMAT = "SELECT {0} FROM [{1}] where isDelete!=1 {2} {3}";
        private const string GET_BY_ID_FORMAT = "SELECT {0} FROM [{1}] WHERE Id=@Id";
        private const string CHECK_NAME_FORMAT = "SELECT COUNT(1) FROM [{0}] WHERE Name=@Name {1}";

        public string InsertFormat { get; set; }
        public string UpdateFormat { get; set; }
        public string DeleteFormat { get; set; }
        public string GetFormat { get; set; }
        public string GetByIdFormat { get; set; }
        public string CheckNameFormat { get; set; }

        public SqlQueryFormatter()
        {
            InsertFormat = INSERT_FORMAT;
            UpdateFormat = UPDATE_FORMAT;
            DeleteFormat = DELETE_FORMAT;
            GetFormat = GET_FORMAT;
            GetByIdFormat = GET_BY_ID_FORMAT;
            CheckNameFormat = CHECK_NAME_FORMAT;
        }




    }

    public class SqlGenerator
    {
        public string Statement { get; set; }
        public SqlOperationType OperationType { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        
        private int rowId;

        private List<string> condition = null;
        private List<string> orderColumns = null;
        private BaseVM viewModel = null;

        private SqlQueryFormatter sqlQuery = null;

        //public SqlParameterCollection SqlParams { get; set; }
        //tableName or StoredProcName
        public SqlGenerator(string tableName, SqlOperationType type, BaseForm form, 
            SqlQueryFormatter sqlQuery = null, List<string> condition = null)
            : this(tableName, type, form, null, 0, sqlQuery, condition)
        {

        }

        private SqlGenerator(string tableName, SqlOperationType type, BaseForm form, BaseVM view, int id, 
            SqlQueryFormatter sqlQuery=null, List<string> condition = null, List<string> orderColumns = null)
        {
            this.OperationType = type;
            this.condition = condition;
            this.orderColumns = orderColumns;
            this.viewModel = view;
            this.rowId = id;

            if (type == SqlOperationType.GetById && id <= 0)
            {
                throw new ArgumentException("Id must provide to get the data");
            }
            this.sqlQuery = sqlQuery ?? new SqlQueryFormatter();

            var sqlParamsList = GetProperties(form);
            Parameters = PrepareSqlParams(sqlParamsList);
            Statement = PrepareSqlStatement(tableName, type, sqlParamsList);
        }

        public SqlGenerator(string storedProcName, BaseForm form, SqlQueryFormatter sqlQuery = null, List<string> condition = null) :
            this(storedProcName, SqlOperationType.StoredProc, form, null, 0,sqlQuery, condition)
        {

        }

        public SqlGenerator(string tableName, BaseForm form, BaseVM view,
            SqlQueryFormatter sqlQuery = null, List<string> condition = null, List<string> orderColumns = null) :
            this(tableName, SqlOperationType.Get, form, view, 0, sqlQuery, condition, orderColumns)
        {
            //this.viewModel = view;
        }

        public SqlGenerator(string tableName, BaseVM view, int id, SqlQueryFormatter sqlQuery = null, List<string> condition = null) :
            this(tableName, SqlOperationType.GetById, null, view, id,sqlQuery, condition)
        {

        }

        private string PrepareSqlStatement(string tableName, SqlOperationType type, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var sqlStatement = "";
            switch (type)
            {
                case SqlOperationType.Insert:
                    sqlStatement = PrepareInsertSqlStatement(tableName, sqlParamsList);
                    break;
                case SqlOperationType.Update:
                    sqlStatement = PrepareUpdateSqlStatement(tableName, sqlParamsList);
                    break;
                case SqlOperationType.Delete:
                    sqlStatement = PrepareDeleteSqlStatement(tableName, sqlParamsList);
                    break;
                case SqlOperationType.Get:
                    sqlStatement = PrepareGetSqlStatement(tableName, sqlParamsList);
                    break;
                case SqlOperationType.GetById:
                    sqlStatement = PrepareGetByIdSqlStatement(tableName, sqlParamsList);
                    break;
                case SqlOperationType.CheckUniqueName:
                    sqlStatement = PrepareUniqueNameSqlStatement(tableName, sqlParamsList);
                    break;
                case SqlOperationType.StoredProc:
                    sqlStatement = tableName;
                    break;
            }
            return sqlStatement;

        }

        private string PrepareInsertSqlStatement(string tableName, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var ignoreColumns = new List<string> { "Id", "Code" };

            var query = sqlParamsList.Where(a => !ignoreColumns.Contains(a.Key));
            var columns = query.Select(a => a.Key).ToArray();
            var columnsSql = query.Select(a => "@" + a.Key).ToArray();
            var insertQuery = string.Join(", ", columns);
            var insertValuesQuery = string.Join(", ", columnsSql);
            return string.Format(sqlQuery.InsertFormat, tableName, insertQuery, insertValuesQuery);
        }

        private string PrepareUpdateSqlStatement(string tableName, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var ignoreColumns = new List<string> { "Id", "Code" };

            var query = sqlParamsList.Where(a => !ignoreColumns.Contains(a.Key));
            var columns = query.Select(a => a.Key + "=@" + a.Key).ToArray();
            var updateQuery = string.Join(", ", columns);
            var sqlCondition = "Id=@Id";
            if (condition != null && condition.Count > 0)
            {
                sqlCondition += string.Join(" and", condition.Select(a => a + "=@" + a).ToArray());
            }

            return string.Format(sqlQuery.UpdateFormat, tableName, updateQuery, sqlCondition);
        }

        private string PrepareDeleteSqlStatement(string tableName, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var sqlCondition = "Id=@Id";
            if (condition != null && condition.Count > 0)
            {
                sqlCondition += string.Join(" and", condition.Select(a => a + "=@" + a).ToArray());
            }

            return string.Format(sqlQuery.DeleteFormat, tableName, sqlCondition);
        }

        private string PrepareGetSqlStatement(string tableName, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var getColumnsPair = GetProperties(viewModel);
            var columns = getColumnsPair.Select(a => a.Key).ToArray();
            var getQuery = string.Join(", ", columns);
            var sqlCondition = "";
            var sqlOrderBy = "";
            if (condition != null && condition.Count > 0)
            {
                sqlCondition = " and " + string.Join(" and ", condition.Select(a => a + "=@" + a).ToArray());
            }
            if (orderColumns != null && orderColumns.Count > 0)
            {
                sqlOrderBy = string.Join(" , ", condition.Select(a => a).ToArray());
                sqlOrderBy = sqlQuery.GetFormat.ToLower().Contains(" order by ") ? ","+ sqlOrderBy : " order by " + sqlOrderBy;
            }

            return string.Format(sqlQuery.GetFormat, getQuery, tableName, sqlCondition, sqlOrderBy);
        }

        private string PrepareGetByIdSqlStatement(string tableName, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var getColumnsPair = GetProperties(viewModel);
            var columns = getColumnsPair.Select(a => a.Key).ToArray();
            var getQuery = string.Join(", ", columns);
            return string.Format(sqlQuery.GetByIdFormat, getQuery, tableName);
        }

        private string PrepareUniqueNameSqlStatement(string tableName, List<KeyValuePair<string, object>> sqlParamsList)
        {
            var idCondition = "";
            var id = sqlParamsList.Where(a => a.Key == "Id").Select(a => a.Value).FirstOrDefault();
            if ((int)id > 0)
            {
                idCondition = " AND Id != @Id ";
            }
            return string.Format(sqlQuery.CheckNameFormat, tableName, idCondition);
        }

        private List<SqlParameter> PrepareSqlParams(List<KeyValuePair<string, object>> sqlParamsList)
        {
            var SqlParams = new List<SqlParameter>();
            if (rowId > 0)
            {
                SqlParams.Add(new SqlParameter("@Id", rowId));
            }
            else
            {
                foreach (var sqlParam in sqlParamsList)
                {
                    if (sqlParam.Value != null)
                        SqlParams.Add(new SqlParameter("@" + sqlParam.Key, sqlParam.Value));
                    else
                        SqlParams.Add(new SqlParameter("@" + sqlParam.Key, DBNull.Value));
                }
            }
            return SqlParams;
        }

        private List<KeyValuePair<string, object>> GetProperties(object item) //where T : class
        {
            var result = new List<KeyValuePair<string, object>>();
            if (item != null)
            {
                var type = item.GetType();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var pi in properties)
                {
                    var selfValue = type.GetProperty(pi.Name).GetValue(item, null);
                    result.Add(new KeyValuePair<string, object>(pi.Name, selfValue));


                }
            }
            return result;
        }


    }
}
