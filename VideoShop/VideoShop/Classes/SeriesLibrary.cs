using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class SeriesLibrary
    {
        private int seriesID;
        private int userID;

        public SeriesLibrary()
        {
        }
        public SeriesLibrary(int series, int user)
        {
            seriesID = series;
            userID = user;
        }

        //setters
        public void setSeries(int series)
        {
            seriesID = series;
        }
        public void setUser(int user)
        {
            userID = user;
        }

        //getters
        public int getSeries()
        {
            return seriesID;
        }
        public int getUser()
        {
            return userID;
        }
    }
}
