using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Commands
{
    class AddVehicleCommand : ICommand
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly Vehicle _vehicle;

        public AddVehicleCommand(IVehicleRepository vehicleRepository, Vehicle vehicle)
        {
            _vehicleRepository = vehicleRepository;
            _vehicle = vehicle;
        }

        public async Task Do()
        {
            await _vehicleRepository.AddVehicle(_vehicle);
        }

        public async Task Undo()
        {
            await _vehicleRepository.DeleteVehicle(_vehicle);
        }
    }
}
