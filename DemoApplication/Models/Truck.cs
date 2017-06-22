using DemoApplication.Repositories;

namespace DemoApplication.Models
{
    public class Truck : Vehicle
    {
        public string WheelBase { get; set; }

        //public Truck() : base(null, "Truck") { } // required empty constructor for sqlite
        //public Truck(IVehicleRepository repository) : base(repository, "Truck") { }
    }
}