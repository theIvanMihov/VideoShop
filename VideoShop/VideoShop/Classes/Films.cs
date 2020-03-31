using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Films
    {
        private int filmID;
        private string filmProducer;
        private string filmLeading;
        private string filmName;
        private int genreId;
        private int filmYear;
        private string genre;
        //constructors
        public Films() { }
        public Films(string prod, string lead, string name, int genre, int year) 
        {
            filmProducer = prod;
            filmLeading = lead;
            filmName = name;
            genreId = genre;
            filmYear = year;
        }
        public Films(int id, string prod, string lead, string name, int genre, int year)
        {
            filmID = id;
            filmProducer = prod;
            filmLeading = lead;
            filmName = name;
            genreId = genre;
            filmYear = year;
        }

        //setters
        public void setID(int id)
        {
            filmID = id;
        }
        public void setProd(string prod)
        {
            filmProducer = prod;
        }
        public void setLead(string lead)
        {
            filmLeading = lead;
        }
        public void setName(string name)
        {
            filmName = name;
        }
        public void setGenre(int genre)
        {
            genreId = genre;
        }
        public void setYear(int year)
        {
            filmYear = year;
        }
        public void setStringGenre(string g)
        {
            genre = g;
        }
        public void setFilmSettings(Films f)
        {
            filmProducer = f.getProducer();
            filmLeading = f.getLeading();
            filmName = f.getName();
            genreId = f.getGenre();
            filmYear = f.getYear();
        }
        
        //getters
        public string getProducer()
        {
            return filmProducer;
        }
        public string getLeading()
        {
            return filmLeading;
        }
        public string getName()
        {
            return filmName;
        }
        public int getGenre()
        {
            return genreId;
        }
        public int getYear()
        {
            return filmYear;
        }
        public int getID()
        {
            return filmID;
        }
        public string getStringGenre()
        {
            return genre;
        }


        public string[] getStringArray()
        {
            return new string[] { filmProducer, filmLeading, filmName, genre, filmYear.ToString() };
        }
    }
}
