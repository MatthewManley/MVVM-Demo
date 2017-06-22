using DemoApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Repositories
{
    public class TestRepository : IRepository
    {
        private Dictionary<int, Vehicle> Vehicles { get; } = new Dictionary<int, Vehicle>();

        public TestRepository()
        {
            //I am doing this for vehicle indexing, since this isn't actually a database.
            List<Vehicle> tempList = new List<Vehicle>
            {
                new Car {Capacity = 5, Make = "Fiat", Model = "Punto", TopSpeed = 70, Price = 1000},
                new Car {Capacity = 4, Make = "Renault", Model = "Megane", TopSpeed = 80, Price = 2000},
                new Car {Capacity = 5, Make = "Ford", Model = "Fiesta", TopSpeed = 90, Price = 1500},
                new Truck {Capacity = 3, Make = "Volvo", Model = "FMX", WheelBase = "Large", Price = 10000},
                new Truck {Capacity = 3, Make = "Volvo", Model = "VHD", WheelBase = "Small", Price = 8000}
            };
            foreach (var vehicle in tempList)
            {
                Vehicles.Add(vehicle.ID, vehicle);
            }
        }

        public Task<ICollection<Vehicle>> GetVehicles()
        {
            var vehicles = Vehicles.Values as ICollection<Vehicle>;
            return Task.FromResult(vehicles);
        }

        public Task<Vehicle> GetVehicle(int id)
        {
            var vehicle = Vehicles[id];
            return Task.FromResult(vehicle);
        }

        public Task AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle.ID, vehicle);

            //.NET 4.6 and above
            //return Task.CompletedTask;

            //Below .NET 4.6
            return Task.FromResult(true);
        }

        public Task UpdateVehicle(Vehicle vehicle)
        {
            Vehicles[vehicle.ID] = vehicle;

            //.NET 4.6 and above
            //return Task.CompletedTask;

            //Below .NET 4.6
            return Task.FromResult(true);
        }

        public Task DeleteVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle.ID);

            //.NET 4.6 and above
            //return Task.CompletedTask;

            //Below .NET 4.6
            return Task.FromResult(true);
        }
    }
}