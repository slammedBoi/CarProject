using CarProject.Models;

namespace CarProject.Database
{
    public interface IAutoContext
    {
        List<Car> carList { get; set; }
        public void SaveChanges(Car car);
    }
}
