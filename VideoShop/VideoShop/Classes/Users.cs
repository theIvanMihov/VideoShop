using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Users
    {
        private int userID;
        private string userName;
        private string userPass;
        private string userEmail;
        private int userCountryID;

        //Constructors
        public Users()
        {

        }
        public Users(int id, string name, string pass, string email, int countryID)
        {
            userID = id;
            userName = name;
            userPass = pass;
            userEmail = email;
            userCountryID = countryID;
        }

        //Setters
        public void setUserID(int id)
        {
            userID = id;
        }
        public void setUserDetails(Users u)
        {
            userID = u.getUserID();
            userName = u.getUserName();
            userPass = u.getUserName();
            userEmail = u.getEmail();
            userCountryID = u.getCountryID();
        }
        public void setUserName(string name)
        {
            userName = name;
        }
        public void setPassword(string pass)
        {
            userPass = pass;
        }
        public void setEmail(string email)
        {
            userEmail = email;
        }
        public void setCountry(int id)
        {
            userCountryID = id;
        }

        //Getters
        public int getUserID()
        {
            return userID;
        }
        public string getUserName()
        {
            return userName;
        }
        public string getPass()
        {
            return userPass;
        }
        public string getEmail()
        {
            return userEmail;
        }
        public int getCountryID()
        {
            return userCountryID;
        }
    }
}
