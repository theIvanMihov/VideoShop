using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoShop.Classes;
using VideoShop.TableClasses;

namespace VideoShop.BufferClasses
{
    class FilmsBuffer
    {
        private TableTemplate<Films> filmsTable = new TableTemplate<Films>();
        private List<Object> filmsArray = new List<Object>();

        public FilmsBuffer()
        {

        }

        /// <summary>
        /// Зареждане на филмите от базата данни
        /// </summary>
        /// <returns>Връща true ако успешно са заредени данните от базата данни</returns>
        public bool initializeFilmsArray()
        {
            if( !filmsTable.Select("FILMS", filmsArray))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Функцията връща масива от филми от базата данни
        /// </summary>
        /// <returns>Връща масива</returns>
        public List<Object> returnRecords()
        {
            return filmsArray;
        }

        /// <summary>
        /// Връща филм по дадено id
        /// </summary>
        /// <param name="id">ID-то на филма</param>
        /// <returns>Филма, който търсим. Ако върне null значи не съществува филм с такова ID</returns>
        public Films returnFilmByID(int id)
        {
            foreach(Films i in filmsArray)
            {
                if(i.getID() == id)
                {
                    return i;
                }
            }
            return null;
        }

        /// <summary>
        /// Търсене на филм, по зададени данни
        /// </summary>
        /// <param name="f">Критерият за задаване на данните</param>
        /// <returns>Връща масив от филми, които отговарят на тези критерии</returns>
        public List<Object> searchByFilter(Films f)
        {
            List<Object> resultArray = new List<Object>();
            List<Object> yearArray = new List<Object>();

            if(f.getGenre() != 0)
            {
                foreach (Films i in filmsArray)
                {
                    if (i.getGenre() == f.getGenre())
                    {
                        resultArray.Add(i);
                    }
                }
            }

            if(f.getName() != "")
            {
                foreach (Films i in filmsArray)
                {
                    if (i.getName() == f.getName())
                    {
                        resultArray.Add(i);
                        return resultArray;
                    }
                }
            }

            if(f.getYear() != 0)
            {
                if (resultArray.Count != 0)
                {
                    foreach (Films i in resultArray)
                    {
                        if (i.getYear() == f.getYear())
                        {
                            yearArray.Add(i);
                        }
                    }
                    return yearArray;
                }
                else
                {
                    foreach (Films i in filmsArray)
                    {
                        if (i.getYear() == f.getYear())
                        {
                            resultArray.Add(i);
                        }
                    }
                }
            }
            
            return resultArray;
        }

        /// <summary>
        /// Enters a row into the DB
        /// </summary>
        /// <param name="f">The structure that needs to be inserted</param>
        /// <returns>Returns true if the data is selected successfully, and false if occured an error</returns>
        public bool insertRow(Films f)
        {
            if (!checkDuplicateRecord(f))
            {
                MessageBox.Show("Този град вече съществува.");
                return false;
            }

            if (!filmsTable.Insert("FILMS", f))
            {
                MessageBox.Show("Неуспешен опит за извършване на операцията. ");
                return false;
            }

            addNewRecord(f);
            return true;
        }

        /// <summary>
        /// Взимаме id-то по зададено име
        /// </summary>
        /// <param name="name">Името, което ще търсим </param>
        /// <returns>Връща id-то на елемента</returns>
        public int getID(string name)
        {
            foreach(Films f in filmsArray)
            {
                if(f.getName() == name)
                {
                    return f.getID();
                }
            }
            return 0;
        }

        /// <summary>
        /// Функция за промяна на запис
        /// </summary>
        /// <param name="f">Вече промененият запис</param>
        /// <returns>Връща true ако промяната е станала успешно</returns>
        public bool changeRow(Films f)
        {
            if (!checkIfInside(f))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (Films n in filmsArray)
            {
                if (n.getID() == f.getID())
                {
                    n.setFilmSettings(f);
                    if (!filmsTable.Update("FILMS", n))
                    {
                        MessageBox.Show("no");
                        return false;
                    }
                    MessageBox.Show("yes");
                }
            }
            return true;
        }

        /// <summary>
        /// Изтриване на запис
        /// </summary>
        /// <param name="f">Записът, който ще изтриваме</param>
        /// <returns>Връща true ако успешно изтрием записа</returns>
        public bool deleteRow(Films f)
        {
            if (!checkIfNameInside(f))
            {
                MessageBox.Show("no");
                return false;
            }

            foreach (Films n in filmsArray)
            {
                if (n.getName() == f.getName())
                {
                    f.setID(n.getID());
                    filmsArray.Remove(n);
                    if (!filmsTable.Delete(f))
                    {
                        MessageBox.Show("no");
                        return false;
                    }
                    break;
                }
            }
            MessageBox.Show("yes");
            return true;
        }


        /// <summary>
        /// Проверява дали структурата съществува
        /// </summary>
        /// <param name="f">Структурата, която искаме да проверим</param>
        /// <returns>Връща true ако съществува</returns>
        private bool checkIfInside(Films f)
        {
            foreach (Films n in filmsArray)
            {
                if (n.getID() == f.getID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="f">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfNameInside(Films f)
        {
            foreach (Films i in filmsArray)
            {
                if (f.getName() == i.getName())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверява дали вече съществува дубликат 
        /// </summary>
        /// <param name="f">Структурата, която ще проверяваме</param>
        /// <returns>Връща true ако не съществува</returns>
        private bool checkDuplicateRecord(Films f)
        {
            foreach (Films i in filmsArray)
            {
                if (i.getName() == f.getName())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Добавя новия запис в буферния масив
        /// </summary>
        /// <param name="f">Новата структура, която ще добавяме</param>
        private void addNewRecord(Films f)
        {
            filmsArray.Add(f);
        }
    }
}
