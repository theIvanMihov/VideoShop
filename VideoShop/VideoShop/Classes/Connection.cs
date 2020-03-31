using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{    
    class Connection
    {
        private string connString = "Data Source=DESKTOP-U6A27FU\\IVANSQL; Initial Catalog=VideoShop; MultipleActiveResultSets=true; User ID=sa; Password=123456";
        private static Connection _instance = null;
        private static readonly object _syncObject = new object();
        private SqlConnection conn;

        private Connection()
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }
        public static Connection Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_syncObject)
                    {
                        if(_instance == null)
                        {
                            _instance = new Connection();
                        }
                    }
                }
                return _instance;
            }
        }
        public SqlConnection returnConnection()
        {
            return conn;
        }
    }
}
