using DemoApplication.Repositories;
using SQLite;

namespace DemoApplication.Models
{
    public abstract class Vehicle
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public string Make { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        /// <summary>
        /// Price in cents
        /// </summary>
        public int Price { get; set; }
        
        //I prefer the car object not knowing how its saved
        //public async Task Save()
        //{
        //    await _repository.SaveVehicle(this);
        //}

        //internal void SetRepository(IVehicleRepository repository)
        //{
        //    _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        //}

        //This is something that you should have
        public override bool Equals(object obj) => (obj as Vehicle)?.ID == ID;

        //Probably not the best way to generate hash codes but this will do
        //TODO: Hash code should be calcualted by read only properties
        public override int GetHashCode() => ID;
    }
}
