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
    public class InsertServiceClassToDatabaseTests
    {
        #region Unit Tests for InsertServiceClassToDatabase
        
        [Test]
        public void InsertServiceClassToDatabase_Test_ReturnsFalse()
        {
            // WebsiteCrawler.Database.Database.InsertServiceClassToDatabase(Service)(18)=[VVVXXXXXXVVVVVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("server", "user", "password", "name", (uint)1);    // plan 103 (194: 0) (195: 0) (196: 0) (197: 0) (15: 0)
            var service = new Service();    // plan 92
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>();    // plan 124
            var fakeMySqlException = Isolate.Fake.Instance<MySqlException>();    // plan 120
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).WillThrow(fakeMySqlException);    // plan 123 (124: 0) (120: 0)
             
            // act
            var result = database.InsertServiceClassToDatabase(service);    // plan 126 (103: 0) (113)(92: 0) (123: 0) (125: 0)
             
            // assert
            Assert.AreEqual(false, result);
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