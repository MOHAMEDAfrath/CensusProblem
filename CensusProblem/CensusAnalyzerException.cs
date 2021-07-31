using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusProblem
{
   public class CensusAnalyzerException:Exception
    {
        //declaring exception type constants
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_EXTENSION, INVALID_HEADERS, INVALID_DELIMITER, NO_SUCH_COUNTRY
        }
        public ExceptionType exception;
        //Base throws the message to the base class constructor
        public CensusAnalyzerException(ExceptionType exception, string message) : base(message)
        {
            this.exception = exception;
        }
    }
}
