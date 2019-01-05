using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class RoleRepository : BaseRepository<Role,BaseForm,RoleVM>
    {
        public RoleRepository():base("Role")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<RoleVM>();
            var list2 = new List<RoleVM>();
            var list3 = new List<RoleVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<RoleVM>();// Mapper.Map<System.Data.IDataReader, List<RoleVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<RoleVM>();// Mapper.Map<System.Data.IDataReader, List<RoleVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<RoleVM>(); ;// Mapper.Map<System.Data.IDataReader, List<RoleVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
