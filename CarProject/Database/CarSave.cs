using CarProject.Models;

namespace CarProject.Database
{
    public class CarSave
    {
        public int listSize { get; set; }
        public void SaveCarText(Car saveCar)
        {
            string fileLoc = "C:\\Users\\sean_\\source\\repos\\CarProject\\CarProject\\Database\\CarDB.txt";

            string carTemp = (saveCar.Id).ToString() + " ";
            carTemp += (saveCar.Year).ToString() + " ";
            carTemp += saveCar.Make + " ";
            carTemp += saveCar.Model;

            File.AppendAllText(fileLoc, carTemp + Environment.NewLine);
        }

        public List<Car> GetCarList()
        {
            string fileLoc = "C:\\Users\\sean_\\source\\repos\\CarProject\\CarProject\\Database\\CarDB.txt";
            StreamReader reader = new StreamReader(fileLoc);
            string textLine;

            List<Car> carList = new List<Car>();

            while((textLine = reader.ReadLine()) != null)
            {
                Car addCar = new Car();
                int counter = 0;
                string prop = "";
                for (int i = 0; i < textLine.Length; i++)
                {
                    if(textLine.Substring(i,1).Equals(" ") && counter <= 2)
                    {
                        if(counter == 0)
                        {
                            addCar.Id= Convert.ToInt32(prop);
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
                        //else if (counter == 3)
                        //{
                        //    addCar.Model = prop;
                        //    prop = "";
                        //}
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
            listSize = carList.Count;
            return carList;
        }

        public bool checkFileEmpty()
        {
            FileInfo checkFile = new FileInfo("C:\\Users\\sean_\\source\\repos\\CarProject\\CarProject\\Database\\CarDB.txt");
            if (checkFile.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
