using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoShop.TableClasses;
using VideoShop.BufferClasses;
using System.Windows.Forms;

namespace VideoShop.Classes
{
    class ViewControl
    {
        private static ViewControl _instance = null;
        private static readonly object _syncObject = new object();

        private Users loggedUser = new Users();
        private Films filterItem = new Films();

        private FilmsBuffer films = new FilmsBuffer();
        private SeriesBuffer series = new SeriesBuffer();
        private GenresBuffer genres = new GenresBuffer();
        private CitiesBuffer cities = new CitiesBuffer();
        private FilmsLibraryBuffer filmsLibrary = new FilmsLibraryBuffer();
        private SeriesLibraryBuffer seriesLibrary = new SeriesLibraryBuffer();
        private UsersBuffer users = new UsersBuffer();

        public static ViewControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new ViewControl();
                        }
                    }
                }
                return _instance;
            }
        }
        public ViewControl()
        {
            films.initializeFilmsArray();

            series.initializeSeriesArray();

            genres.initializeGenresArray();

            cities.initializeCitiesArray();

            users.initializeSubscriptions();

        }

        /// <summary>
        /// Функцията връща масива от жанрове
        /// </summary>
        /// <returns>Масива от жанрове</returns>
        public List<Object> getGenresArray()
        {
            return genres.returnRecords();
        }
       
        /// <summary>
        /// Проверява информацията на потребителя, който се опитва да се логне
        /// </summary>
        /// <param name="user">Детайлите на потребителя, който е написал</param>
        /// <returns>Връща true ако съществува потребител със същата информация</returns>
        public bool checkUserCredentials(Users user)
        {
            if (!users.checkCredentials(user))
            {
                return false;
            }

            loggedUser = user;
            filmsLibrary.initializeFilmsForUser(loggedUser);
            seriesLibrary.initializeSeriesForUser(loggedUser);
            return true;
        }

        /// <summary>
        /// Взима email-a на вече логнатият потребител
        /// </summary>
        /// <returns>Връща email-a</returns>
        public string getLoggedEmail()
        {
            return loggedUser.getEmail();
        }

        /// <summary>
        /// Запълва с данни посоченият ViewControl от масивите. Спрямо подадената опция
        /// </summary>
        /// <param name="view">ViewControl-ът, който ще запълваме с данни</param>
        /// <param name="sectionName">Използва се за да разграничим, с какви данни ще пълним ViewControl-a</param>
        public void fillViewControl(ListView view, string sectionName)
        {
            switch (sectionName)
            {
                case "films":
                    {
                        foreach(Films f in films.returnRecords())
                        {
                            f.setStringGenre(genres.returnGenre(f.getGenre()));
                            view.Items.Add(new ListViewItem(f.getStringArray()));
                        }
                        break;
                    }
                case "series":
                    {
                        foreach (Series s in series.returnRecords())
                        {
                            s.setStringGenre(genres.returnGenre(s.getGenre()));
                            view.Items.Add(new ListViewItem(s.getStringArray()));
                        }
                        break;
                    }
                case "cities":
                    {
                        foreach(Cities c in cities.returnRecords())
                        {
                            view.Items.Add(new ListViewItem(c.getCitiesArray()));
                        }
                        break;
                    }
                case "FilmsLibrary":
                    {
                        foreach(FilmsLibrary f in filmsLibrary.returnRecords())
                        {
                            Films film = films.returnFilmByID(f.getFilmID());
                            film.setStringGenre(genres.returnGenre(film.getGenre()));

                            view.Items.Add(new ListViewItem( film.getStringArray() ) );
                        }

                        break;
                    }
                case "SeriesLibrary":
                    {
                        foreach(SeriesLibrary s in seriesLibrary.returnRecords())
                        {
                            Series serial = series.returnSeriesByID(s.getSeries());
                            serial.setStringGenre(genres.returnGenre(serial.getGenre()));

                            view.Items.Add( new ListViewItem( serial.getStringArray() ) );
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Запълва с данни посоченият ViewControl по подаден критерии
        /// </summary>
        /// <param name="view">ViewControl-a, който ще запълваме с данни</param>
        /// <param name="sectionName">Използва се за да разграничим, с какви данни ще пълним ViewControl-a</param>
        /// <param name="searchQuery">Критерият, по който ще търсим в масивите</param>
        public void searchResult(ListView view, string sectionName, string searchQuery)
        {
            view.Items.Clear();
            switch (sectionName)
            {
                case "films":
                    {
                        foreach(Films f in films.returnRecords())
                        {
                            if(f.getStringGenre() == searchQuery)
                            {
                                view.Items.Add(new ListViewItem(f.getStringArray()));
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Задаване на данни, в определената таблица
        /// </summary>
        /// <param name="data">Данните, които ще вкарваме в масива и в базата данни</param>
        /// <param name="tableName">Името на таблицата, в която ще вкарваме данните</param>
       public void setData(Object data, string tableName)
        {
            switch (tableName)
            {
                case "Films":
                    {
                        films.insertRow( data as Films );
                        break;
                    }
                case "Users":
                    {
                        users.insertRow(data as Users);
                        loggedUser = data as Users;

                        filmsLibrary.initializeFilmsForUser(loggedUser);
                        break;
                    }
            }
        }

        /// <summary>
        /// Промяна на данни в определената таблица
        /// </summary>
        /// <param name="data">Данните, който ще променяме</param>
        /// <param name="tableName">Името на таблицата, чиито данни ще променяме</param>
       public void chandeData(Object data, string tableName)
        {
            switch (tableName)
            {
                case "Films":
                    {
                        Films f = data as Films;
                        f.setGenre(genres.returnID(f.getStringGenre()));
                        films.changeRow(f);
                        break;
                    }
            }
        }

        /// <summary>
        /// Изтриване на данни от определена таблица
        /// </summary>
        /// <param name="data">Данните, който ще изтриваме</param>
        /// <param name="tableName">Името на таблицата, чиито данни ще изтриваме</param>
        public void deleteData(Object data, string tableName)
        {
            switch (tableName)
            {
                case "Films":
                    {
                        films.deleteRow(data as Films);
                        break;
                    }
            }
        }

        /// <summary>
        /// Взимане на id от определената таблица
        /// </summary>
        /// <param name="name">Променливата, чиито id ще извличаме</param>
        /// <param name="className">Името на таблицата, от където ще взимаме id-то </param>
        /// <returns></returns>
        public int getID(string name, string className)
        {
            switch (className)
            {
                case "Films":
                    {
                        return films.getID(name);
                    }
                case "Series":
                    {
                        return series.getID(name);
                    }

            }
            return 0;
        }

        /// <summary>
        /// Запазване на данните за филтриране
        /// </summary>
        /// <param name="f">Данните за филтриране</param>
        public void setFilterItem(Films f)
        {
            filterItem = f;
        }

        /// <summary>
        /// Запълва с данни ViewControl-a след търсенето на данните
        /// </summary>
        /// <param name="view">ViewControl-a, който ще запълваме с данни </param>
        /// <param name="sectionName">Използва се за да разграничим, с какви данни ще пълним ViewControl-a</param>
        public void filterResult(ListView view, string sectionName)
        {
            filterItem.setGenre(genres.returnID(filterItem.getStringGenre()));
            switch (sectionName) 
            {
                case "Films":
                    {
                        foreach(Films f in films.searchByFilter(filterItem))
                        {
                            f.setStringGenre(genres.returnGenre(f.getGenre()));
                            view.Items.Add( new ListViewItem(f.getStringArray() ) );
                        }
                        break;
                    }
                case "Series":
                    {
                        Series filter = new Series();
                        filter.setDetails(filterItem);

                        foreach(Series s in series.searchByFilter(filter))
                        {
                            s.setStringGenre( genres.returnGenre(s.getGenre()) );
                            view.Items.Add( new ListViewItem(s.getStringArray()) );
                        }
                        break;
                    }
            }

        }

    }
}
