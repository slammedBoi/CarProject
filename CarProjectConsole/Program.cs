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
            BusinessTxt choiceTxt = new BusinessTxt(new DLCarText());
            BusinessXML choiceXML = new BusinessXML(new DLCarXML());
            ICarBusiness choice;

            Console.WriteLine("Welcome to the Car Project Console Vers.!");
            Console.WriteLine("Would you like to view the Txt or XML file?");

            string? type = Console.ReadLine();
            string? response = "";

            List<Car> carList = new List<Car>();
            while (type != "") 
            {
                if(type.Equals(""))
                {
                    break;
                }
                else if (type.ToLower().Equals("txt"))
                {
                    choice = choiceTxt;
                    carList = choice.GetCars();

                    foreach (Car car in carList)
                    {
                        Console.WriteLine(car.Id + " " + car.Year + " " + car.Make + " " + car.Model);
                    }

                    Console.WriteLine("Would you like to add a car? Enter y/n");
                    response = Console.ReadLine(); 

                    if(response.ToLower().Equals("y"))
                    {
                        Console.WriteLine("Enter the Year-Make-Model of your car, seperating with a space inbetween");
                        string? carDescr = Console.ReadLine();

                        Car addCar = choice.NewCar(carDescr);
                        choice.Add(addCar);
                    }
                    else
                    {
                        Console.WriteLine("No car to add? No problem!");
                    }

                }
                else if (type.ToLower().Equals("xml"))
                {
                    choice = choiceXML;
                    carList = choice.GetCars();

                    foreach (Car car in carList)
                    {
                        Console.WriteLine(car.Id + car.Year + car.Make + car.Model);
                    }

                    Console.WriteLine("Would you like to add a car? Enter y/n");
                    response = Console.ReadLine();

                    if (response.ToLower().Equals("y"))
                    {
                        Console.WriteLine("Enter the Year-Make-Model of your car, seperating with a space inbetween");
                        string? carDescr = Console.ReadLine();

                        Car addCar = choice.NewCar(carDescr);
                        choice.Add(addCar);
                    }
                    else
                    {
                        Console.WriteLine("No car to add? No problem!");
                    }
                }

                Console.WriteLine("Would you like to view the Txt or XML file? Or press ENTER to quit.");
                type = Console.ReadLine();
            }
        }

        //public static Car NewCar()
        //{
        //    Console.WriteLine("Enter the Year-Make-Model of your car, seperating with a space inbetween");
        //    string ?carDescr = Console.ReadLine();

        //    string[] carSplit = carDescr.Split(" ");
        //    Car returnCar = new Car
        //    {
        //        Id = 0,
        //        Year = Convert.ToInt32(carSplit[0]),
        //        Make = carSplit[1],
        //        Model = carSplit[2]
        //    };
            
        //    return returnCar;
        //}
    }
}