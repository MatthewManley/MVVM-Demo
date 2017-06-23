using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException()
        {
        }
        
        /// <param name="id">The provided id of vehicle to find</param>
        public VehicleNotFoundException(int id) : base($"Vehicle with Id {id} not found!")
        {
        }

        /// <param name="id">The provided id of vehicle to find</param>
        /// <param name="innerException">Inner Exception</param>
        public VehicleNotFoundException(int id, Exception innerException) : base($"Vehicle with Id {id} not found!", innerException)
        {
        }
    }
}
