using System.Collections.Generic;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain
{
    public interface IVehicleService
    {
        Task<Vehicle> GetVehicle(int id);
        Task<ICollection<Vehicle>> GetVehicles();
        Task AddVehicle(Vehicle vehicle);
        Task DeleteVehicle(Vehicle vehicle);
        Task DeleteVehicle(int id);
        Task UpdateVehicle(Vehicle vehicle);
        Task UpdateVehicle(Vehicle oldVehicle, Vehicle newVehicle);
    }
}
