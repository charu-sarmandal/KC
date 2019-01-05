using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class MaterialRepository : BaseRepository<Material,BaseForm,MaterialVM>
    {
        public MaterialRepository():base("Material")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<MaterialVM>();
            var list2 = new List<MaterialVM>();
            var list3 = new List<MaterialVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<MaterialVM>();// Mapper.Map<System.Data.IDataReader, List<MaterialVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<MaterialVM>();// Mapper.Map<System.Data.IDataReader, List<MaterialVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<MaterialVM>(); ;// Mapper.Map<System.Data.IDataReader, List<MaterialVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
