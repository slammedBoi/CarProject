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
            //_DLCarTxt = new DLCarText();    
            _DLCarTxt = carTxt;
        }

        public void Add(Car inpCar)
        {
            _DLCarTxt.CarList.Add(inpCar);
            _DLCarTxt.SaveChanges(inpCar);
        }

        public List<Car> GetCars()
        {
            return _DLCarTxt.CarList;
        }
    }
}
