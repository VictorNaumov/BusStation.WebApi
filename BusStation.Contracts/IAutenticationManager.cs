using BusStation.Data.DataTransferObjects.Admin;
using System.Threading.Tasks;

namespace BusStation.Contracts
{
    public interface IAutenticationManager
    {
        public Task<bool> ValidateUser(AdminValidationDTO dataForAuth);

        public Task<string> CreateToken();
    }
}
