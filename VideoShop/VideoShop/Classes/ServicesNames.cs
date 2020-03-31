using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class ServicesNames
    {
        private int servID;
        private string servName;
        private double servPrice = 0;

        //Constructors
        public ServicesNames(string name, float price) {
            servName = name;
            servPrice = price;
        }
        public ServicesNames(int id, string name, double price)
        {
            servID = id;
            servName = name;
            servPrice = price;
        }

        //Setters
        public void setServID(int id)
        {
            servID = id;
        }
        public void setServName(string name)
        {
            servName = name;
        }
        public void setServPrice(double price)
        {
            servPrice = price;
        }

        //Getters
        public int getServID()
        {
            return servID;
        }
        public string getServName()
        {
            return servName;
        }
        public double getServPrice()
        {
            return servPrice;
        }
    }
}
