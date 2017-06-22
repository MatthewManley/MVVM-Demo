using DemoApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApplication.Repositories
{
    public class TestRepository : IRepository
    {
        private List<Vehicle> Vehicles { get; } = new List<Vehicle>();

        public Task<ICollection<Vehicle>> LoadVehicles()
        {
            Vehicles.Add(new Car { Capacity = 5, Make = "Fiat", Model = "Punto", TopSpeed = 70, Price = 1000 });
            Vehicles.Add(new Car { Capacity = 4, Make = "Renault", Model = "Megane", TopSpeed = 80, Price = 2000 });
            Vehicles.Add(new Car { Capacity = 5, Make = "Ford", Model = "Fiesta", TopSpeed = 90, Price = 1500 });
            Vehicles.Add(new Truck { Capacity = 3, Make = "Volvo", Model = "FMX", WheelBase = "Large", Price = 10000 });
            Vehicles.Add(new Truck { Capacity = 3, Make = "Volvo", Model = "VHD", WheelBase = "Small", Price = 8000 });
            
            return Task.FromResult(Vehicles as ICollection<Vehicle>);
        }

        public async Task SaveVehicle(Vehicle vehicle)
        {
            //I belive this removes the old vehicle based upon ID, then adds back the new one. Should probably test it though.
            Vehicles.Remove(vehicle);
            Vehicles.Add(vehicle);
        }
    }
}