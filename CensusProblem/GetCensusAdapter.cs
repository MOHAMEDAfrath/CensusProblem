using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusProblem
{
    public class GetCensusAdapter
    {
        public string[] GetCensusData(string csvFilePath, string header)
        {
            string[] censusData;
            //Checks whether the file is present or not
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, "File Not Found");
            }
            //Checks the file is of csv extension or not
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.INVALID_FILE_EXTENSION, "Invalid File Extension");
            }
            //Read the data from the csv file
            censusData = File.ReadAllLines(csvFilePath);
            //checks for valid header.
            if (censusData[0] != header)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.INVALID_HEADERS, "Invalid Header");
            }
            return censusData;
        }

    }
       


}
