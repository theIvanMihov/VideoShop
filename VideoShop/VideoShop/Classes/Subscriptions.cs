using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Subscriptions
    {
        private int subID;
        private int userID;
        private int servID;
        private DateTime startDate;
        private DateTime endDate;

        public Subscriptions()
        {

        }
        public Subscriptions(int user, int service, DateTime start, DateTime end)
        {
            userID = user;
            servID = service;
            startDate = start;
            endDate = end;
        }
        public Subscriptions(int id, int user, int service, DateTime start, DateTime end)
        {
            subID = id;
            userID = user;
            servID = service;
            startDate = start;
            endDate = end;
        }

        //setters
        public void setSubID(int id)
        {
            subID = id;
        }        
        public void setEndDate(DateTime end)
        {
            endDate = end;
        }

        //getters
        public int getSubID()
        {
            return subID;
        }
        public int getUserID()
        {
            return userID;
        }
        public int getServID()
        {
            return servID;
        }
        public DateTime getStartDate()
        {
            return startDate;
        }
        public DateTime getEndDate()
        {
            return endDate;
        }

    }
}
