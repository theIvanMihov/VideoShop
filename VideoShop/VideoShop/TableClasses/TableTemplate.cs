using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoShop.Classes;

namespace VideoShop.TableClasses
{
    class TableTemplate <T>
    {
        private bool result;
        private string query;
        /// <summary>
        /// Функция за добавяне на нов запис в подадена таблица и записът, който ще вкарваме 
        /// </summary>
        /// <param name="tableName">Името на таблицата, в която ще вкраваме данните</param>
        /// <param name="t">Записът, който ще вкарваме в таблицата</param>
        /// <returns>При успешно вкарване на записа, функцията връща true, ако е станала грешка някъде функцията връща false</returns>
        public bool Insert(string tableName, T t)
        {
            
            foreach(var p in GlobalVariables.Instance.getInsertProcedure())
            {
                if(p.Key == tableName)
                {
                    query = p.Value;
                    break;

                }
            }

            SqlCommand comm = new SqlCommand(query, Connection.Instance.returnConnection());
            addParameters(comm, t);
            
            
            if (comm.ExecuteNonQuery() < 0)
            {
                MessageBox.Show("Неуспешен опит за добавяне на запис.");
                result = false ;
            }

            addID(t);
            

            comm.Dispose();
            result = true;
            return result;
        }

        /// <summary>
        /// Функция за извличане на данни от избрана таблица и въвеждането им в съответен масив
        /// </summary>
        /// <param name="tableName">Името на таблицата от, която ще извличаме данните</param>
        /// <param name="arrayT">Масивът, в който ще записваме всички данни</param>
        /// <returns>При успешно извличане на данните функцията връще true, но в обратен случай функцията връща false</returns>
        public bool Select (string tableName, List<Object> arrayT)
        {
            SqlDataReader sr;
            query = "SELECT * FROM " + tableName;
            SqlCommand comm = new SqlCommand(query, Connection.Instance.returnConnection());

            sr = comm.ExecuteReader();
            while (sr.Read())
            {
                arrayT.Add(selectReader(sr));
            }


            sr.Close();
            comm.Dispose();
            return true;
        }
        /// <summary>
        /// Извлича всички данни за дадената таблица по подаден критерии
        /// </summary>
        /// <param name="tableName">Името на таблицата от, която ще взимаме данните</param>
        /// <param name="arrayT">Масива, където ще слагаме данните</param>
        /// <param name="t">Критерият, по който ще извличаме данните</param>
        /// <returns></returns>
        public bool SelectWhereID(string tableName, List<Object> arrayT, Users u)
        {
            SqlDataReader sr;
            query = "SELECT * FROM " + tableName;
            switch (tableName)
            {
                case "FILM_LIBRARY":
                    {               
                        query += " WHERE USER_ID=" + u.getUserID();
                        break;
                    }
                case "SERIES_LIBRARY":
                    {                      
                        query += " WHERE USER_ID=" + u.getUserID();
                        break;
                    }
                case "SUBSCRIPTIONS": 
                    {
                        query += " WHERE SUBS_USER_ID=" + u.getUserID();
                        break;
                    }
                case "USERS":
                    {
                        query += " WHERE [USER_USERNAME]=" + u.getUserName();
                        break;
                    }
            }

            SqlCommand comm = new SqlCommand(query, Connection.Instance.returnConnection());

            sr = comm.ExecuteReader();
            while (sr.Read())
            {
                arrayT.Add(selectReader(sr));
            }

            sr.Close();
            comm.Dispose();
            return true;

        }

        /// <summary>
        /// Функция за променяне на съществуващ запис от таблицата 
        /// </summary>
        /// <param name="tableName">Името на таблицата, където ще променяме записа</param>
        /// <param name="t">Промененият вече запис</param>
        /// <returns>При успешна промяна на данните функцията връще true, но в обратен случай функцията връща false</returns>
        public bool Update (string tableName, T t)
        {
            
            foreach(var p in GlobalVariables.Instance.getUpdateProcedure())
            {
                if(tableName == p.Key)
                {
                    query = p.Value;
                    break;
                }
            }

            SqlCommand comm = new SqlCommand(query, Connection.Instance.returnConnection());
            addUpdateParameteres(comm, t);

            if (comm.ExecuteNonQuery() < 0)
            {
                result = false;
            }
            
            comm.Dispose();
            result = true;
            return result;
            
        }

