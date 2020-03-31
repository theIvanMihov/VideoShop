using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Genres
    {
        private int genreID;
        private string genreName;

        //Constructor
        public Genres() { }
        public Genres(string genre)
        {
            genreName = genre;
        }
        public Genres(int id, string genre) 
        {
            genreID = id;
            genreName = genre;
        }

        //setters
        public void setGenreID(int id)
        {
            genreID = id;
        }
        public void setGenreName(string name)
        {
            genreName = name;
        }

        //getters
        public int getGenreID()
        {
            return genreID;
        }
        public string getGenreName()
        {
            return genreName;
        }
        
    }
}
