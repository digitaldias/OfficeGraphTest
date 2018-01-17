using FizzWare.NBuilder;
using Moq;
using OfficeGraphTest.CrossCutting.TestHelpers;
using OfficeGraphTest.Domain.Contracts;
using OfficeGraphTest.Domain.Entities;
using Should;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OfficeGraphTest.Business.UnitTests
{
    public class OfficeGraphClientTests : TestsFor<OfficeGraphClient>
    {
        public override void DoBeforeInstanceCreated()
        {
            // Need a real exceptionHandler when testing classes that use it
            var exceptionHandler = new ExceptionHandler(GetInstance<ILogger>());

            Inject<IExceptionHandler>(exceptionHandler);
        }


        [Fact]
        public void Initialize_IdentityManagerIsNull_ResultIsFalse()
        {
            // Arrange  
            EjectAllInstancesOf<IIdentityManager>();

            // Act
            
            var result = Instance.Initialize();

            // Assert
            result.ShouldBeFalse();
        }


        [Fact]
        public void Initialize_IdentityManagerIsNull_LogsTheProblem()
        {
            // Arrange
            EjectAllInstancesOf<IIdentityManager>();

            // Act
            Instance.Initialize();

            // Assert
            GetMockFor<ILogger>()
                .Verify(l => l.LogError(It.IsAny<string>()), 
                Times.AtLeastOnce());
        }


        [Fact]
        public void Initialize_IdentityManagerIsOk_CallsSignInMethod()
        {
            // Act
            Instance.Initialize();

            // Assert
            GetMockFor<IIdentityManager>().Verify(o => o.SignIn(It.IsAny<string>()), Times.AtLeastOnce());
        }


        [Fact]
        public void Initialize_SignInIsOk_ReturnsTrue()
        {
            // Arrange
            GetMockFor<IIdentityManager>()
                .Setup(o => o.SignIn(It.IsAny<string>()))
                .Returns(true);

            // Act
            var result = Instance.Initialize();

            // Assert
            result.ShouldBeTrue();
        }


        [Fact]
        public void Initialize_SignInFails_ReturnsFalse()
        {
            // Arrange
            GetMockFor<IIdentityManager>().Setup(o => o.SignIn(It.IsAny<string>())).Returns(false);

            // Act
            var result = Instance.Initialize();

            // Assert
            result.ShouldBeFalse();
        }


        [Fact]
        public void Initialize_SignInFails_ProblemIsLogged()
        {
            // Arrange
            GetMockFor<IIdentityManager>()
                .Setup(o => o.SignIn(It.IsAny<string>()))
                .Returns(false);

            // Act
            var result = Instance.Initialize();

            // Assert
            GetMockFor<ILogger>()
                .Verify(l => l.LogError(It.IsAny<string>()), Times.AtLeastOnce());
        }


        [Fact]
        public void Initialize_SignInThrowsException_ReturnsFalse()
        {
            // Arrange
            var badException = new Exception("I'm bad");
            GetMockFor<IIdentityManager>()
                .Setup(o => o.SignIn(It.IsAny<string>())).Throws(badException);

            // Act
            var result = Instance.Initialize();

            // Assert
            result.ShouldBeFalse();
        }


        [Fact]
        public void Initialize_SignInThrowsException_ExceptionIsLogged()
        {
            // Arrange
            var badException = new Exception("I'm bad");
            GetMockFor<IIdentityManager>()
                .Setup(o => o.SignIn(It.IsAny<string>())).Throws(badException);

            // Act
            var result = Instance.Initialize();

            // Assert (Exceptionhandler will inherently log, so this test is superfluous
            GetMockFor<ILogger>()
                .Verify(l => l.LogException(badException),
                Times.AtLeastOnce());
        }


        [Fact]
        public async Task GetMyInformationAsync_EverythingIsOk_CallsRestApi()
        {
            // Arrange
            var token = ValidBearerToken;
            GetMockFor<IIdentityManager>().SetupGet(o => o.BearerToken).Returns(token);
          

            // Act
            var result = await Instance.GetMyInformationAsync();

            // Assert
            GetMockFor<IOfficeGraphReader>()
                .Verify(gr => gr.GetMyInformationAsync(token),
                Times.AtLeastOnce());
        }


        [Fact]
        public async Task GetMyInformationAsync_RestCallThrowsException_ReturnsNull()
        {
            // Arrange
            var token = ValidBearerToken;
            GetMockFor<IIdentityManager>().SetupGet(o => o.BearerToken).Returns(token);

            var badException = new Exception("I'm bad");
            GetMockFor<IOfficeGraphReader>().Setup(r => r.GetMyInformationAsync(token)).Throws(badException);


            // Act
            var result = await Instance.GetMyInformationAsync();

            // Assert
            result.ShouldBeNull();
        }


        [Fact]
        public async Task GetMyInformationAsync_RestCallReturnsSomething_ReturnGraphUserObject()
        {
            // Arrange
            var token = ValidBearerToken;
            var jsonString = GraphUserString;

            GetMockFor<IIdentityManager>().SetupGet(o => o.BearerToken).Returns(token);
            GetMockFor<IOfficeGraphReader>()
                .Setup(o => o.GetMyInformationAsync(token))
                .Returns(Task.FromResult(jsonString));

            // Act
            var result = await Instance.GetMyInformationAsync();

            // Assert
            result.id.ShouldEqual("48d31887-5fad-4d73-a9f5-3c356e68a038");
            result.givenName.ShouldEqual("Megan");
            result.mail.ShouldEqual("MeganB@M365x214355.onmicrosoft.com");
        }


        [Fact]
        public async Task SignOut_WhenCalled_DoesNotThrowNotImplementedException()
        {
            // Act
            var result = await DoesThrowAsync<NotImplementedException>(() => Instance.SignOut());

            // Assert
            result.ShouldBeFalse();
        }


        [Fact]
        public async Task SignOut_SomethingFailsWithIdentityManager_LoggerLogsWarning()
        {
            // Arrange
            GetMockFor<IIdentityManager>()
                .Setup(o => o.SignOut())
                .Returns(false);

            // Act
            var result = await DoesThrowAsync<NotImplementedException>(() => Instance.SignOut());

            // Assert
            GetMockFor<ILogger>()
                .Verify(l => l.logWarning(It.IsAny<string>()), Times.Once());
        }


        [Fact]
        public async Task SignOut_IdentityManagerReportsSuccess_LoggerIsNotInvoked()
        {
            // Arrange
            GetMockFor<IIdentityManager>()
                .Setup(o => o.SignOut())
                .Returns(true);

            // Act
            var result = await DoesThrowAsync<NotImplementedException>(() => Instance.SignOut());

            // Assert
            GetMockFor<ILogger>()
                .Verify(l => l.logWarning(It.IsAny<string>()), Times.Never());
        }


        #region Helper properties and methods


        public string ValidBearerToken => "BEARER 173291y591y3259y5915y1985719817591751";


        public GraphUser ValidGraphUser
        {
            get
            {
                return Builder<GraphUser>.CreateNew().Build();
            }
        }


        public string GraphUserString
        {
            get
            {
                return "{ \"@odata.context\": \"https://graph.microsoft.com/v1.0/$metadata#users/$entity\", \"id\": \"48d31887-5fad-4d73-a9f5-3c356e68a038\", \"businessPhones\": [ \"+1 412 555 0109\" ], \"displayName\": \"Megan Bowen\", \"givenName\": \"Megan\", \"jobTitle\": \"Auditor\", \"mail\": \"MeganB@M365x214355.onmicrosoft.com\", \"mobilePhone\": null, \"officeLocation\": \"12/1110\", \"preferredLanguage\": \"en-US\", \"surname\": \"Bowen\", \"userPrincipalName\": \"MeganB@M365x214355.onmicrosoft.com\" }";
            }
        }


        #endregion
    }
}
