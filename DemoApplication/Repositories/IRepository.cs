using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApplication.Models;

namespace DemoApplication.Repositories
{
    public interface IRepository
    {
        Task<ICollection<Vehicle>> LoadVehicles();
        Task SaveVehicle(Vehicle vehicle);
    }
}