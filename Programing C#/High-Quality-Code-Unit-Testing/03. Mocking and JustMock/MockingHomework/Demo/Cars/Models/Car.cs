namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
        
        public override bool Equals(object obj)
        {
            Car otherCar = (Car)obj;

            return this.Id == otherCar.Id && this.Make == otherCar.Make && this.Model == otherCar.Model
                    && this.Year == otherCar.Year;
        }
    }
}
