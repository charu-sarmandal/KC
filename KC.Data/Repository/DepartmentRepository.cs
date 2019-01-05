using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class DepartmentRepository : BaseRepository<Department,BaseForm,DepartmentVM>
    {
        public DepartmentRepository():base("Department")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<DepartmentVM>();
            var list2 = new List<DepartmentVM>();
            var list3 = new List<DepartmentVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<DepartmentVM>();// Mapper.Map<System.Data.IDataReader, List<DepartmentVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<DepartmentVM>();// Mapper.Map<System.Data.IDataReader, List<DepartmentVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<DepartmentVM>(); ;// Mapper.Map<System.Data.IDataReader, List<DepartmentVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
