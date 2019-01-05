using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data.Repository
{
    public class TaxRateRepository : BaseRepository<TaxRate,BaseForm,TaxRateVM>
    {
        public TaxRateRepository():base("TaxRate")
        {

        }

        protected override object ExcecuteDataWithMultiple(SqlGenerator sqlGenerator)
        {
            var list = new List<TaxRateVM>();
            var list2 = new List<TaxRateVM>();
            var list3 = new List<TaxRateVM>();
            DbExceute.Exceute(sqlGenerator, ((command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        list = reader.GenerateList<TaxRateVM>();// Mapper.Map<System.Data.IDataReader, List<TaxRateVM>>(reader); // for 1st result
                    reader.NextResult();
                    if (reader.HasRows)
                        list2 = reader.GenerateList<TaxRateVM>();// Mapper.Map<System.Data.IDataReader, List<TaxRateVM>>(reader); // for 2nd result
                    reader.NextResult();
                    if (reader.HasRows)
                        list3 = reader.GenerateList<TaxRateVM>(); ;// Mapper.Map<System.Data.IDataReader, List<TaxRateVM>>(reader); // for 3rd result
                }
            }));
            return list;

        }
    }
}
