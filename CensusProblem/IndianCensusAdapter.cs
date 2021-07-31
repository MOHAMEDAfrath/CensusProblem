using CensusProblem.DataDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusProblem
{
    public class IndianCensusAdapter:GetCensusAdapter
    {
        string[] censusData;
        //dictionary to store the indian census data;
        List<CensusData> dataMap;

        //method list as a type for load census method
        public List<CensusData> LoadCensusData(string csvFilePath, string header)
        {
            dataMap = new List<CensusData>();
            censusData = GetCensusData(csvFilePath, header);
            //Skips the header
            foreach (string data in censusData.Skip(1))
            {
                //Checks for delimiter (,)
                if (!data.Contains(","))
                {
                    throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.INVALID_DELIMITER, "Wrong delimiter");
                }
                //split by ,
                string[] col = data.Split(',');
                //IndiaStateCensusData
                if (csvFilePath.Contains("IndianStateCensusInformation.csv"))
                {
                    dataMap.Add(new CensusData(col[0], col[1], col[2], col[3],col[4],col[5],col[6]));
                }
            }
            return dataMap;

        }
    }
}
