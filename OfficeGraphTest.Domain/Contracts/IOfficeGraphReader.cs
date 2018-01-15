using System.Threading.Tasks;

namespace OfficeGraphTest.Domain.Contracts
{
    public interface IOfficeGraphReader
    {
        Task<string> GetMyInformationAsync(string bearerToken);        
    }
}