namespace Domain.Models
{
    public class Car : Vehicle
    {
        /// <summary>
        /// How fast the Vehicle can travel
        /// </summary>
        public decimal TopSpeed { get; set; }
    }
}