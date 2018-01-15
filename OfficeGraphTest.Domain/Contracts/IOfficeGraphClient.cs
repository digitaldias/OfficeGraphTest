using OfficeGraphTest.Domain.Entities;
using System.Threading.Tasks;

namespace OfficeGraphTest.Domain.Contracts
{
    public interface IOfficeGraphClient
    {
        bool Initialize();

        Task<GraphUser> GetMyInformationAsync();
    }
}