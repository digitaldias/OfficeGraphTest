using OfficeGraphTest.CrossCutting.TestHelpers;
using OfficeGraphTest.Domain.Contracts;
using Should;
using System;
using Xunit;

namespace OfficeGraphTest.Business.UnitTests
{
    /// <summary>
    /// These tests will all be working "live" against Graph and 
    /// Windows, so each test needs to be tagged as an integration test. 
    /// Failiure to do so will make the other unit tests too slow to be practical
    /// 
    /// </summary>
    public class IdentityManagerTests : TestsFor<IdentityManager>
    {
        private ISettings _settings;

        public IdentityManagerTests()            
        {
            _settings = ConstructTestableSettingsFromMock();            
        }


        public override void DoBeforeInstanceCreated()
        {
            // We actually don't need a real logger for this. A mock is fine
            var logger = GetInstance<ILogger>();
            var exceptionHandler = new ExceptionHandler(logger);

            // Do the override
            Instance = new IdentityManager(exceptionHandler, _settings);
        }


        [Fact, Trait("Category", "Integration")]
        public void SignOut_resourceIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            string nullResource = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => Instance.SignOut(nullResource));
        }


        [Fact, Trait("Category", "Integration")]
        public void SignOut_UserIsSignedIn_ReturnsTrue()
        {
            // Arrange
            Instance.SignIn(_settings["officeGraphResource"]);

            // Act
            var result = Instance.SignOut(_settings["officeGraphResource"]);

            // Assert
            result.ShouldBeTrue();
        }


        [Fact, Trait("Category", "Integration")]
        public void SignIn_ResourceIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            string nullArgument = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => Instance.SignIn(nullArgument));            
        }


        [Fact, Trait("Category", "Integration")]
        public void SignIn_UserEntersCorrectInfo_ReturnsTrue()
        {
            // Act
            var result = Instance.SignIn(_settings["officeGraphResource"]);

            // Assert
            result.ShouldBeTrue();
        }


        #region Helper Methods and properties

        private ISettings ConstructTestableSettingsFromMock()
        {
            var settingsMock = GetMockFor<ISettings>();

            settingsMock.Setup(o => o["authority"]  )        .Returns("https://login.windows.net/leapno.onmicrosoft.com");
            settingsMock.Setup(o => o["clientDomain"])       .Returns("leapno.onmicrosoft.com");
            settingsMock.Setup(o => o["officeGraphResource"]).Returns("https://graph.microsoft.com");
            settingsMock.Setup(o => o["applicationId"])      .Returns("a25be7f4-918d-4310-b33e-991a10544dab");
            settingsMock.Setup(o => o["redirectUri"])        .Returns("http://somewhere.nice.com");

            return settingsMock.Object;
        }

        #endregion
    }
}
