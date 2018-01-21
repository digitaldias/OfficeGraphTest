using OfficeGraphTest.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace OfficeGraphTest.Data.Fakes
{
    //TODO: Dammit, need internet connection to download sample data!! 
    public class FakeOfficeGraphReader : IOfficeGraphReader
    {
        public Task<byte[]> GetImageBytesAsync(string bearerToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMyContactsAsync(string bearerToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMyInformationAsync(string bearerToken)
        {
            throw new NotImplementedException();
        }
    }
}
