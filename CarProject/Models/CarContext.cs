using CarProject.Database;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Models
{
    public class CarContext //: DbContext
    {
        CarSave testSave = new CarSave();
        public List<Car> CarsSet { get; set; } = new List<Car>();

        public CarContext()//DbContextOptions<CarContext> options) : base(options)
        {
            CarsSet.Add(
                new Car
                {
                    carId = 1,
                    Make = "Mazda",
                    Model = "RX7",
                    Year = 1999
                });
            CarsSet.Add(
                new Car
                {
                    carId = 2,
                    Make = "Nissan",
                    Model = "Skyline",
                    Year = 2002
                });

            if(testSave.checkFileEmpty() == true )
            {
                testSave.SaveCarText(CarsSet[0]);
                testSave.SaveCarText(CarsSet[1]);
            }
        }
    }
}
