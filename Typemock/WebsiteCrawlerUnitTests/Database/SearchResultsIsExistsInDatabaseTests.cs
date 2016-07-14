using System;
using WebsiteCrawler.Database;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;
using TypeMock.ArrangeActAssert.Suggest;


namespace CurrentUnitTestProject.Database
{
    [SafetyNet(typeof(WebsiteCrawler.Database.Database))]
    [Isolated()]
    [TestFixture()]
    public class SearchResultsIsExistsInDatabaseTests
    {
        #region Unit Tests for SearchResultsIsExistsInDatabase
        
        [Test]
        public void SearchResultsIsExistsInDatabase_Test_Returns0()
        {
            // WebsiteCrawler.Database.Database.SearchResultsIsExistsInDatabase(SearchResult)(44)=[VVVVXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXVVVVVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("@departure", "@arrDate", "@depTime", "utf8", (uint)1);    // plan 122 (89: 0) (95: 0) (93: 0) (112: 0) (15: 0)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 138
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 139 (138: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 140
            var fakeMySqlException = Isolate.Fake.Instance<MySqlException>();    // plan 136
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).WillThrow(fakeMySqlException);    // plan 141 (140: 0) (136: 0)
             
            // act
            var result = database.SearchResultsIsExistsInDatabase(null);    // plan 142 (122: 0) (134: 0) (139: 0) (141: 0)
             
            // assert
            Assert.AreEqual(0, result);
            // side affects on handleMySqlConnection
            Isolate.Verify.WasCalledWithAnyArguments(() => handleMySqlConnection.Close());
        }

        
        [Test]
        public void SearchResultsIsExistsInDatabase_Test_Returns0_001()
        {
            // WebsiteCrawler.Database.Database.SearchResultsIsExistsInDatabase(SearchResult)(44)=[VVVVVVVVVVVVVVVVVVVVVVVVVVVVVXXXVVVXXXXVVVXV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("@arrDate", "@fee", "@validateCarrier", "@arrival", (uint)0);    // plan 149 (95: 0) (107: 0) (100: 0) (90: 0) (14: 0)
            var search = new SearchResult();    // plan 119
            search.Price = 0.1m;    // plan 131 (119: 0) (29: 0)
            search.Rtrip = (byte)1;    // plan 133 (131)(119: 0) (5: 0)
            search.TravelDuration = (-1);    // plan 143 (133)(119: 0) (11: 0)
            var dateTime = new DateTime((int)2016, (int)2, 29);    // plan 44 (41: 0) (42: 0) (43: 0)
            search.ArrTime = dateTime;    // plan 144 (143)(119: 0) (44: 0)
            search.ValidateCarrierNumber = 0;    // plan 150 (144)(119: 0) (12: 0)
            search.OperateCarrier = "{0:yyyy-MM-dd}";    // plan 151 (150)(119: 0) (92: 0)
            search.ValidateCarrier = "@arrDate";    // plan 152 (151)(119: 0) (95: 0)
            var dateTime1 = DateTime.MinValue;    // plan 39 (38: 0)
            search.ArrDate = dateTime1;    // plan 153 (152)(119: 0) (39: 1)
            search.Url = "@departure";    // plan 164 (153)(119: 0) (89: 0)
            search.Type1 = 0;    // plan 167 (164)(119: 0) (12: 0)
            search.Arrival = "@type";    // plan 170 (167)(119: 0) (88: 0)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 138
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 139 (138: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 140
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).IgnoreCall();    // plan 147 (140: 0)
            var handleMySqlCommand = Isolate.Fake.AllInstances<MySqlCommand>(Members.CallOriginal);    // plan 185
            var fakeMySqlDataReader = Isolate.Fake.Instance<MySqlDataReader>();    // plan 184
            Isolate.WhenCalled(() => handleMySqlCommand.ExecuteReader()).WillReturn(fakeMySqlDataReader);    // plan 198 (185: 0) (184: 0)
             
            // act
            var result = database.SearchResultsIsExistsInDatabase(search);    // plan 199 (149: 0) (170)(119: 0) (139: 0) (147: 0) (198: 0)
             
            // assert
            Assert.AreEqual(0, result);
            // side affects on handleMySqlConnection
            Isolate.Verify.WasCalledWithAnyArguments(() => handleMySqlConnection.CreateCommand());
            Isolate.Verify.WasCalledWithAnyArguments(() => handleMySqlConnection.Close());
            // side affects on fakeMySqlDataReader
            Isolate.Verify.WasCalledWithAnyArguments(() => fakeMySqlDataReader.Read());
        }

        #endregion

        #region Setup
        [SetUp]
        public void Setup_RunBeforeEachTest()
        {
            TestUtil.ResetAllStatics();
            TestUtil.AssertRunningInSandbox();
        }
        #endregion

    }
}