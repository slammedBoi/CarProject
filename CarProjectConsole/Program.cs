using CarProjectConsole.Buisness;
using CarProjectConsole.DataAccess.Text;
using CarProjectConsole.DataAccess.XML;
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

            List<Car> carList = new List<Car>();
            while (type != "") 
            {
                if(type.Equals(""))
                {
                    break;
                }
                else if (type.ToLower().Equals("txt"))
                {
                    DLCarText dLCarText = new DLCarText();

                    ICarBusiness carTxt = new BusinessTxt(dLCarText);
                    carList = carTxt.GetCars();

                    foreach (Car car in carList)
                    {
                        Console.WriteLine(car.Id + " " + car.Year + " " + car.Make + car.Model);
                    }
                }
                else if (type.ToLower().Equals("xml"))
                {
                    DLCarXML dLCarXML = new DLCarXML();

                    ICarBusiness carXML = new BusinessXML(dLCarXML);
                    carList = carXML.GetCars();

                    foreach (Car car in carList)
                    {
                        Console.WriteLine(car.Id + " " + car.Year + " " + car.Make + car.Model);
                    }
                }

                Console.WriteLine("Would you like to view the Txt or XML file? Or press ENTER to quit.");
                type = Console.ReadLine();
            }
        }
    }
}