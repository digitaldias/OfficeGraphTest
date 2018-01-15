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
        /// Allows you to inject your own concrete implementation of a TContract. 
        /// NOTE: MUST be called witin DoBeforeInstanceCreation()!! 
        /// </summary>
        public void Inject<TContract>(TContract with) where TContract : class
        {            
            AutoMock.Inject<TContract>(with);
        }


        public void EjectAllInstancesOf<TContract>() where TContract : class
        {
            AutoMock.Container.EjectAllInstancesOf<TContract>();
        }


        /// <summary>
        /// Returns the mock that owns the instance of TContract
        /// </summary>
        public Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(GetInstance<TContract>());
        }


        /// <summary>
        /// Returns the given instance of TContract
        /// </summary>
        public TContract GetInstance<TContract>() where TContract : class
        {
            return AutoMock.Get<TContract>();
        }
    }
}
