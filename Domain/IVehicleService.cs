using Domain.Models;
using System.Threading.Tasks;

namespace Domain
{
    public interface IVehicleService
    {
        Task AddVehicle(Vehicle vehicle);
        Task DeleteVehicle(Vehicle vehicle);
        Task DeleteVehicle(int id);
        Task UpdateVehcile(Vehicle vehicle);
        Task UpdateVehcile(Vehicle oldVehicle, Vehicle newVehicle);
    }
}
