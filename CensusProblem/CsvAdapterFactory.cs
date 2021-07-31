using CensusProblem.DataDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusProblem
{
    public class CsvAdapterFactory
    {
        public List<CensusData> LoadCsvData(CensusAnalyzer.Country country, string csvFilePath, string header)
        {
            //Checks for the country
            switch (country)
            {
                case (CensusAnalyzer.Country.INDIA):
                    {
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, header);
                    }
                default:
                    {
                        throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.NO_SUCH_COUNTRY, "NO SUCH COUNTRY");
                    }
            }
        }
    }
}