        /// <summary>
        /// Функция за изтриване на запис от базата данни
        /// </summary>
        /// <param name="t">Записът, който ще изтриваме</param>
        /// <returns>Връща true ако успешно изтрие записа</returns>
        public bool Delete(T t)
        {
            query = getDeleteQuery(t);

            SqlCommand comm = new SqlCommand(query, Connection.Instance.returnConnection());

            if(comm.ExecuteNonQuery() < 0)
            {
                result = false;
            }

            comm.Dispose();
            result = true;
            return result;
        }

        /// <summary>
        /// В тази функция спрямо името на таблицата се чете такъв запис от SqlDataReader-a
        /// </summary>
        /// <param name="sr">Променливата, която чете от БД</param>
        /// <param name="tableName">Името на таблицата</param>
        /// <returns>Връща обект, който се записва в подаденият масив</returns>
        private Object selectReader(SqlDataReader sr)
        {            
            switch (typeof(T).Name)
            {
                case "Cities":
                    {
                        return new Cities(sr.GetInt32(0), sr.GetString(1));
                    }
                case "Countries":
                    {
                        return new Countries(sr.GetInt32(0), sr.GetString(1));
                    }
                case "Genres":
                    {
                        return new Genres(sr.GetInt32(0), sr.GetString(1));
                    }
                case "Films":
                    { 
                        return new Films(sr.GetInt32(0), sr.GetString(1), sr.GetString(2), sr.GetString(3), sr.GetInt32(4), Int32.Parse(sr.GetString(5)));
                    }
                case "Series":
                    {
                        return new Series(sr.GetInt32(0), sr.GetString(1), sr.GetString(2), sr.GetString(3), sr.GetInt32(4), sr.GetInt32(5), Int32.Parse(sr.GetString(6)));
                    }
                case "ServicesNames":
                    {
                        return new ServicesNames(sr.GetInt32(0), sr.GetString(1), sr.GetDouble(2));
                    }
                case "StaffPositions":
                    {
                        return new StaffPositions(sr.GetInt32(0), sr.GetString(1));
                    }
                case "Types":
                    {
                        return new Types(sr.GetInt32(0), sr.GetString(1));
                    }
                case "Users":
                    {
                        return new Users(sr.GetInt32(0), sr.GetString(1), sr.GetString(2), sr.GetString(3), sr.GetInt32(4));
                    }
                case "Positions":
                    {
                        return new Positions(sr.GetInt32(0), sr.GetString(1));
                    }
                case "Employees":
                    {
                        return new Employees(sr.GetInt32(0), sr.GetString(1), sr.GetString(2), sr.GetInt32(3), sr.GetString(4), sr.GetInt32(5), sr.GetInt32(6));
                    }
                case "FilmsLibrary":
                    {
                        return new FilmsLibrary(sr.GetInt32(0), sr.GetInt32(1));
                    }
                case "SeriesLibrary":
                    {
                        return new SeriesLibrary(sr.GetInt32(0), sr.GetInt32(1));
                    }
                case "Subscriptions":
                    {
                        return new Subscriptions(sr.GetInt32(0), sr.GetInt32(1), sr.GetDateTime(2), sr.GetDateTime(3));
                    }
                    
            }
            return null;

        }

