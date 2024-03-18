using CarProjectConsole.DataAccess.Text;
using CarProjectConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProjectConsole.Buisness
{
    public class BusinessTxt : ICarBusiness
    {
        private DLCarText _DLCarTxt {  get; set; }
        
        public BusinessTxt(DLCarText carTxt)
        {  
            _DLCarTxt = carTxt;
        }

        public Car NewCar(string parameters)
        {
            string[] carSplit = parameters.Split(" ");
            Car returnCar = new Car
            {
                Id = 0,
                Year = Convert.ToInt32(carSplit[0]),
                Make = carSplit[1],
                Model = carSplit[2]
            };

            return returnCar;
        }

        public void Add(Car inpCar)
        {
            inpCar.Id = (_DLCarTxt.CarList.Count) + 1;

            _DLCarTxt.CarList.Add(inpCar);
            _DLCarTxt.SaveChanges(inpCar);
        }

        public List<Car> GetCars()
        {
            return _DLCarTxt.CarList;
        }
    }
}
