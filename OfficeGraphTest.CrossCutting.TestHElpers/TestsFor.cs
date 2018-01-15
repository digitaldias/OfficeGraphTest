using Moq;
using StructureMap.AutoMocking.Moq;

namespace OfficeGraphTest.CrossCutting.TestHelpers
{
    public abstract class TestsFor<TInstance> where TInstance : class
    {
        public MoqAutoMocker<TInstance> AutoMock { get; set; }


        public TInstance Instance { get; set; }


        public TestsFor()
        {
            // Create our Automocker
            AutoMock = new MoqAutoMocker<TInstance>();

            // Execute anything that needs to execute prior to Instance creation
            DoBeforeInstanceCreated();

            // Create the instance based on the automocker configuration
            Instance = AutoMock.ClassUnderTest;
        }


        public virtual void DoBeforeInstanceCreated()
        {
            // No implementation here
        }


        /// <summary>
        /// Returns the mock that owns the instance of TContract
        /// </summary>
        public Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(AutoMock.Get<TContract>());
        }
    }
}
