using DemoApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApplication.Repositories
{
    public interface IRepository
    {
        Task<ICollection<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicle(int id);
        Task AddVehicle(Vehicle vehicle);
        Task UpdateVehicle(Vehicle vehicle);
        Task DeleteVehicle(Vehicle vehicle); //Can also do DeleteVehicle(int id)
    }
}