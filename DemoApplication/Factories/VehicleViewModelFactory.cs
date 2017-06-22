using System;
using System.Reflection;
using DemoApplication.Models;
using DemoApplication.Repositories;
using DemoApplication.ViewModels;
using log4net;

namespace DemoApplication.Factories
{
    public class VehicleViewModelFactory
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILog _log;

        public VehicleViewModelFactory(IVehicleRepository vehicleRepository, ILog log)
        {
            _vehicleRepository = vehicleRepository;
            _log = log;
        }

        public VehicleViewModel Create(Vehicle v)
        {

            if (v is Car)
                return new CarViewModel(_log, (Car) v);

            if (v is Truck)
                return new TruckViewModel(_log, (Truck) v);

            throw new ArgumentException($"Vehicle is not valid type; \'{v.GetType()}\'.");
        }
        
        public VehicleViewModel Create(string type)
        {
            var model = Reflect<Vehicle>(type);
            return Create(model);
        }

        private T Reflect<T>(string type)
        {
            // I wouldn't normally use reflection because it is slow; this is just a play with Activator.
            var nameSpace = Assembly.GetExecutingAssembly().GetName().Name;
            return (T)Activator.CreateInstance(Type.GetType($"{nameSpace}.Models.{type}"));
            //return (T)Activator.CreateInstance(nameSpace, $"{nameSpace}.Models.{type}", false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, new object[] { _vehicleRepository }, null, null).Unwrap();
        }
    }
}