using NUnit.Framework;
using TypeMock.ArrangeActAssert;
using TypeMock.ArrangeActAssert.Suggest;
using WebsiteCrawler.Database;


namespace CurrentUnitTestProject.Database
{
    [SafetyNet(typeof(CommonConfig))]
    [Isolated()]
    [TestFixture()]
    public class IsSameTests
    {
        #region Unit Tests for IsSame
        
        [Test]
        public void IsSame_Test_ReturnsFalse()
        {
            // WebsiteCrawler.Database.CommonConfig.IsSame(CommonConfig)(6)=[VVXXVV]
             
            // arrange
            var commonConfig = new CommonConfig();    // plan 81
            commonConfig.DatabaseHost = "DatabaseHost";    // plan 82 (81: 0) (327: 0)
            var start = new CommonConfig();    // plan 87
             
            // act
            var result = commonConfig.IsSame(start);    // plan 89 (85)(81: 0) (87: 0)
             
            // assert
            Assert.AreEqual(false, result);
        }
        
        [Test]
        public void IsSame_Test_ReturnsFalse_003()
        {
            // WebsiteCrawler.Database.TemplateSearchEngine.IsSame(TemplateSearchEngine)(15)=[VVXVXVVXXXXXXXV]
             
            // arrange
            var templateSearchEngine = new TemplateSearchEngine();    // plan 98
            var htmlTags = new HtmlTags();    // plan 83
            var htmlTags1 = new HtmlTags(htmlTags);    // plan 150 (83: 0)
            templateSearchEngine.ArrivalPoint = htmlTags1;    // plan 177 (172: 0) (150: 0)
            templateSearchEngine = new TemplateSearchEngine(templateSearchEngine);    // plan 184 (177)(172: 0)
            templateSearchEngine.ArrivalPoint = htmlTags;    // plan 173 (172: 0) (150)(83: 0)
             
            // act
            var result = templateSearchEngine.IsSame(templateSearchEngine);    // plan 186 (184: 0) (181)(172: 0)
             
            // assert
            Assert.AreEqual(false, result);
        }

        
        [Test]
        public void IsSame_Test_ReturnsFalse_004()
        {
            // WebsiteCrawler.Database.TemplateSearchEngine.IsSame(TemplateSearchEngine)(15)=[VVXVXVXVXVXVVXV]
             
            // arrange
            var templateSearchEngine = new TemplateSearchEngine();    // plan 84
            var htmlTags = new HtmlTags();    // plan 83
            templateSearchEngine.DeparturePoint = htmlTags;    // plan 85 (84: 0) (83: 0)
            templateSearchEngine.DepartureDate = htmlTags;    // plan 86 (85)(84: 0) (83: 0)
            templateSearchEngine.ArrivalDate = htmlTags;    // plan 87 (86)(84: 0) (83: 0)
            templateSearchEngine.ArrivalPoint = htmlTags;    // plan 89 (87)(84: 0) (83: 0)
            templateSearchEngine.Roundtrip = htmlTags;    // plan 417 (89)(84: 0) (150)(83: 0)
            var searchEngine = new TemplateSearchEngine();    // plan 98
            searchEngine.ArrivalPoint = htmlTags;    // plan 106 (98: 0) (83: 0)
            searchEngine.Roundtrip = htmlTags;    // plan 116 (106)(98: 0) (83: 0)
            searchEngine.DepartureDate = htmlTags;    // plan 164 (129)(98: 0) (150)(83: 0)
            searchEngine.DeparturePoint = htmlTags;    // plan 284 (164)(98: 0) (150)(83: 0)
            searchEngine.ArrivalDate = htmlTags;    // plan 546 (284)(98: 0) (150)(83: 0)
             
            // act
            var result = templateSearchEngine.IsSame(searchEngine);    // plan 620 (587)(84: 0) (546)(98: 0)
             
            // assert
            Assert.AreEqual(false, result);
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