using CarProjectConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProjectConsole.Buisness
{
    internal interface ICarBusiness
    {
        public void Add(Car inpCar);
        public List<Car> GetCars();
    }
}
