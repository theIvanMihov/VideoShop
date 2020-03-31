using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class Pepper
    {
        private static Pepper _instance = null;
        private static readonly object _syncObject = new object();

        public static Pepper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Pepper();
                        }
                    }
                }
                return _instance;
            }
        }
        public string PepperOnTheDish(string unseasonedDish)
        {
            
            using ( SHA256 pepper = SHA256.Create() ){

                byte[] pepperContainer = pepper.ComputeHash(Encoding.UTF8.GetBytes(unseasonedDish));

                StringBuilder seasonedDish = new StringBuilder();
                for (int i = 0; i < pepperContainer.Length; i++)
                {
                    seasonedDish.Append(pepperContainer[i].ToString("x2") );
                }
                return seasonedDish.ToString();
            }
        }
        public bool Authenticate(string passOne, string passTwo)
        {
            byte[] one = Encoding.ASCII.GetBytes(passOne);
            byte[] two = Encoding.ASCII.GetBytes(passTwo);

            for(int i = 0; i < two.Length; i++)
            {
                if (!one[i].Equals(two[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckForAdmin(string adminPassword)
        {
            if(adminPassword == this.PepperOnTheDish("EMP"))
            {
                return true;
            }

            return false;
        }

    }
}
