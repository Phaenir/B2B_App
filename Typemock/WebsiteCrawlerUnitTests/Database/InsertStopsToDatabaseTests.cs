using System.Linq;
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
    public class InsertStopsToDatabaseTests
    {
        #region Unit Tests for InsertStopsToDatabase
        
        [Test]
        public void InsertStopsToDatabase_Test_ReturnsFalse()
        {
            // WebsiteCrawler.Database.Database.InsertStopsToDatabase(Stops)(24)=[VVVXXXXXXXXXXXXXVVVVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("server", "user", "password", "name", (uint)0);    // plan 103 (187: 0) (188: 0) (189: 0) (190: 0) (14: 0)
            var stops = Isolate.Fake.Instance<Stops>();    // plan 122
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 131
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 132 (131: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>();    // plan 133
            var fakeMySqlException = Isolate.Fake.Instance<MySqlException>();    // plan 129
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).WillThrow(fakeMySqlException);    // plan 134 (133: 0) (129: 0)
             
            // act
            var result = database.InsertStopsToDatabase(stops);    // plan 135 (103: 0) (122: 0) (132: 0) (134: 0)
             
            // assert
            Assert.AreEqual(false, result);
            // side affects on handleMySqlConnection
            Isolate.Verify.WasCalledWithAnyArguments(() => handleMySqlConnection.Close());
        }

        
        [Test]
        public void InsertStopsToDatabase_Test_ReturnsCommandTextIsInsertIntoService_cl()
        {
            // WebsiteCrawler.Database.Database.InsertStopsToDatabase(Stops)(24)=[VVVVVVVVVVVVVVVVXXXXVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("server", "user", "password", "name", (uint)1);    // plan 123 (195: 0) (196: 0) (197: 0) (198: 0) (15: 0)
            var stops = Isolate.Fake.Instance<Stops>();    // plan 122
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>();    // plan 133
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).IgnoreCall();    // plan 132 (133: 0)
             
            // act
            var result = database.InsertStopsToDatabase(stops);    // plan 163 (123: 0) (122: 0) (132: 0) (139: 0) (156: 0) (144: 0) (0: 0) (159: 0) (160: 0) (162: 0)
             
            // assert
            // side affects on handleMySqlConnection
            Assert.AreEqual("INSERT INTO service_class(search_id,arrival,arr_date,arr_time,operate_carrier,ope" +
                "rateFlight_number,departure,dep_date,dep_time) VALUES (@searchId,@arrival,@arrDa" +
                "te,@arrTime,@operateCarrier,@operateFlightNumber,@departure,@depDate,@depTime);", handleMySqlConnection.CreateCommand().CommandText);
            // side affects on result
            Assert.AreEqual(true, result);
            // side affects on handleMySqlConnection
            Isolate.Verify.WasCalledWithAnyArguments(() => handleMySqlConnection.CreateCommand());
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