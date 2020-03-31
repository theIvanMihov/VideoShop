using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class StaffPositions
    {
        private int posID;
        private string positionName;

        //Constructors
        public StaffPositions() { }
        public StaffPositions(int id, string name)
        {
            posID = id;
            positionName = name;
        }

        //Setters
        public void setPosID(int id)
        {
            posID = id;
        }
        public void setPosName(String name)
        {
            positionName = name;
        }

        //Getters
        public int getPosID()
        {
            return posID;
        }
        public string getPosName()
        {
            return positionName;
        }
    }
}
