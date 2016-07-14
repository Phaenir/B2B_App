using System;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;
using TypeMock.ArrangeActAssert.Suggest;
using WebsiteCrawler.Database;


namespace CurrentUnitTestProject.Database
{
    [SafetyNet(typeof(WebsiteCrawler.Database.Database))]
    [Isolated()]
    [TestFixture()]
    public class GetServiceIdTests
    {
        #region Unit Tests for GetServiceId
        
        [Test]
        [ExpectedException(typeof(Exception))]
        public void GetServiceId_Test_ThrowsException()
        {
            // WebsiteCrawler.Database.Database.GetServiceId(Service)(23)=[VVVVXXXXXXXXXXXVVVVVVXX]
             
            // arrange
            var database = new WebsiteCrawler.Database.Database("server", "user", "password", "name", (uint)0);    // plan 93 (1040: 0) (1041: 0) (1042: 0) (1043: 0) (14: 0)
            var service = new Service();    // plan 104
             
            // act
            var result = database.GetServiceId(service);    // plan 109 (93: 0) (104: 0)
            
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