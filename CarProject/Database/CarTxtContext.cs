using CarProject.Models;

namespace CarProject.Database
{
    public class CarTxtContext : IAutoContext
    {
        private string _fileLoc { get; set; }

        public List<Car> carList { get; set; }
        public CarTxtContext() 
        {
            _fileLoc = "C:\\Users\\sean_\\source\\repos\\CarProject\\CarProject\\Database\\CarDB.txt";
            GetItems();   
        }

        public void SaveChanges(Car car)
        {
            string carTemp = (car.Id).ToString() + " ";
            carTemp += (car.Year).ToString() + " ";
            carTemp += car.Make + " ";
            carTemp += car.Model;

            File.AppendAllText(_fileLoc, carTemp + Environment.NewLine);
        }

        private void GetItems()
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
                carList.Add(addCar);
            }

            reader.Close();
            //listSize = carList.Count;
        }
    }
}
