using System.Transactions;
using System;
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
    public class InsertSearchResultsToDatabaseTests
    {
        #region Unit Tests for InsertSearchResultsToDatabase
        
        [Test]
        public void InsertSearchResultsToDatabase_Test_Returns0()
        {
            // WebsiteCrawler.Database.Database.InsertSearchResultsToDatabase(SearchResult)(37)=[VVVXXXXXXXXXXXXXXXXXXXXXXXXXXVVVVVVVV]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("server", "user", "password", "name", (uint)0);    // plan 121 (314: 0) (315: 0) (316: 0) (317: 0) (14: 0)
            var search = new SearchResult();    // plan 116
            var handleIDbConnection = Isolate.Fake.AllInstances<IDbConnection>();    // plan 141
            Isolate.WhenCalled(() => handleIDbConnection.Open()).IgnoreCall();    // plan 142 (141: 0)
            var handleMySqlConnection = Isolate.Fake.AllInstances<MySqlConnection>();    // plan 143
            var fakeMySqlException = Isolate.Fake.Instance<MySqlException>();    // plan 139
            Isolate.WhenCalled(() => handleMySqlConnection.Open()).WillThrow(fakeMySqlException);    // plan 144 (143: 0) (139: 0)
             
            // act
            var result = database.InsertSearchResultsToDatabase(search);    // plan 145 (121: 0) (136)(116: 0) (142: 0) (144: 0)
             
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