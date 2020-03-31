using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Types
    {
        private int typeID;
        private string typeName;

        //Constructors
        public Types() { }
        public Types(int id, string name)
        {
            typeID = id;
            typeName = name;
        }

        //Setters
        public void setID(int id)
        {
            typeID = id;
        }
        public void setType(string name)
        {
            typeName = name;
        }

        //Getters
        public int getID()
        {
            return typeID;
        }
        public string getType()
        {
            return typeName;
        }
    }
}