        /// <summary>
        /// В тази функция записваме ID-то на последния записан запис в таблицата за да успеем да запаметим id-to в масива, без да четем цялата таблица наново
        /// </summary>
        /// <param name="tableName">Името на таблицата</param>
        /// <param name="t">Новият запис, в който ще записваме id-то</param>
        private void addID(T t)
        {
            switch (typeof(T).Name)
            {
                case "Cities":
                    {
                        ( t as Cities ).setID(returnID( "CITIES" ) );
                        break;
                    }
                case "Countries":
                    {
                        ( t as Countries ).setCountryID( returnID( "COUNTRIES" ) );
                        break;
                    }
                case "Genres":
                    {
                        (t as Genres).setGenreID( returnID( "GENRES" ) );
                        break;
                    }
                case "Films":
                    {
                        (t as Films).setID( returnID( "FILMS" ) );
                        break;
                    }
                case "Series":
                    {
                        (t as Series).setSeriesID( returnID( "SERIES" ) );
                        break;
                    }
                case "ServicesNames":
                    {
                        (t as ServicesNames).setServID( returnID("SERVICES") );
                        break;
                    }
                case "StaffPositions":
                    {
                        (t as StaffPositions).setPosID( returnID( "POSITIONS" ) );
                        break;
                    }
                case "Types":
                    {
                        (t as Types).setID( returnID( "TYPES" ) );
                        break;
                    }
                case "Users":
                    {
                        (t as Users).setUserID( returnID( "[USERS]" ) );
                        break;
                    }
                case "Employees":
                    {
                        (t as Employees).setID( returnID( "EMPLOYEES" ) );
                        break; ;
                    }
                case "Positions":
                    {
                        (t as Positions).setID( returnID( "POSITIONS" ) );
                        break;
                    }
                case "Subscriptions":
                    {
                        (t as Subscriptions).setSubID( returnID( "SUBSCRIPTIONS" ) );
                        break;
                    }
            }
        }

        /// <summary>
        /// Тук взимаме ID-то на последно записаният запис в съответната таблица
        /// </summary>
        /// <param name="tableName">Името на таблицата</param>
        /// <returns>Функцията връща ID-то</returns>
        private int returnID(string tableName)
        {
            decimal id = 0;
            SqlDataReader sr;
            query = "SELECT IDENT_CURRENT('"+ tableName +"') AS LASTID";
            SqlCommand comm = new SqlCommand(query, Connection.Instance.returnConnection());

            sr = comm.ExecuteReader();
            while (sr.Read())
            {
                id = sr.GetDecimal(0);
            }

            return Int32.Parse(id.ToString());

        }

