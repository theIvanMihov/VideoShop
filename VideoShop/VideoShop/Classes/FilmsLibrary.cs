using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class FilmsLibrary
    {
        private int filmID;
        private int userID;
        
        public FilmsLibrary()
        {

        }
        public FilmsLibrary(int film, int user)
        {
            filmID = film;
            userID = user;
        }

        //setters
        public void setFilmID(int film)
        {
            filmID = film;
        }
        public void setUserID(int user)
        {
            userID = user;
        }

        //getters
        public int getFilmID()
        {
            return filmID;
        }
        public int getUserID()
        {
            return userID;
        }
    }
}
