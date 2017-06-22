using DemoApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Repositories
{
    public class TestVehicleRepository : IVehicleRepository
    {
        private Dictionary<int, Vehicle> Vehicles { get; }

        public TestVehicleRepository()
        {
            //I am doing this for vehicle indexing, since this isn't actually a database.
            Vehicles = new Dictionary<int, Vehicle>
            {
                {0, new Car {Id = 0, Capacity = 5, Make = "Fiat", Model = "Punto", TopSpeed = 70, Price = 1000}},
                {1, new Car {Id = 1, Capacity = 4, Make = "Renault", Model = "Megane", TopSpeed = 80, Price = 2000}},
                {2,  new Car {Id = 2, Capacity = 5, Make = "Ford", Model = "Fiesta", TopSpeed = 90, Price = 1500}},
                {3, new Truck {Id = 3, Capacity = 3, Make = "Volvo", Model = "FMX", WheelBase = "Large", Price = 10000}},
                {4, new Truck {Id = 4, Capacity = 3, Make = "Volvo", Model = "VHD", WheelBase = "Small", Price = 8000} }
            };
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
            Vehicles.Add(vehicle.Id, vehicle);

            //.NET 4.6 and above
            //return Task.CompletedTask;

            //Below .NET 4.6
            return Task.FromResult(true);
        }
        
        public Task UpdateVehicle(Vehicle vehicle)
        {
            //If you want to force the vehicle to exist first
            //if (!Vehicles.ContainsKey(vehicle.ID))
            //{
                  //TODO: Should probably create custom exception
            //    throw new KeyNotFoundException();
            //}

            Vehicles[vehicle.Id] = vehicle;

            //.NET 4.6 and above
            //return Task.CompletedTask;

            //Below .NET 4.6
            return Task.FromResult(true);
        }

        public Task DeleteVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle.Id);

            //.NET 4.6 and above
            //return Task.CompletedTask;

            //Below .NET 4.6
            return Task.FromResult(true);
        }
    }
}