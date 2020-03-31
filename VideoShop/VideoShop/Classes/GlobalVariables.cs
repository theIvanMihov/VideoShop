using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShop.Classes
{
    class GlobalVariables
    {
        private bool isAdminLogged = false;

        /// <summary>
        /// Тeзи мапове отговаря на условието, на съответен подаден ключ тоест името на таблицата отговаря съответната процедура за
        /// вкарване на данни в базата от данни
        /// </summary>
        protected static Dictionary<string, string> insertProcedures = new Dictionary<string, string>();
        protected static Dictionary<string, string> updateProcedures = new Dictionary<string, string>();

        private static GlobalVariables _instance = null;
        private static readonly object _syncObject = new object();
        
        //to do add other global variables

        public static GlobalVariables Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new GlobalVariables();
                        }
                    }
                }
                return _instance;
            }
        }
        public GlobalVariables()
        {
            loadInsertProcedures();
            loadUpdateProcedures();
        }
        //setters
        public void setAdminLogged(bool set)
        {
            isAdminLogged = set;
        }


        //getters
        public bool getAdminLogged()
        {
            return isAdminLogged;
        }
        public Dictionary<string, string> getInsertProcedure()
        {
            return insertProcedures;
        }
        public Dictionary<string, string> getUpdateProcedure()
        {
            return updateProcedures;
        }
        /// <summary>
        /// Зареждаме в мапа ключовете - имената на таблиците, и като стойности процедурите за промяна на запис.
        /// По този начин на таблицата съответства процедурата за промяна на записа в таблицата
        /// </summary>
        public void loadUpdateProcedures()
        {
            updateProcedures.Add("CITIES", "EXEC CITIES_UPD @id, @name");
            updateProcedures.Add("COUNTRIES", "EXEC COUNTRIES_UPD @id, @name");
            updateProcedures.Add("GENRES", "EXEC GENRES_UPD @id, @name");
            updateProcedures.Add("FILMS", "EXEC FILMS_UPD @id, @producer, @leading, @film_name, @genreID, @filmYear");
            updateProcedures.Add("SERIES", "EXEC SERIES_UPD @id, @prod, @lead, @name, @season, @genre, @year");
            updateProcedures.Add("SERVICES", "EXEC SERVICES_UPD @id, @name, @price");
            updateProcedures.Add("POSITIONS", "EXEC POSITIONS_UPD @id, @desc");
            updateProcedures.Add("TYPES", "EXEC TYPES_UPD @id, @name");
            updateProcedures.Add("USERS", "EXEC USERS_UPD @id, @userName, @password, @email, @countryID");
            updateProcedures.Add("SUBCRIPTIONS", "EXEC SUBSCRIPTION_UPD @subsID, @userID, @servicesID, @startDate, @endDate");
            updateProcedures.Add("EMPLOYEES", "EXEC EMPLOYEES_UPD @id, @fName, @lName, @salary, @ph, @posId, @cityID");
        }

        /// <summary>
        /// Зареждаме в мапа ключовете - имената на таблиците, и като стойности процедурите за добавяне на запис.
        /// По този начин на таблицата съответства процедурата за добавяне на записа в таблицата
        /// </summary>
        public void loadInsertProcedures()
        {
            insertProcedures.Add("CITIES", "EXEC CITIES_INS @name");
            insertProcedures.Add("COUNTRIES", "EXEC COUNTRIES_INS @name");
            insertProcedures.Add("GENRES", "EXEC GENRES_INS @name");
            insertProcedures.Add("FILMS", "EXEC FILMS_INS @producer, @leading, @film_name, @genreID, @filmYear");
            insertProcedures.Add("SERIES", "EXEC SERIES_INS @producer, @leading, @series_name, @season, @genreID, @seriesYear");
            insertProcedures.Add("SERVICES", "EXEC SERVICES_INS @name, @price");
            insertProcedures.Add("POSITIONS", "EXEC POSITIONS_INS @desc");
            insertProcedures.Add("TYPES", "EXEC TYPES_INS @name");
            insertProcedures.Add("USERS", "EXEC USERS_INS @userName, @password, @email, @countryID");
            insertProcedures.Add("EMPLOYEES", "EXEC EMP_INS @fname, @lname, @salary, @phone, @positionID, @cityID");
            insertProcedures.Add("SUBSCRIPTIONS", "EXEC SUBSCRIPTION_INS @userID, @servicesID, @startDate, @endDate");
            insertProcedures.Add("FILM_LIBRARY", "EXEC FILM_LIBRARY_INS @FILMID, @USERID");
            insertProcedures.Add("SERIES_LIBRARY", "EXEC SERIES_LIBRARY_INS, @SERIESID, @USERID");
        }
    }
}
