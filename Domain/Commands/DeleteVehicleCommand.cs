using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Commands
{
    class DeleteVehicleCommand : ICommand
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly int? _id;
        private Vehicle _vehicle;

        public DeleteVehicleCommand(IVehicleRepository vehicleRepository, Vehicle vehicle)
        {
            _vehicleRepository = vehicleRepository;
            _vehicle = vehicle;
        }

        public DeleteVehicleCommand(IVehicleRepository vehicleRepository, int id)
        {
            _vehicleRepository = vehicleRepository;
            _id = id;
        }

        public async Task Do()
        {
            if (_vehicle != null)
            {
                await _vehicleRepository.DeleteVehicle(_vehicle);
            }
            else if (_id != null)
            {
                _vehicle = await _vehicleRepository.GetVehicle(_id.Value);
                await _vehicleRepository.DeleteVehicle(_id.Value);
            }
            else
            {
                //TODO: Create custom exception
                throw new Exception();
            }
        }

        public async Task Undo()
        {
            await _vehicleRepository.AddVehicle(_vehicle);
        }
    }
}
