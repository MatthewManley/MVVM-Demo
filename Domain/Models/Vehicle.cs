//using SQLite;

namespace Domain.Models
{
    public abstract class Vehicle
    {
        // You don't really want database stuff in the domain
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Make { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        /// <summary>
        /// Price in cents
        /// </summary>
        public int Price { get; set; }
        
        
        public override bool Equals(object obj) => (obj as Vehicle)?.Id == Id;

        //Probably not the best way to generate hash codes but this will do for now
        //TODO: Hash code should be calcualted by read only properties
        public override int GetHashCode() => Id;
    }
}
