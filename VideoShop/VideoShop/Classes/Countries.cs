using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Countries
    {
        private int countryID;
        private string countryName;

        //constructors
        private Countries() { }
        public Countries(string name)
        {
            countryName = name;
        }
        public Countries(int id, string name)
        {
            countryID = id;
            countryName = name;
        }

        //setters
        public void setCountry(string name)
        {
            countryName = name;
        }
        public  void setCountryID(int id)
        {
            countryID = id;
        }

        //getters
        public string getCountry()
        {
            return countryName;
        }
        public int getCountryID()
        {
            return countryID;
        }
    }
}