        /// <summary>
        /// Тук записваме параметрите в SqlCommand съответно за всяка таблица за заявките за добавяне на записи
        /// </summary>
        /// <param name="comm">SqlCommand параметъра</param>
        /// <param name="tableName">Името на таблицата</param>
        /// <param name="t">Данните, който ще добавяме</param>
        private void addParameters(SqlCommand comm, T t)
        {
            switch (typeof(T).Name)
            {
                case "Cities":
                    {
                        comm.Parameters.AddWithValue("@name", (t as Cities).getCity());
                        break;
                    }
                case "Countries":
                    {
                        comm.Parameters.AddWithValue("@name", (t as Countries).getCountry());
                        break;
                    }
                case "Genres":
                    {
                        comm.Parameters.AddWithValue("@name", (t as Genres).getGenreName());
                        break;
                    }
                case "Films":
                    {
                        var f = (t as Films);
                        comm.Parameters.AddWithValue("@producer", f.getProducer());
                        comm.Parameters.AddWithValue("@leading", f.getLeading());
                        comm.Parameters.AddWithValue("@film_name", f.getName());
                        comm.Parameters.AddWithValue("@genreID", f.getGenre());
                        comm.Parameters.AddWithValue("@filmYear", f.getYear());
                        break;
                    }
                case "Series":
                    {
                        var s = (t as Series);
                        comm.Parameters.AddWithValue("@producer", s.getProd());
                        comm.Parameters.AddWithValue("@leading", s.getLead());
                        comm.Parameters.AddWithValue("@series_name", s.getName());
                        comm.Parameters.AddWithValue("@genreID", s.getGenre());
                        comm.Parameters.AddWithValue("@seriesYear", s.getYear());
                        break;
                    }
                case "ServicesNames":
                    {
                        var c = (t as ServicesNames);
                        comm.Parameters.AddWithValue("@name", c.getServName());
                        comm.Parameters.AddWithValue("@float", c.getServPrice());
                        break;
                    }
                case "StaffPositions":
                    {
                        var c = (t as StaffPositions);
                        comm.Parameters.AddWithValue("@desc", c.getPosName());
                        break;
                    }
                case "Types":
                    {
                        var f = t as Types;
                        comm.Parameters.AddWithValue("@name", f.getType());
                        break;
                    }
                case "Users":
                    {
                        var u = t as Users;
                        comm.Parameters.AddWithValue("@userName", u.getUserName());
                        comm.Parameters.AddWithValue("@password", u.getPass());
                        comm.Parameters.AddWithValue("@email", u.getEmail());
                        comm.Parameters.AddWithValue("@countryID", u.getCountryID());
                        break;
                    }
                case "Positions":
                    {
                        var p = t as Positions;
                        comm.Parameters.AddWithValue("@desc", p.getPosName());
                        break;
                    }
                case "Employees":
                    {
                        var e = t as Employees;
                        comm.Parameters.AddWithValue("@fname", e.getFirstName());
                        comm.Parameters.AddWithValue("@lname", e.getLastName());
                        comm.Parameters.AddWithValue("@salary", e.getSalary());
                        comm.Parameters.AddWithValue("@phone", e.getPhone());
                        comm.Parameters.AddWithValue("@positionID", e.getPos());
                        comm.Parameters.AddWithValue("@cityID", e.getCity());
                        break;
                    }
                case "FilmsLibrary":
                    {
                        var f = t as FilmsLibrary;
                        comm.Parameters.AddWithValue("@FILM_ID", f.getFilmID());
                        comm.Parameters.AddWithValue("@USER_ID", f.getUserID());
                        break;
                    }
                case "SeriesLibrary":
                    {
                        var s = t as SeriesLibrary;
                        comm.Parameters.AddWithValue("@SERIESID", s.getSeries());
                        comm.Parameters.AddWithValue("@USERID", s.getUser());
                        break;
                    }
                case "Subscriptions":
                    {
                        var s = t as Subscriptions;
                        comm.Parameters.AddWithValue("@userID", s.getUserID());
                        comm.Parameters.AddWithValue("@servicesID", s.getServID());
                        comm.Parameters.AddWithValue("@startDate", s.getStartDate());
                        comm.Parameters.AddWithValue("@endDate", s.getEndDate());
                        break;
                    }


            }
        }

