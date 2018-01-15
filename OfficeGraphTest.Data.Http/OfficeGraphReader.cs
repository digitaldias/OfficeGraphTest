using OfficeGraphTest.Domain.Contracts;
using System.Threading.Tasks;

namespace OfficeGraphTest.Data.Http
{
    public class OfficeGraphReader : IOfficeGraphReader
    {
        public Task<string> GetMyInformationAsync(string bearerToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
