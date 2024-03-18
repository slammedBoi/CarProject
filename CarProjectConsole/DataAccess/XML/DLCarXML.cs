using CarProjectConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CarProjectConsole.DataAccess.XML
{
    public class DLCarXML
    {
        private string _fileLoc { get; set; }

        public List<Car> CarList { get; set; }

        public DLCarXML()
        {
            CarList = new List<Car>();
            _fileLoc = "C:\\Users\\sean_\\source\\repos\\CarProject\\CarProjectConsole\\DataAccess\\XML\\CarXML.xml";
            getXMLList();
        }

        public void SaveChanges(Car car)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            StreamWriter writer = new StreamWriter(_fileLoc);

            serializer.Serialize(writer, car);
            writer.Close();
            //throw new NotImplementedException();
        }

        private void getXMLList()
        {
            XmlReader reader = XmlReader.Create(_fileLoc);
            reader.MoveToContent();

            //while reader read returns true that there is data on current line?
            while(reader.Read()) 
            {
                if(reader.IsStartElement())
                {
                    Car car = new Car();    
                    if (reader.Name.ToString().Equals("Id"))
                    {
                        car.Id = Convert.ToInt32(reader.ReadElementContentAsString());//Convert.ToInt32(reader.Value.ToString());
                    }
                    else if (reader.Name.ToString().Equals("Year"))
                    {
                        car.Year = Convert.ToInt32(reader.ReadElementContentAsString());
                    }
                    else if (reader.Name.ToString().Equals("Make"))
                    {
                        car.Make = reader.ReadElementContentAsString();
                    }
                    else if (reader.Name.ToString().Equals("Model"))
                    {
                        car.Model = reader.ReadElementContentAsString();
                    }
                    CarList.Add(car); 
                }
            }

            reader.Close();
        }
    }
}
