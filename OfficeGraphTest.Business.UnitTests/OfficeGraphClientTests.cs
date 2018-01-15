using Moq;
using OfficeGraphTest.CrossCutting.TestHelpers;
using OfficeGraphTest.Domain.Contracts;
using Should;
using Xunit;

namespace OfficeGraphTest.Business.UnitTests
{
    public class OfficeGraphClientTests : TestsFor<OfficeGraphClient>
    {

        [Fact]
        public void Initialize_IdentityManagerIsNull_ResultIsFalse()
        {
            // Arrange
            IIdentityManager identityManager = null;

            // Act
            var result =  Instance.Initialize(identityManager);

            // Assert
            result.ShouldBeFalse();
        }


        [Fact]
        public void Initialize_IdentityManagerIsNull_LogsTheProblem()
        {
            // Arrange
            IIdentityManager identityManager = null;

            // Act
            Instance.Initialize(identityManager);

            // Assert
            GetMockFor<ILogger>()
                .Verify(l => l.LogError(It.IsAny<string>()), 
                Times.AtLeastOnce());
        }


        [Fact]
        public void Initialize_IdentityManagerIsOk_CallsSignInMethod()
        {
            // Arrange
            var identityManagerMock          = new Mock<IIdentityManager>();
            IIdentityManager identityManager = identityManagerMock.Object;

            // Act
            Instance.Initialize(identityManager);

            // Assert
            identityManagerMock.Verify(o => o.SignIn(), Times.AtLeastOnce());
        }


        [Fact]
        public void Initialize_SignInIsOk_ReturnsTrue()
        {
            // Arrange
            var identityManagerMock = new Mock<IIdentityManager>();
            identityManagerMock.Setup(o => o.SignIn()).Returns(true);
            IIdentityManager identityManager = identityManagerMock.Object;

            // Act
            var result = Instance.Initialize(identityManager);

            // Assert
            result.ShouldBeTrue();
        }


        [Fact]
        public void Initialize_SignInFails_ReturnsFalse()
        {
            // Arrange
            var identityManagerMock = new Mock<IIdentityManager>();
            identityManagerMock.Setup(o => o.SignIn()).Returns(false);
            IIdentityManager identityManager = identityManagerMock.Object;

            // Act
            var result = Instance.Initialize(identityManager);

            // Assert
            result.ShouldBeFalse();
        }


        [Fact]
        public void Initialize_SignInFails_ProblemIsLogged()
        {
            // Arrange
            var identityManagerMock = new Mock<IIdentityManager>();
            identityManagerMock.Setup(o => o.SignIn()).Returns(false);
            IIdentityManager identityManager = identityManagerMock.Object;

            // Act
            var result = Instance.Initialize(identityManager);

            // Assert
            GetMockFor<ILogger>()
                .Verify(l => l.LogError(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