        /// <summary>
        /// Тук записваме параметрите за всяка таблица за заявките за промяна на записи
        /// </summary>
        /// <param name="comm">SqlCommand параметър</param>
        /// <param name="tableName">Името на таблицата</param>
        /// <param name="t">Данните, който ще променяме</param>
        private void addUpdateParameteres( SqlCommand comm, T t)
        {
            switch (typeof(T).Name)
            {
                case "Cities":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Cities).getId());
                        comm.Parameters.AddWithValue("@name", (t as Cities).getCity());
                        break;
                    }
                case "Countries":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Countries).getCountryID());
                        comm.Parameters.AddWithValue("@name", (t as Countries).getCountry());
                        break;
                    }
                case "Genres":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Genres).getGenreID());
                        comm.Parameters.AddWithValue("@name", (t as Genres).getGenreName());
                        break;
                    }
                case "Films":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Films).getID());
                        comm.Parameters.AddWithValue("@producer", (t as Films).getProducer());
                        comm.Parameters.AddWithValue("@leading", (t as Films).getLeading());
                        comm.Parameters.AddWithValue("@film_name", (t as Films).getName());
                        comm.Parameters.AddWithValue("@genreID", (t as Films).getGenre());
                        comm.Parameters.AddWithValue("@filmYear", (t as Films).getYear());
                        break;
                    }
                case "Series":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Series).getSeriesID());
                        comm.Parameters.AddWithValue("@prod", (t as Series).getProd());
                        comm.Parameters.AddWithValue("@lead", (t as Series).getLead());
                        comm.Parameters.AddWithValue("@name", (t as Series).getName());
                        comm.Parameters.AddWithValue("@season", (t as Series).getSeason());
                        comm.Parameters.AddWithValue("genre", (t as Series).getGenre());
                        comm.Parameters.AddWithValue("@year", (t as Series).getYear());
                        break;
                    }
                case "ServicesNames":
                    {
                        comm.Parameters.AddWithValue("@id", (t as ServicesNames).getServID());
                        comm.Parameters.AddWithValue("@name", (t as ServicesNames).getServName());
                        comm.Parameters.AddWithValue("@price", (t as ServicesNames).getServPrice());
                        break;
                    }
                case "StaffPositions":
                    {
                        comm.Parameters.AddWithValue("@id", (t as StaffPositions).getPosID());
                        comm.Parameters.AddWithValue("@desc", (t as StaffPositions).getPosName());
                        break;
                    }
                case "Types":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Types).getID());
                        comm.Parameters.AddWithValue("@name", (t as Types).getType());
                        break;
                    }
                case "Users":
                    {
                        comm.Parameters.AddWithValue("@id", (t as Users).getUserID());
                        comm.Parameters.AddWithValue("@userName", (t as Users).getUserName());
                        comm.Parameters.AddWithValue("@password", (t as Users).getPass());
                        comm.Parameters.AddWithValue("@email", (t as Users).getEmail());
                        comm.Parameters.AddWithValue("@countryID", (t as Users).getCountryID());
                        break;
                    }
                case "Employee":
                    {
                        var e = t as Employees;
                        comm.Parameters.AddWithValue("@id", e.getID());
                        comm.Parameters.AddWithValue("@fName", e.getFirstName());
                        comm.Parameters.AddWithValue("@lName", e.getLastName());
                        comm.Parameters.AddWithValue("@salary", e.getSalary());
                        comm.Parameters.AddWithValue("@ph", e.getPhone());
                        comm.Parameters.AddWithValue("@posID", e.getPos());
                        comm.Parameters.AddWithValue("@cityID", e.getCity());
                        break;
                    }
                case "Subscriptions":
                    {
                        var s = t as Subscriptions;
                        comm.Parameters.AddWithValue("@subsID", s.getSubID());
                        comm.Parameters.AddWithValue("@userID", s.getUserID());
                        comm.Parameters.AddWithValue("@servicesID", s.getServID());
                        comm.Parameters.AddWithValue("@startDate", s.getStartDate());
                        comm.Parameters.AddWithValue("@endDate", s.getEndDate());
                        break;
                    }
            }
        }
              
        /// <summary>
        /// Създаваме query за изтриване от базата данни за едната от таблиците
        /// </summary>
        /// <param name="t">Записът, който ще изтриваме</param>
        /// <returns>Връща query-то</returns>
        private string getDeleteQuery(T t)
        {
            switch (typeof(T).Name) 
            {
                case "Films":
                    {
                        return "DELETE FROM FILMS WHERE ID=" + (t as Films).getID();
                    }
                case "Cities":
                    {
                        return "DELETE FROM CITIES WHERE CITY_ID=" + (t as Cities).getId();
                    }
                case "Countries":
                    {
                        return "DELETE FROM COUNTRIES WHERE COUNTRY_ID=" + (t as Countries).getCountryID();
                    }
                case "Genres":
                    {
                        return "DELETE FROM GENRES WHERE ID=" + (t as Genres).getGenreID();
                    }
                case "Series":
                    {
                        return "DELETE FROM SERIES WHERE ID=" + (t as Series).getSeriesID();
                    }
                case "ServicesNames":
                    {
                        return "DELETE FROM [SERVICES] WHERE ID=" + (t as ServicesNames).getServName();
                    }
                case "StaffPositions":
                    {
                        return "DELETE FROM POSITIONS WHERE POS_ID=" + (t as StaffPositions).getPosID();
                    }
                case "Users":
                    {
                        return "DELETE FROM [USERS] WHERE [USER_ID]=" + (t as Users).getUserID();
                    }
                case "Employees":
                    {
                        return "DELETE FROM EMPLOYEES WHERE EMP_ID=" + (t as Employees).getID();
                    }
                case "Subscriptions":
                    {
                        return "DELETE FROM SUBSCRIPTIONS WHERE SUBS_ID=" + (t as Subscriptions).getSubID();
                    }
            }
            return null;

        }


    }
}
