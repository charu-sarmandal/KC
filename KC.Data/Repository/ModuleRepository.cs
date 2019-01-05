using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class ModuleRepository : BaseRepository<Module,BaseForm,ModuleVM>
    {
        public ModuleRepository():base("Module")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<ModuleVM>();
            var list2 = new List<ModuleVM>();
            var list3 = new List<ModuleVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<ModuleVM>();// Mapper.Map<System.Data.IDataReader, List<ModuleVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<ModuleVM>();// Mapper.Map<System.Data.IDataReader, List<ModuleVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<ModuleVM>(); ;// Mapper.Map<System.Data.IDataReader, List<ModuleVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
