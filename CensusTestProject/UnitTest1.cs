using CensusProblem;
using CensusProblem.DataDAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CensusTestProject
{
    [TestClass]
    public class UnitTest1
    {
        CsvAdapterFactory csv;
        List<FullCensusData> IndianCensusRecords;
        //Indian Census data
        string censusFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCensusInformation.csv";
        string invalidFileCsvPath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidCensusFile.csv";
        string invalidFileTypePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidCensusFile.csa";
        string invalidDelimiterFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCensusWithInvalidDelimiter.csv";
        string invalidHeaderFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCensusWithInvalidHeader.csv";
        //State code data
        string stateCodeFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCode.csv";
        string stateCodeInvalidFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidIndianStateCode.csv";
        string stateCodeInvalidFileTypePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidIndianStateCode.csa";
        string stateCodeInvalidFileDelimiterPath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidIndianStateDelimiterCode.csv";
        string stateCodeInvalidFileHeaderPath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidIndianStateHeaderCode.csv";
        //Initialize before running each test method
        [TestInitialize]
        public void Setup()
        {
            csv = new CsvAdapterFactory();
            IndianCensusRecords = new List<FullCensusData>();
        }
        //UC1: Count of matching records is returned
        [TestMethod]
        public void GivenIndianStateCensusReturnCountOfMatchingRecords()
        {
            IndianCensusRecords = csv.LoadCsvData(CensusAnalyzer.Country.INDIA, censusFilePath, "State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy");
            Assert.AreEqual(13, IndianCensusRecords.Count);

        }
        //TC1.2 Given invalid file name returns file not found custom exception
        [TestMethod]
        public void IncorrectFileReturnThrowsException()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, invalidFileCsvPath, "State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, result.exception);
        }
        //TC1.3 given file with wrong file type throws invalid type custom exception
        [TestMethod]
        public void IncorrectFileExtensionReturnThrowException()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, invalidFileTypePath, "State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_EXTENSION, result.exception);
        }
        //TC1.4 Wrong delimiter in csvfile throws wrong csv delimiter
        [TestMethod]
        public void IncorrectDelimiterReturnThrowException()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, invalidDelimiterFilePath, "State.Population.Increase.Area(Km2).Density.Sex-Ratio.Literacy"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_DELIMITER, result.exception);
        }
        //TC1.5 Wrong headers in csvfile.
        [TestMethod]
        public void IncorrectHeadersInCsvReturnThrowsException()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, invalidHeaderFilePath, "State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADERS, result.exception);
        }
        //UC2: Count of matching records for state is returned
        [TestMethod]
        public void GivenIndianStateCensusReturnCountOfMatchingRecordsForStateCode()
        {
            IndianCensusRecords = csv.LoadCsvData(CensusAnalyzer.Country.INDIA, stateCodeFilePath, "SerailNo,StateName,StateCode");
            Assert.AreEqual(11, IndianCensusRecords.Count);

        }
        //TC2.2 Given invalid file name returns file not found custom exception
        [TestMethod]
        public void IncorrectFileReturnThrowsExceptionForStateCode()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, stateCodeInvalidFilePath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, result.exception);
        }
        //TC2.3 given file with wrong file type throws invalid type custom exception
        [TestMethod]
        public void IncorrectFileExtensionReturnThrowExceptionForStateCode()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, stateCodeInvalidFileTypePath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_EXTENSION, result.exception);
        }
        //TC2.4 Wrong delimiter in csvfile throws wrong csv delimiter
        [TestMethod]
        public void IncorrectDelimiterReturnThrowExceptionForStateCode()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, stateCodeInvalidFileDelimiterPath, "SerailNo.StateName.StateCode"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_DELIMITER, result.exception);
        }
        //TC2.5 Wrong headers in csvfile.
        [TestMethod]
        public void IncorrectHeadersInCsvReturnThrowsExceptionForStateCode()
        {
            var result = Assert.ThrowsException<CensusAnalyzerException>(() => csv.LoadCsvData(CensusAnalyzer.Country.INDIA, stateCodeInvalidFileHeaderPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_HEADERS, result.exception);
        }
    }
}
