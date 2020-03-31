using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoShop.TableClasses;
using VideoShop.Classes;
using System.Windows.Forms;

namespace VideoShop.BufferClasses
{
    class GenresBuffer
    {
        private TableTemplate<Genres> genresTable = new TableTemplate<Genres>();
        private List<Object> genresArray = new List<Object>();

        /// <summary>
        /// Зарежда жанровете от базата данни
        /// </summary>
        /// <returns>Връща true ако успешно се извлекат данните </returns>
        public bool initializeGenresArray()
        {
            if( !genresTable.Select("GENRES", genresArray))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Функцията връща масива от жанрове
        /// </summary>
        /// <returns>Масива от жанрове</returns>
        public List<Object> returnRecords()
        {
            return genresArray;
        }

        /// <summary>
        /// Добавя запис в буферния масив и в базата данни
        /// </summary>
        /// <param name="g">Записът, който ще добавяме/param>
        /// <returns>Връща true ако успешно се запише в назата данни</returns>
        public bool insertRow(Genres g)
        {
            if (!checkDuplicateRecord(g))
            {
                MessageBox.Show("Този град вече съществува.");
                return false;
            }

            if (!genresTable.Insert("GENRES", g))
            {
                MessageBox.Show("Неуспешен опит за извършване на операцията. ");
                return false;
            }

            addNewRecord(g);
            return true;
        }

        /// <summary>
        /// Функция за промяна на запис
        /// </summary>
        /// <param name="g">Вече промененият запис</param>
        /// <returns>Връща true ако промяната е станала успешно</returns>
        public bool changeRow(Genres g)
        {
            if (!checkIfInside(g))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (Genres n in genresArray)
            {
                if (n.getGenreID() == g.getGenreID())
                {
                    n.setGenreName(g.getGenreName());
                    if (!genresTable.Update("GENRES", n))
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
        /// <param name="g">Записът, който ще изтриваме</param>
        /// <returns>Връща true ако успешно изтрием записа</returns>
        public bool deleteRow(Genres g)
        {
            if (!checkIfNameInside(g))
            {
                MessageBox.Show("no");
                return false;
            }

            foreach (Genres n in genresArray)
            {
                if (n.getGenreName() == g.getGenreName())
                {
                    g.setGenreID(n.getGenreID());
                    genresArray.Remove(n);
                    if (!genresTable.Delete(g))
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
        /// Проверка дали този обект съществува
        /// </summary>
        /// <param name="g">Структурата, която проверяваме</param>
        /// <returns>Връща true ако структурата съществува</returns>
        private bool checkIfInside(Genres g)
        {
            foreach (Genres n in genresArray)
            {
                if (n.getGenreID() == g.getGenreID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="g">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfNameInside(Genres g)
        {
            foreach (Genres i in genresArray)
            {
                if (g.getGenreName() == i.getGenreName())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверява дали има същия запис
        /// </summary>
        /// <param name="g">Структурата, коят проверяваме</param>
        /// <returns>Връща true ако такъв запис съществува</returns>
        private bool checkDuplicateRecord(Genres g)
        {
            foreach (Genres i in genresArray)
            {
                if (i.getGenreName() == g.getGenreName())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Добавя запис в буферния масив
        /// </summary>
        /// <param name="g">Записът, който ще добавяме</param>
        private void addNewRecord(Genres g)
        {
            genresArray.Add(g);
        }

        /// <summary>
        /// Връща id по дадено име на жанра
        /// </summary>
        /// <param name="genre">ID-то на жанра</param>
        /// <returns>Жанра, който търсим. Ако върне null значи не съществува филм с такова ID</returns>
        public int returnID(string genre)
        {
            foreach(Genres g in genresArray)
            {
                if(g.getGenreName() == genre)
                {
                    return g.getGenreID();
                }
            }
            return 0;
        }

        /// <summary>
        /// Връща id по дадено име на жанра
        /// </summary>
        /// <param name="a">id-to на жанра</param>
        /// <returns>Жанра, който търсим. Ако върне null значи не съществува филм с такова ID</returns>
        public string returnGenre(int a)
        {
            foreach(Genres g in genresArray)
            {
                if(g.getGenreID() == a)
                {
                    return g.getGenreName();
                }
            }
            return null;
        }
    }
}
