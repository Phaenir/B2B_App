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
    public class InsertRoundtripsToDatabaseTests
    {
        #region Unit Tests for InsertRoundtripsToDatabase
        
        [Test]
        public void InsertRoundtripsToDatabase_Test_Returns0()
        {
            // WebsiteCrawler.Database.Database.InsertRoundtripsToDatabase(Roundtrip)(27)=[VVVXXXXXXXXXXXXXXXXVVVVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("@travelDuration", "@arrDate", "@depDate", "INSERT INTO roundtripdeparture,arrival,dep_date,dep_time,arr_date,arr_time,servic" +
                "eClass,validate_carrier,validateFlight_number,operate_carrier,operateFlight_numb" +
                "er,travelDuration VALUES @departure,@arrival,@depDate,@depTime,@arrDate,@arrTime" +
                ",@serviceClass,@validateCarrier,@validateFlightNumber,@operateCarrier,@operateFl" +
                "ightNumber,@travelDuration;", (uint)1);    // plan 114 (102: 0) (95: 0) (93: 0) (90: 0) (15: 0)
            var roundtrip = new Roundtrip();    // plan 110
            var dateTime = DateTime.MinValue;    // plan 39 (38: 0)
            roundtrip.DepDate = dateTime;    // plan 126 (110: 0) (39: 1)
            roundtrip.ValidateCarrier = "@arrival";    // plan 128 (126)(110: 0) (92: 0)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 136
            var fakeMySqlException = Isolate.Fake.Instance<MySqlException>();    // plan 134
            Isolate.WhenCalled(() => handleIDbConnection.Open()).WillThrow(fakeMySqlException);    // plan 137 (136: 0) (134: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 138
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).WillThrow(fakeMySqlException);    // plan 139 (138: 0) (134: 0)
             
            // act
            var result = database.InsertRoundtripsToDatabase(roundtrip);    // plan 140 (114: 0) (128)(110: 0) (137: 0) (139: 0)
             
            // assert
            Assert.AreEqual(0, result);
            // side affects on handleMySqlConnection
            Isolate.Verify.WasCalledWithAnyArguments(() => handleMySqlConnection.Close());
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