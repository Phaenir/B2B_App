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
    public class GetRoundtripsIdTests
    {
        #region Unit Tests for GetRoundtripsId
        
        [Test]
        public void GetRoundtripsIdByCallingInsertRoundtripsToDatabase_Test_Returns0()
        {
            // WebsiteCrawler.Database.Database.InsertRoundtripsToDatabase(Roundtrip)(27)=[VVVVVVVVVVVVVVVVVVVXXXXVVVV]
            // WebsiteCrawler.Database.Database.GetRoundtripsId()(24)=[VVVVVVVVXXXVVVXXXXXVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("Id", "utf8", "utf8", "utf8", (uint)1);    // plan 109 (87: 0) (103: 0) (103: 0) (103: 0) (15: 0)
            var roundtrip = new Roundtrip();    // plan 105
            roundtrip.TravelDuration = 0;    // plan 120 (105: 0) (12: 0)
            var dateTime = new DateTime((int)2016, (int)2, 29);    // plan 44 (41: 0) (42: 0) (43: 0)
            roundtrip.ArrTime = dateTime;    // plan 133 (120)(105: 0) (44: 0)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 128
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 135 (128: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 130
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).IgnoreCall();    // plan 136 (130: 0)
            var handleMySqlCommand = Isolate.Fake.AllInstances<MySqlCommand>(Members.CallOriginal);    // plan 139
            Isolate.WhenCalled(() => handleMySqlCommand.ExecuteNonQuery()).WillReturn(1);    // plan 140 (139: 0) (13: 0)
            var fakeMySqlDataReader = Isolate.Fake.Instance<MySqlDataReader>();    // plan 138
            Isolate.WhenCalled(() => handleMySqlCommand.ExecuteReader()).WillReturn(fakeMySqlDataReader);    // plan 143 (139: 0) (138: 0)
             
            // act
            var result = database.InsertRoundtripsToDatabase(roundtrip);    // plan 144 (109: 0) (133)(105: 0) (135: 0) (136: 0) (140: 0) (143: 0)
             
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