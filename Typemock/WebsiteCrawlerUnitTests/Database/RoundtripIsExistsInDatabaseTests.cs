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
    public class RoundtripIsExistsInDatabaseTests
    {
        #region Unit Tests for RoundtripIsExistsInDatabase
        
        [Test]
        public void RoundtripIsExistsInDatabase_Test_Returns0()
        {
            // WebsiteCrawler.Database.Database.RoundtripIsExistsInDatabase(Roundtrip)(34)=[VVVVVVVVVVVVVVVVVVVVXXXVVVXXXXVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("utf8", "@dep_date", "@departure", "SELECT Id FROM roundtrip WHERE departure=@departure AND arrival=@arrival AND  ser" +
                "viceClass=@serviceClass AND validate_carrier=@validateCarrier AND validateFlight" +
                "_number=@validateFlightNumber AND operate_carrier=@operateCarrier AND operateFli" +
                "ght_number=@operateFlightNumber AND travelDuration=@travelDuration AND dep_date=" +
                "@dep_date AND dep_time=@dep_time AND arr_date=@arr_date AND arr_time=@arr_time;", (uint)1);    // plan 107 (103: 0) (95: 0) (87: 0) (86: 0) (15: 0)
            var roundtrip = new Roundtrip();    // plan 105
            roundtrip.ValidateCarrier = "Id";    // plan 118 (105: 0) (101: 0)
            var dateTime = new DateTime((int)2016, (int)2, 29);    // plan 44 (41: 0) (42: 0) (43: 0)
            roundtrip.ArrTime = dateTime;    // plan 119 (118)(105: 0) (44: 0)
            var dateTime1 = DateTime.MaxValue;    // plan 40 (38: 0)
            roundtrip.DepTime = dateTime1;    // plan 120 (119)(105: 0) (40: 1)
            roundtrip.ServiceClass = 1;    // plan 121 (120)(105: 0) (13: 0)
            roundtrip.Arrival = "@arrival";    // plan 123 (121)(105: 0) (88: 0)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 129
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 130 (129: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 131
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).IgnoreCall();    // plan 132 (131: 0)
            var handleMySqlCommand = Isolate.Fake.AllInstances<MySqlCommand>(Members.CallOriginal);    // plan 135
            var fakeMySqlDataReader = Isolate.Fake.Instance<MySqlDataReader>();    // plan 134
            Isolate.WhenCalled(() => handleMySqlCommand.ExecuteReader()).WillReturn(fakeMySqlDataReader);    // plan 137 (135: 0) (134: 0)
             
            // act
            var result = database.RoundtripIsExistsInDatabase(roundtrip);    // plan 138 (107: 0) (123)(105: 0) (130: 0) (132: 0) (137: 0)
             
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