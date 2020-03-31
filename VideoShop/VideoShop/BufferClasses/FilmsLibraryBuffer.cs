using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoShop.Classes;
using VideoShop.TableClasses;
using System.Windows.Forms;

namespace VideoShop.BufferClasses
{
    class FilmsLibraryBuffer
    {
        private TableTemplate<FilmsLibrary> libraryTable = new TableTemplate<FilmsLibrary>();
        private List<Object> filmLibraryArray = new List<Object>();

        public FilmsLibraryBuffer()
        {

        }

        /// <summary>
        /// Функция за връщане на пълният масив
        /// </summary>
        /// <returns>Връща масив от обекти</returns>
        public List<Object> returnRecords()
        {
            return filmLibraryArray;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeFilmsForUser(Users u)
        {
            if (!libraryTable.SelectWhereID("FILM_LIBRARY", filmLibraryArray, u))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Функция за добавяне на запис 
        /// </summary>
        /// <param name="f">Записът, който ще добавяме</param>
        /// <returns>Връща true ако записът е добавен успешно</returns>
        public bool insertRow(FilmsLibrary f)
        {
            if (!libraryTable.Insert("FILM_LIBRARY", f))
            {
                MessageBox.Show("Неуспешен опит за извършване на операцията. ");
                return false;
            }

            addNewRecord(f);
            return true;
        }

        /// <summary>
        /// Премахване на запис
        /// </summary>
        /// <param name="f">Записът, който ще премахваме</param>
        /// <returns>Връща true ако премахването е успешно</returns>
        public bool removeRecord(FilmsLibrary f)
        {

            if (!checkIfInside(f))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (FilmsLibrary n in filmLibraryArray)
            {
                if (n.getFilmID() == f.getFilmID())
                {
                    if(n.getUserID() == f.getUserID())
                    {
                        filmLibraryArray.Remove(n);
                        if (!libraryTable.Delete(f))
                        {
                            MessageBox.Show("no");
                            return false;
                        }
                    }
                    

                }
            }

            MessageBox.Show("yes");
            return true;
        }

        /// <summary>
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="f">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfInside(FilmsLibrary f)
        {
            foreach (FilmsLibrary n in filmLibraryArray)
            {
                if (n.getUserID() == f.getUserID()) { }
                {
                    if (n.getFilmID() == f.getFilmID())
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Добавяне на нов запис в буферния масив
        /// </summary>
        /// <param name="f">Записът, който добавяме</param>
        private void addNewRecord(FilmsLibrary f)
        {
            filmLibraryArray.Add(f);
        }

    }
}
