namespace Domain.Models
{
    public abstract class Vehicle
    {
        /// <summary>
        /// Unique Id of the Vehicle
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Make of the Vehicle
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Model of the vehicle
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Number of passengers that can fit in the vehicle
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Price in cents
        /// </summary>
        public int Price { get; set; }
        
        public override bool Equals(object obj) => (obj as Vehicle)?.Id == Id;

        public override int GetHashCode() => Id;
    }
}
