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
        private DLCarXML _DLCarXML {  get; set; } 

        public BusinessXML(DLCarXML carXML) 
        {
            _DLCarXML = carXML;
        }

        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCars() 
        {
            return _DLCarXML.CarList;
        }
    }
}
