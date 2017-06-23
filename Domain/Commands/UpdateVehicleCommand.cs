using Domain.Models;
using Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Commands
{
    class UpdateVehicleCommand : ICommand
    {
        private readonly IVehicleRepository _vehicleRepository;
        private Vehicle _oldVehicle;
        private readonly Vehicle _newVehicle;

        public UpdateVehicleCommand(IVehicleRepository vehicleRepository, Vehicle oldVehicle, Vehicle newVehicle)
        {
            _vehicleRepository = vehicleRepository;
            _oldVehicle = oldVehicle;
            _newVehicle = newVehicle;
        }

        public UpdateVehicleCommand(IVehicleRepository vehicleRepository, Vehicle newVehicle)
        {
            _vehicleRepository = vehicleRepository;
            _newVehicle = newVehicle;
        }

        public async Task Do()
        {
            if (_oldVehicle == null)
                _oldVehicle = await _vehicleRepository.GetVehicle(_newVehicle.Id);

            await _vehicleRepository.UpdateVehicle(_newVehicle);
        }

        public async Task Undo()
        {
            if (_oldVehicle == null)
            {
                //TODO: Create custom exception
                throw new Exception();
            }
            await _vehicleRepository.UpdateVehicle(_oldVehicle);
        }
    }
}
