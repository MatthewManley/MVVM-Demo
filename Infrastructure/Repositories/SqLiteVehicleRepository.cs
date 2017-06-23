﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class SqLiteVehicleRepository : IVehicleRepository
    {
        private SQLiteAsyncConnection _db;
        private readonly ILog _log;

        public SqLiteVehicleRepository(ILog log)
        {
            _log = log;
            _log.Info("Creating new SqLiteVehicleRepository.");
        }

        public async Task<ICollection<Vehicle>> GetVehicles()
        {
            await CheckAndCreateDatabase();
            await PopulateIfEmpty();

            var vehicles = new List<Vehicle>();
            vehicles.AddRange(await _db.Table<Car>().ToListAsync());
            vehicles.AddRange(await _db.Table<Truck>().ToListAsync());

            _log.Info($"Loaded {vehicles.Count} vehicles from database.");
            return vehicles;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            Vehicle vehicle = (await _db.Table<Car>().Where(x => x.Id == id).ToListAsync()).FirstOrDefault();
            if (vehicle != null)
                return vehicle;

            vehicle = (await _db.Table<Truck>().Where(x => x.Id == id).ToListAsync()).FirstOrDefault();
            if (vehicle != null)
                return vehicle;

            //Throw exception or return null
            return null;
        }

        public Task AddVehicle(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateVehicle(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteVehicle(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        private async Task CheckAndCreateDatabase()
        {
            var dir = Path.Combine(Path.GetTempPath(), "Vehicles");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            _db = new SQLiteAsyncConnection(Path.Combine(dir, "VehiclesDB.sqlite"));

            await _db.CreateTableAsync<Truck>();
            await _db.CreateTableAsync<Car>();
        }

        private async Task PopulateIfEmpty()
        {
            var counter = await _db.ExecuteScalarAsync<int>("SELECT COUNT(*) As Result FROM Car");

            if (counter == 0)
            {
                _log.Info("No database exists; creating database with sample data...");

                await _db.InsertAsync(new Car   { Capacity = 5, Make = "Fiat"   , Model = "Punto"     , TopSpeed  = 70     , Price = 1000  });
                await _db.InsertAsync(new Car   { Capacity = 4, Make = "Renault", Model = "Megane"    , TopSpeed  = 80     , Price = 2000  });
                await _db.InsertAsync(new Car   { Capacity = 5, Make = "Ford"   , Model = "Fiesta"    , TopSpeed  = 90     , Price = 1500  });
                await _db.InsertAsync(new Truck { Capacity = 3, Make = "Volvo"  , Model = "FMX"       , WheelBase = "Large", Price = 10000 });
                await _db.InsertAsync(new Truck { Capacity = 3, Make = "Volvo"  , Model = "VHD"       , WheelBase = "Small", Price = 8000  });
            }
        }

        public async Task SaveVehicle(Vehicle vehicle)
        {
            await _db.InsertOrReplaceAsync(vehicle);
        }
    }
}
