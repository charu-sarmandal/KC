using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class UserRepository : BaseRepository<User,BaseForm,UserVM>
    {
        public UserRepository():base("User")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<UserVM>();
            var list2 = new List<UserVM>();
            var list3 = new List<UserVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<UserVM>();// Mapper.Map<System.Data.IDataReader, List<UserVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<UserVM>();// Mapper.Map<System.Data.IDataReader, List<UserVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<UserVM>(); ;// Mapper.Map<System.Data.IDataReader, List<UserVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
