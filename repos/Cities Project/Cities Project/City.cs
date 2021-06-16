using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities_Project
{
    class City
    {
        private static int ID_Counter = 0;
        private string name { get; set; }

        private List<Street> streetsList;
        private int ID { get; set; } 
        public City(string cityName)
        {
            name = cityName;
            ID = System.Threading.Interlocked.Increment(ref ID_Counter);
            ID_Counter++;
            streetsList = new List<Street>();
        }

        public string getCityName()
        {
            return this.name;
        }

        public void setCityName(string cityName)
        {
            this.name = cityName;
        }

        public int getCityId()
        {
            return this.ID;
        }

        public void setCityId(int cityId)
        {
            this.ID = cityId;
        }

        public void addStreet(Street street)
        {
            this.streetsList.Add(street);
        }
    }
}
