using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public abstract class BaseRepository<T, TForm, TVm> where T : class where TForm : BaseForm where TVm : BaseVM, new()
    {
        private string dbTableName = "";
        private bool cacheEnable;
        private string cacheKey;
        private SqlQueryFormatter sqlQuery;
        public BaseRepository(string dbTableName, bool cacheEnable = true, SqlQueryFormatter sqlQuery = null)
        {
            this.dbTableName = dbTableName;
            this.cacheEnable = cacheEnable;
            this.cacheKey = "Cache_" + dbTableName;
            this.sqlQuery = sqlQuery;
        }


        #region "Insert, Update, Soft Delete"
        public virtual int Insert(BaseForm form, List<string> condition = null)
        {
            var id = Excecute(form, SqlOperationType.Insert, condition);
            ClearCache(dbTableName);
            return id;
        }
        public virtual TVm InsertWithData(BaseForm  form, List<string> condition = null)
        {
            var id = Insert(form, condition);
            return GetById(id);
        }

        public virtual int Update(BaseForm form, List<string> condition = null)
        {
            var id = Excecute(form, SqlOperationType.Update, condition);
            ClearCache(dbTableName);
            return id;
        }
        public virtual TVm UpdateWithData(BaseForm form, List<string> condition = null)
        {
            var id = Update(form, condition);
            return GetById(id);
        }

        public virtual int Delete(BaseForm form, List<string> condition = null)
        {
            var id = Excecute(form, SqlOperationType.Delete, condition);
            ClearCache(dbTableName);
            return id;
        }
        public virtual TVm DeleteWithData(BaseForm form, List<string> condition = null)
        {
            var id = Delete(form, condition);
            return GetById(id);
        }

        protected virtual void ClearCache(string cacheName)
        {
            CacheHandler.ClearContains(cacheName);
        }
        #endregion

        public virtual List<TVm> Get(TForm form = null, bool enableCaching = true, List<string> condition = null, List<string> orderColumns = null)
        {
            enableCaching = enableCaching && condition == null;//TODO : Need to Check
            return CacheHandler<List<TVm>>.Get(cacheKey , () =>
            {
                var sqlGenerator = new SqlGenerator(dbTableName, form, new TVm(), sqlQuery, condition, orderColumns);//for Get
                return ExcecuteData(sqlGenerator);
            }, enableCaching);
        }

        public virtual TVm GetById(int id)
        {
            var sqlGenerator = new SqlGenerator(dbTableName, new TVm(), id, null);//for GetById
            var list = ExcecuteData(sqlGenerator);
            return list.Count > 0 ? list[0] : null;

        }
        public virtual bool CheckNameExists(TForm form, List<string> condition = null)
        {
            var sqlGenerator = new SqlGenerator(dbTableName, SqlOperationType.CheckUniqueName, form, sqlQuery, condition);
            var list = ExcecuteData(sqlGenerator);
            return list.Count > 0;

        }

        public virtual List<TVm> GetByStoredProc(string storedProcName, TForm form, bool enableCaching = true, List<string> condition = null)
        {
            enableCaching = enableCaching && condition == null;//TODO : Need to Check
            return CacheHandler<List<TVm>>.Get(cacheKey + "_" + storedProcName, () =>
            {
                var sqlGenerator = new SqlGenerator(storedProcName, form, sqlQuery, condition);
                return ExcecuteData(sqlGenerator);
            }, enableCaching);
        }

        public virtual int ExecuteByStoredProcBulk(string storedProcName, TForm form, string typeName, System.Data.DataTable dtBulk, List<string> condition = null)
        {
            var sqlGenerator = new SqlGenerator(storedProcName, form, sqlQuery, condition);
            sqlGenerator.Parameters.AddWithTableValue(typeName, dtBulk);
            return Excecute(form, sqlGenerator);
        }

        public virtual List<TVm> GetByStoredProcBulk(string storedProcName, TForm form, string typeName, System.Data.DataTable dtBulk, List<string> condition = null)
        {
            var sqlGenerator = new SqlGenerator(storedProcName, form, sqlQuery, condition);
            sqlGenerator.Parameters.AddWithTableValue(typeName, dtBulk);
            return ExcecuteData(sqlGenerator);
        }

        protected virtual int Excecute(BaseForm form, SqlOperationType type, List<string> condition = null)
        {
            var sqlGenerator = new SqlGenerator(dbTableName, type, form, sqlQuery, condition);
            return Excecute(form, sqlGenerator);
        }

        protected virtual int Excecute(BaseForm form, SqlGenerator sqlGenerator)
        {
            var id = 0;
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                if (sqlGenerator.OperationType == SqlOperationType.Insert)
                    id = Convert.ToInt32((decimal)command.ExecuteScalar());
                else
                {
                    command.ExecuteNonQuery();
                    id = form.Id;
                }
            }));
            return id;
        }

        protected virtual TVm ExcecuteWithData(TForm form, SqlOperationType type, List<string> condition = null)
        {
            var id = Excecute(form, type, condition);
            return GetById(id);
        }

        protected virtual List<TVm> ExcecuteData(SqlGenerator sqlGenerator)
        {
            var list = new List<TVm>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                    if (reader.HasRows)
                    {
                        list = reader.GenerateList<TVm>();
                    }                        
            }));
            return list;
        }

        public virtual object GetByStoredProcWithMultipleData(string storedProcName, TForm form, bool enableCaching = true, List<string> condition = null)
        {
            enableCaching = enableCaching && condition == null; //TODO : Need to Check
            return CacheHandler<object>.Get(cacheKey + "_" + storedProcName, () =>
            {
                var sqlGenerator = new SqlGenerator(storedProcName, form, sqlQuery, condition);
                return ExcecuteDataWithMultiple(sqlGenerator);
            }, enableCaching);

        }

        protected virtual object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            throw new ArgumentException("Implement missing for ExcecuteDataWithMultiple");
        }

    }
}
