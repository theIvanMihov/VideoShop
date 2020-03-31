using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Positions
    {
        private int posID;
        private string posName;

        public Positions()
        {

        }
        public Positions(int id, string name)
        {
            posID = id;
            posName = name;
        }
        public Positions( string name)
        {
            posName = name;
        }

        //setters
        public void setID(int id)
        {
            posID = id;
        }
        public void setPosName(string name)
        {
            posName = name;
        }

        //getters
        public int getID()
        {
            return posID;
        }
        public string getPosName()
        {
            return posName;
        }
    }
}
