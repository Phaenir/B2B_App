using UnitTestB2B_App.Models.APA.Configuration;
using TypeMock.ArrangeActAssert.Suggest;
using TypeMock.ArrangeActAssert;
using System.Linq;
using NUnit.Framework;


//-------------------------------------------------------------------------------------------------------------------
// Unit Tests suggested by Typemock.
// You are invited to modify the tests just take note to leave tests in region
//-------------------------------------------------------------------------------------------------------------------
namespace UnitTestB2B_App.Models.APA.Configuration
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
            // B2B_App.Models.APA.Configuration.CommonConfig.IsSame(CommonConfig)(6)=[VVXXVV]
             
            // arrange
            var commonConfig = new CommonConfig();    // plan 81
            commonConfig.AgencyName = "AgencyName";    // plan 82 (81: 0) (318: 0)
            var start = new CommonConfig();    // plan 84
             
            // act
            var result = commonConfig.IsSame(start);    // plan 86 (83)(81: 0) (84: 0)
             
            // assert
            Assert.AreEqual(false, result);
        }

        
        [Test]
        public void IsSame_Test_ReturnsFalse_001()
        {
            // B2B_App.Models.APA.Configuration.CommonConfig.IsSame(CommonConfig)(6)=[VVXXVV]
             
            // arrange
            var commonConfig = new CommonConfig();    // plan 81
            commonConfig.AgencyName = "AgencyName";    // plan 82 (81: 0) (318: 0)
            var start = new CommonConfig();    // plan 84
             
            // act
            var result = commonConfig.IsSame(start);    // plan 86 (83)(81: 0) (84: 0)
             
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