using NUnit.Framework;
using TypeMock.ArrangeActAssert;
using TypeMock.ArrangeActAssert.Suggest;
using WebsiteCrawler;
using WebsiteCrawler.Database;

namespace CurrentUnitTestProject.Database
{
    [SafetyNet(typeof(CommonConfigurationModel))]
    [Isolated()]
    [TestFixture()]
    public class GetConfigurationTests
    {
        #region Unit Tests for GetConfiguration
        
        [Test]
        public void GetConfiguration_Test_ReturnsAgencyNameIsName()
        {
            // WebsiteCrawler.Database.CommonConfigurationModel.GetConfiguration(String)(18)=[VVVVVVVVVVVVVVVVVV]
             
            // arrange
            var commonConfigurationModel = new CommonConfigurationModel();    // plan 82
            var fakeCommonConfiguration = Isolate.Fake.Instance<CommonConfiguration>();    // plan 98
            Isolate.WhenCalled(() => CommonConfiguration.LoadFromFile(null)).WillReturn(fakeCommonConfiguration);    // plan 100 (0: 0) (98: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.BerlogicEngine.Agency.Name).WillReturn("Name");    // plan 129 (98: 0) (256: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.BerlogicEngine.Agency.Number).WillReturn("Number");    // plan 105 (98: 0) (257: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.BerlogicEngine.Agency.Salespoint).WillReturn("Salespoint");    // plan 239 (98: 0) (258: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.Database.Host).WillReturn("Host");    // plan 163 (98: 0) (259: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.Database.Name).WillReturn("Name");    // plan 139 (98: 0) (260: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.Database.Port).WillReturn((-1));    // plan 246 (98: 0) (11: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.Database.RemoteHost).WillReturn("RemoteHost");    // plan 144 (98: 0) (261: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.Database.User).WillReturn("User");    // plan 120 (98: 0) (262: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.SearchEngine.FormLimit).WillReturn((-1));    // plan 147 (98: 0) (11: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.SearchEngine.PageLimit).WillReturn(1);    // plan 122 (98: 0) (13: 0)
            Isolate.WhenCalled(() => fakeCommonConfiguration.SearchEngine.SearchLimit).WillReturn(1);    // plan 175 (98: 0) (13: 0)
             
            // act
            var result = commonConfigurationModel.GetConfiguration("path");    // plan 254 (82: 0) (255: 0) (100: 0) (129: 0) (105: 0) (237: 0) (239: 0) (163: 0) (139: 0) (245: 0) (246: 0) (144: 0) (120: 0) (147: 0) (122: 0) (175: 0)
             
            // assert
            Assert.AreEqual("Name", result.AgencyName);
            Assert.AreEqual("Number", result.AgencyNumber);
            Assert.AreEqual("", result.AgencyPassword);
            Assert.AreEqual("Salespoint", result.AgencySalespoint);
            Assert.AreEqual("Host", result.DatabaseHost);
            Assert.AreEqual("RemoteHost", result.DatabaseRemote);
            Assert.AreEqual("", result.DatabasePassword);
            Assert.AreEqual("User", result.DatabaseUser);
            Assert.AreEqual("Name", result.DatabaseName);
            Assert.AreEqual((-1), result.DatabasePort);
            Assert.AreEqual((-1), result.FormLimit);
            Assert.AreEqual(1, result.PageLimit);
            Assert.AreEqual(1, result.SearchLimit);
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