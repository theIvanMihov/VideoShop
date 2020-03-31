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
    class SeriesLibraryBuffer
    {

        private TableTemplate<SeriesLibrary> libraryTable = new TableTemplate<SeriesLibrary>();
        private List<Object> seriesLibraryArray = new List<Object>();

        public SeriesLibraryBuffer()
        {

        }

        /// <summary>
        /// Функция за връщане на пълният масив
        /// </summary>
        /// <returns>Връща масив от обекти</returns>
        public List<Object> returnRecords()
        {
            return seriesLibraryArray;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeSeriesForUser(Users u)
        {
            if (!libraryTable.SelectWhereID("Series_Library", seriesLibraryArray, u))
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
        public bool insertRow(SeriesLibrary f)
        {
            if (!libraryTable.Insert("SERIES_LIBRARY", f))
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
        public bool removeRecord(SeriesLibrary f)
        {

            if (!checkIfInside(f))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (SeriesLibrary n in seriesLibraryArray)
            {
                if (n.getSeries() == f.getSeries())
                {
                    if (n.getUser() == f.getUser())
                    {
                        seriesLibraryArray.Remove(n);
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
        private bool checkIfInside(SeriesLibrary f)
        {
            foreach (SeriesLibrary n in seriesLibraryArray)
            {
                if (n.getUser() == f.getUser()) { }
                {
                    if (n.getSeries() == f.getSeries())
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
        private void addNewRecord(SeriesLibrary f)
        {
            seriesLibraryArray.Add(f);
        }
    }
}
