using CarProjectConsole.Buisness;
using CarProjectConsole.DataAccess.Text;
using CarProjectConsole.Model;

namespace CarProjectConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car Project Console Vers.!");
            Console.WriteLine("Would you like to view the Txt or XML file?");

            string? type = Console.ReadLine();  

            if(type.ToLower().Equals("txt"))
            {
                DLCarText dLCarText = new DLCarText();

                ICarBusiness carTxt = new BusinessTxt(dLCarText);
                List<Car> carList = carTxt.GetCars();

                foreach(Car car in carList)
                {
                    Console.WriteLine(car.Id + " " + car.Year + " " + car.Make + car.Model);
                }
            }
            else 
            {
                //ICarBusiness carXML = new BusinessXML();
            }
        }
    }
}