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
    public class GetAirlineCodeTests
    {
        #region Unit Tests for GetAirlineCode
        
        [Test]
        public void GetAirlineCode_Test_ReturnsNull()
        {
            // WebsiteCrawler.Database.Database.GetAirlineCode(String)(24)=[VVVVXXXXXXXXXXXVVVVVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("127.0.0.1", "testUser", "testPassword", "testName", (uint)1201);    // plan 98 (86: 0) (89: 0) (86: 0) (89: 0) (14: 0)
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 113
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 114 (113: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>(Members.CallOriginal);    // plan 115
            var fakeMySqlException = Isolate.Fake.Instance<MySqlException>();    // plan 111
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).WillThrow(fakeMySqlException);    // plan 116 (115: 0) (111: 0)
             
            // act
            var result = database.GetAirlineCode(null);    // plan 117 (98: 0) (109: 0) (114: 0) (116: 0)
             
            // assert
            Assert.IsNull(result);
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