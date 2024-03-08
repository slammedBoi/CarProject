using CarProject.Database;
using CarProject.Models;

namespace CarProject.Repository
{
    public class AutoRepository
    {
        public IAutoContext carContext { get; set; }

        public AutoRepository(IAutoContext context)
        {
            carContext = context;
        }

        public void AddAutomobile(int autoId, int autoYear, string autoMake, string autoModel, string type)
        {
            if(type.ToLower().Equals("car"))
            {
                Car carObj = new Car
                {
                    Id = autoId,
                    Year = autoYear,
                    Make = autoMake,
                    Model = autoModel
                };

                carContext.carList.Add(carObj);
                carContext.SaveChanges(carObj);
            }
        }
    }
}
