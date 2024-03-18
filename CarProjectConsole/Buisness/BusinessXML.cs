using CarProjectConsole.DataAccess.XML;
using CarProjectConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProjectConsole.Buisness
{
    public class BusinessXML : ICarBusiness
    {
        private DLCarXML _DLCarXML { get; set; } 

        public BusinessXML(DLCarXML carXML) 
        {
            _DLCarXML = carXML;
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

        public void Add(Car car)
        {
            car.Id = (_DLCarXML.CarList.Count) + 1;

            _DLCarXML.CarList.Add(car);
            _DLCarXML.SaveChanges(car);
        }

        public List<Car> GetCars() 
        {
            return _DLCarXML.CarList;
        }
    }
}
