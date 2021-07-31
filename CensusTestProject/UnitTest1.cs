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
        List<CensusData> IndianCensusRecords;
        string censusFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCensusInformation.csv";
        string invalidFileCsvPath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidCensusFile.csv";
        string invalidFileTypePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\InvalidCensusFile.csa";
        string invalidDelimiterFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCensusWithInvalidDelimiter.csv";
        string invalidHeaderFilePath = @"C:\Users\afrat\source\repos\CensusProblem\CensusProblem\IndianStateCensusWithInvalidHeader.csv";
        //Initialize before running each test method
        [TestInitialize]
        public void Setup()
        {
            csv = new CsvAdapterFactory();
            IndianCensusRecords = new List<CensusData>();
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
    }
}
