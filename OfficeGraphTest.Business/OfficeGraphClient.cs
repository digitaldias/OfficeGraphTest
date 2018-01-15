using OfficeGraphTest.Domain.Contracts;
using OfficeGraphTest.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OfficeGraphTest.Business
{
    public class OfficeGraphClient : IOfficeGraphClient
    {
        public Task<GraphUser> GetMyInformationAsync()
        {
            throw new NotImplementedException();
        }

        public void Initialize(IIdentityManager identityManager)
        {
            throw new NotImplementedException();
        }
    }
}
