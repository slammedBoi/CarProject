using CarProjectConsole.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProjectConsole.DataAccess.Text
{
    public class DLCarText
    {
        private string _fileLoc {  get; set; }

        public List<Car> CarList { get; set; }

        public DLCarText() 
        {
            CarList = new List<Car>();
            _fileLoc = "C:\\Users\\sean_\\source\\repos\\CarProject\\CarProjectConsole\\DataAccess\\Text\\CarText.txt";
            getTxtList();
        }

        public void SaveChanges(Car car)
        {
            string carTemp = (car.Id).ToString() + " ";
            carTemp += (car.Year).ToString() + " ";
            carTemp += car.Make + " ";
            carTemp += car.Model;

            File.AppendAllText(_fileLoc, carTemp + Environment.NewLine);
        }

        private void getTxtList()
        {
            StreamReader reader = new StreamReader(_fileLoc);
            string textLine;

            while ((textLine = reader.ReadLine()) != null)
            {
                Car addCar = new Car();
                int counter = 0;
                string prop = "";
                for (int i = 0; i < textLine.Length; i++)
                {
                    if (textLine.Substring(i, 1).Equals(" ") && counter <= 2)
                    {
                        if (counter == 0)
                        {
                            addCar.Id = Convert.ToInt32(prop);
                            prop = "";
                        }
                        else if (counter == 1)
                        {
                            addCar.Year = Convert.ToInt32(prop);
                            prop = "";
                        }
                        else if (counter == 2)
                        {
                            addCar.Make = prop;
                            prop = "";
                        }
                        counter += 1;
                    }
                    else
                    {
                        prop += textLine.Substring(i, 1);
                    }
                    addCar.Model = prop;
                }
                CarList.Add(addCar);
            }

            reader.Close();
        }
    }
}
