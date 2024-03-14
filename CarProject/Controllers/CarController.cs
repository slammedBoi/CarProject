using CarProject.Database;
using CarProject.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class TestObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CarController : Controller
    {
        CarContext carContext = new CarContext();
        CarSave carSave = new CarSave();
        public int listSize { get; set; }

        public IActionResult CarDisplay()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewCar(Car carObj)
        {          
            carContext.CarsSet.Add(carObj);
            carSave.SaveCarText(carObj);


            return Json(new { });
        }

        //[HttpGet]
        public IActionResult GetCarList()//Car car)
        {
            List<Car> carList = new List<Car>();
            carList = carSave.GetCarList();

            return Json(new { carList });
        }

        [HttpGet]
        public IActionResult testFunction(string testString2)
        {
            return Json(new {testString2});
        }

        [HttpGet]
        public IActionResult testFunctionEx(TestObj testx)
        {
            string result = $"{testx.Id}, {testx.Name}";
            return Json(new { result });
        }
    }
}
