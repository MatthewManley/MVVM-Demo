using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Commands;
using Domain.Repositories;

namespace Domain
{
    public class VehicleService : IVehicleService
    {
        private readonly ICommandService _commandService;
        private readonly IVehicleRepository _vehicleRepository;

        //TODO: Should find a way to not have to pass the vehicleRepository into the commands
        public VehicleService(ICommandService commandService, IVehicleRepository vehicleRepository)
        {
            _commandService = commandService;
            _vehicleRepository = vehicleRepository;
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            var addVehcileCommand = new AddVehicleCommand(_vehicleRepository, vehicle);
            await _commandService.ExecuteCommand(addVehcileCommand);
        }

        public async Task DeleteVehicle(Vehicle vehicle)
        {
            var deleteVehcileCOmmand = new DeleteVehicleCommand(_vehicleRepository, vehicle);
            await _commandService.ExecuteCommand(deleteVehcileCOmmand);
        }

        public async Task DeleteVehicle(int id)
        { 
            var deleteVehicleCommand = new DeleteVehicleCommand(_vehicleRepository, id);
            await _commandService.ExecuteCommand(deleteVehicleCommand);
        }

        public async Task UpdateVehcile(Vehicle vehicle)
        {
            var updateVehicleCommand = new UpdateVehicleCommand(_vehicleRepository, vehicle);
            await _commandService.ExecuteCommand(updateVehicleCommand);
        }

        public async Task UpdateVehcile(Vehicle oldVehicle, Vehicle newVehicle)
        {
            var updateVehicleCommand = new UpdateVehicleCommand(_vehicleRepository, oldVehicle, newVehicle);
            await _commandService.ExecuteCommand(updateVehicleCommand);
        }
    }
}
