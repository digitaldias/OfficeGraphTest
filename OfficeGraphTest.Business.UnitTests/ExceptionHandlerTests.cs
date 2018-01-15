using Moq;
using OfficeGraphTest.CrossCutting.TestHelpers;
using OfficeGraphTest.Domain.Contracts;
using Should;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace OfficeGraphTest.Business.UnitTests
{
    public class ExceptionHandlerTests : TestsFor<ExceptionHandler>
    {

        [Fact]
        public void Get_WhenCalled_DoesNotThrowNotImplementedException()
        {
            // Arrange
            Func<int> someFunction = () => 10;

            // Act            
            var result = Instance.Get(someFunction);
        }


        [Fact]
        public void Get_UnsafeMethodBehavesNicely_ResultOfUnsafeMethod()
        {
            // Arrange
            Func<int> niceMethod = () => 10;

            // Act
            var result = Instance.Get(niceMethod);

            // Assert
            result.ShouldEqual(10);
        }


        [Fact]
        public void Get_UnsafeMethodCrashes_ReturnsDefaultOfType()
        {
            // Arrange
            Func<int> niceMethod = () => throw new ArgumentNullException();

            // Act
            var result = Instance.Get(niceMethod);

            // Assert
            result.ShouldEqual(default(int));
        }


        [Fact]
        public void Get_UnsafeMethodCrashes_LogsTheException()
        {
            // Arrange
            var exception = new ArgumentNullException("I'm so null");
            Func<int> niceMethod = () => throw exception;

            // Act
            var result = Instance.Get(niceMethod);

            // Assert
            var loggerMock = GetMockFor<ILogger>();

            loggerMock.Verify(logger => logger.LogException(exception), Times.Once());
        }


        [Fact]
        public void Get_UnsafeMethodIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Func<int> nullFunction = null;

            // Act
            Assert.Throws<ArgumentNullException>(() => Instance.Get(nullFunction));
        }


        [Fact]
        public async Task GetAsync_WhenCalled_DoesNotThrowAnything()
        {
            // Arrange
            Func<Task<int>> harmlessFunction = () => Task.FromResult<int>(10);

            // Act
            var result = await Instance.GetAsync(harmlessFunction);
        }


        [Fact]
        public async Task GetAsync_MethodBehavesNicely_ResultOfUnsafeMethod()
        {
            // Arrange
            Func<Task<int>> harmlessFunction = () => Task.FromResult<int>(10);

            // Act
            var result = await Instance.GetAsync(harmlessFunction);

            // Assert
            result.ShouldEqual(10);
        }


        [Fact]
        public async Task GetAsync_MethodThrowsException_ReturnsDefaultOfType()
        {
            // Arrange
            var badException = new Exception("I'm bad!");
            Func<Task<int>> harmlessFunction = () => throw badException;

            // Act
            var result = await Instance.GetAsync(harmlessFunction);

            // Assert
            result.ShouldEqual(default(int));
        }


        [Fact]
        public async Task GetAsync_MethodThrowsException_LogsTheException()
        {
            // Arrange
            var badException = new Exception("I'm bad!");
            Func<Task<int>> harmlessFunction = () => throw badException;

            // Act
            var result = await Instance.GetAsync(harmlessFunction);

            // Assert
            var loggerMock = GetMockFor<ILogger>();
            loggerMock.Verify(logger => logger.LogException(badException), Times.Once());
        }


        [Fact]
        public async Task GetAsync_unsafeFunctionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Func<Task<int>> nullFunction = null;

            // Act
            await Assert.ThrowsAsync<ArgumentNullException>( () => Instance.GetAsync(nullFunction));
        }



        [Fact]
        public void Run_WhenCalled_DoesNotThrowException()
        {
            // Arrange
            Action fairlySafeAction = () => Debug.WriteLine("I'm benign");

            // Act
            Instance.Run(fairlySafeAction);
        }


        [Fact]
        public void Run_MethodJustWorks_ExecutesTheAction()
        {
            // Arrange
            bool flagWasSet = false;
            Action fairlySafeAction = () => flagWasSet = true;

            // Act
            Instance.Run(fairlySafeAction);

            // Assert
            flagWasSet.ShouldBeTrue();
        }


        [Fact]
        public void Run_ActionThrowsException_DoesNotRethrow()
        {
            // Arrange
            var badException = new Exception("I'm bad");
            Action badAction = () => throw badException;

            // Act
            Instance.Run(badAction);
        }


        [Fact]
        public void Run_ActionThrowsException_ExceptionIsLogged()
        {
            // Arrange
            var badException = new Exception("I'm bad");
            Action badAction = () => throw badException;

            // Act
            Instance.Run(badAction);

            // Assert
            GetMockFor<ILogger>()
                .Verify(logger => logger.LogException(badException), Times.Once());
        }


        [Fact]
        public void Run_ActionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Action nullAction = null;

            // Act
            Assert.Throws<ArgumentNullException>(() => Instance.Run(nullAction));
        }



        [Fact]
        public async Task RunAsync_WhenCalled_DoesNotThrowExceptions()
        {
            // Arrange
            Func<Task> blankFunction = () => Task.Run(() => Debug.WriteLine("nothing to see here"));

            // Act
            await Instance.RunAsync(blankFunction);
        }


        [Fact]
        public async Task RunAsync_WhenCalled_ExecutesTheProvidedAction()
        {
            // Arrange
            bool flagSet = false;
            Func<Task> blankFunction = () => Task.Run(() => flagSet = true);

            // Act
            await Instance.RunAsync(blankFunction);

            // Assert
            flagSet.ShouldBeTrue();
        }


        [Fact]
        public async Task RunAsync_UnsafeFunctionThrows_NoExceptionIsThrown()
        {
            // Arrange
            var badException = new Exception("I'm bad");
            Func<Task> blankFunction = () => Task.Run(() => throw badException);

            // Act
            await Instance.RunAsync(blankFunction);
        }


        [Fact]
        public async Task RunAsync_UnsafeFunctionThrows_ExceptionIsLogged()
        {
            // Arrange
            var badException = new Exception("I'm bad");
            Func<Task> blankFunction = () => Task.Run(() => throw badException);

            // Act
            await Instance.RunAsync(blankFunction);

            // Assert
            GetMockFor<ILogger>()
                .Verify(logger => logger.LogException(badException), Times.Once());
        }



        [Fact]
        public async Task RunAsync_UnsafeFunctionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Func<Task<int>> nullFunc = null;

            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(() =>  Instance.RunAsync(nullFunc));

            // Assert
        }
    }
}
