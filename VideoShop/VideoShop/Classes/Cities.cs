using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Cities
    {
        private int cityID = 0;
        private string cityName = "";

        //constructors 
        public Cities()
        {

        }
        public Cities(int id, string city)
        {
            cityID = id;
            cityName = city;
        }
        public Cities(string city)
        {
            this.cityName = city;
        }

        //setting data 
        public void setCity(string city)
        {
            this.cityName = city;
        }
        public void setID(int id)
        {
            this.cityID = id;
        }

        //getting data 
        public string getCity()
        {
            return cityName;
        }
        public int getId()
        {
            return cityID;
        }

        public string[] getCitiesArray()
        {
            return new string[] { cityName };
        }
    }
}
