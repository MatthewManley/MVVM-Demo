using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IVehicleRepository
    {
        /// <summary>
        /// Gets all Vehicles
        /// </summary>
        /// <returns>Collection of all Vehicles</returns>
        Task<ICollection<Vehicle>> GetVehicles();

        /// <summary>
        /// Gets a Vehicle
        /// </summary>
        /// <param name="id">Id of the Vehicle to get</param>
        /// <returns>Requested Vehicle</returns>
        Task<Vehicle> GetVehicle(int id);
        
        /// <summary>
        /// Adds a new vehicle
        /// </summary>
        /// <param name="vehicle">The vehicle to add</param>
        Task AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Updates existing vehicle
        /// </summary>
        /// <param name="vehicle">Updated Vehicle</param>
        Task UpdateVehicle(Vehicle vehicle);

        /// <summary>
        /// Deletes a Vehicle
        /// </summary>
        /// <param name="vehicle">The Vehicle to delete</param>
        Task DeleteVehicle(Vehicle vehicle);

        /// <summary>
        /// Deletes a Vehicle
        /// </summary>
        /// <param name="id">Id of the Vehicle to delete</param>
        Task DeleteVehicle(int id);
    }
}