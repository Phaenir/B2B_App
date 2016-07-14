using System;
using System.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;
using TypeMock.ArrangeActAssert.Suggest;
using WebsiteCrawler.Database;


namespace CurrentUnitTestProject.Database
{
    [SafetyNet(typeof(WebsiteCrawler.Database.Database))]
    [Isolated()]
    [TestFixture()]
    public class GetSearchResultIdTests
    {
        #region Unit Tests for GetSearchResultId
        
        [Test]
        public void GetSearchResultIdByCallingInsertSearchResultsToDatabase_Test_Returns0()
        {
            // WebsiteCrawler.Database.Database.InsertSearchResultsToDatabase(SearchResult)(37)=[VVVVVVVVVVVVVVVVVVVVVVVVVVVVVXXXXVVVV]
            // WebsiteCrawler.Database.Database.GetSearchResultId()(23)=[VVVVVVVVXXXVVVXXXXVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("SELECT id FROM search_result ORDER BY Id DESC LIMIT 1;", "Id", "utf8", "Id", (uint)1);    // plan 120 (86: 0) (87: 0) (113: 0) (87: 0) (15: 0)
            var search = new SearchResult();    // plan 115
            search.RoundtripId = 1;    // plan 131 (115: 0) (13: 0)
            var dateTime = new DateTime((int)2016, (int)2, 29);    // plan 44 (41: 0) (42: 0) (43: 0)
            search.ArrTime = dateTime;    // plan 132 (131)(115: 0) (44: 0)
            var dateTime1 = DateTime.MaxValue;    // plan 40 (38: 0)
            search.DepDate = dateTime1;    // plan 133 (132)(115: 0) (40: 1)
            search.Fee = 0.1m;    // plan 135 (133)(115: 0) (29: 0)
            search.Price = 0.1m;    // plan 137 (135)(115: 0) (29: 0)
            search.Arrival = "SELECT id FROM search_result ORDER BY Id DESC LIMIT 1;";    // plan 138 (137)(115: 0) (86: 0)
            var dateTime2 = DateTime.MinValue;    // plan 39 (38: 0)
            search.DepTime = dateTime2;    // plan 139 (138)(115: 0) (39: 1)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 145
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 146 (145: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 147
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).IgnoreCall();    // plan 148 (147: 0)
            var handleMySqlCommand = Isolate.Fake.AllInstances<MySqlCommand>(Members.CallOriginal);    // plan 151
            Isolate.WhenCalled(() => handleMySqlCommand.ExecuteNonQuery()).WillReturn(0);    // plan 152 (151: 0) (12: 0)
            var fakeMySqlDataReader = Isolate.Fake.Instance<MySqlDataReader>();    // plan 150
            Isolate.WhenCalled(() => handleMySqlCommand.ExecuteReader()).WillReturn(fakeMySqlDataReader);    // plan 155 (151: 0) (150: 0)
             
            // act
            var result = database.InsertSearchResultsToDatabase(search);    // plan 156 (120: 0) (139)(115: 0) (146: 0) (148: 0) (152: 0) (155: 0)
             
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