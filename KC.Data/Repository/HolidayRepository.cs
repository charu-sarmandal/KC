using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class HolidayRepository : BaseRepository<Holiday,BaseForm,HolidayVM>
    {
        public HolidayRepository():base("Holiday")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<HolidayVM>();
            var list2 = new List<HolidayVM>();
            var list3 = new List<HolidayVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<HolidayVM>();// Mapper.Map<System.Data.IDataReader, List<HolidayVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<HolidayVM>();// Mapper.Map<System.Data.IDataReader, List<HolidayVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<HolidayVM>(); ;// Mapper.Map<System.Data.IDataReader, List<HolidayVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
