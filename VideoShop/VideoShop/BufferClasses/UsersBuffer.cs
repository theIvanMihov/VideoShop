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
    class UsersBuffer
    {
        private TableTemplate<Users> usersTable = new TableTemplate<Users>();
        private List<Object> usersArray = new List<Object>();

        public UsersBuffer()
        {

        }
        public bool checkCredentials(Users login)
        {
            foreach(Users u in usersArray)
            {
                if (Pepper.Instance.Authenticate(u.getUserName(), login.getUserName()) )
                {
                    if(Pepper.Instance.Authenticate(u.getPass(), u.getPass()))
                    {
                        login.setUserDetails(u);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Функция за връщане на пълният масив
        /// </summary>
        /// <returns>Връща масив от обекти</returns>
        public List<Object> returnRecords()
        {
            return usersArray;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeSubForUser(Users u)
        {
            if (!usersTable.SelectWhereID("USERS", usersArray, u))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeSubscriptions()
        {
            if (!usersTable.Select("USERS", usersArray))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Функция за добавяне на запис 
        /// </summary>
        /// <param name="u">Записът, който ще добавяме</param>
        /// <returns>Връща true ако записът е добавен успешно</returns>
        public bool insertRow(Users u)
        {
            if (!checkDuplicateRecord(u))
            {
                MessageBox.Show("Този град вече съществува.");
                return false;
            }

            if (!usersTable.Insert("USERS", u))
            {
                MessageBox.Show("Неуспешен опит за извършване на операцията. ");
                return false;
            }

            addNewRecord(u);
            return true;
        }

        /// <summary>
        /// Функция за промяна на запис
        /// </summary>
        /// <param name="u">Вече промененият запис</param>
        /// <returns>Връща true ако промяната е станала успешно</returns>
        public bool changeRow(Users u)
        {
            if (!checkIfInside(u))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (Users n in usersArray)
            {
                if (n.getUserID() == u.getUserID())
                {
                    n.setUserDetails(u);
                    if (!usersTable.Update("USERS", n))
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
        /// Премахване на запис
        /// </summary>
        /// <param name="u">Записът, който ще премахваме</param>
        /// <returns>Връща true ако премахването е успешно</returns>
        public bool deleteRow(Users u)
        {
            if (!checkIfNameInside(u))
            {
                MessageBox.Show("no");
                return false;
            }

            foreach (Users n in usersArray)
            {
                if (n.getUserName() == u.getUserName())
                {
                    u.setUserID(n.getUserID());
                    usersArray.Remove(n);
                    if (!usersTable.Delete(u))
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
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="u">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfInside(Users u)
        {
            foreach (Users n in usersArray)
            {
                if (n.getUserID() == u.getUserID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка дали съществува това потребителско име
        /// </summary>
        /// <param name="u">Записът, който проверяваме</param>
        /// <returns>Връща true ако това име го няма</returns>
        private bool checkIfNameInside(Users u)
        {
            foreach (Users i in usersArray)
            {
                if (u.getUserName() == i.getUserName())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="u">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkDuplicateRecord(Users u)
        {
            foreach (Users i in usersArray)
            {
                if (i.getUserName() == u.getUserName())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Добавяне на нов запис в буферния масив
        /// </summary>
        /// <param name="u">Записът, който добавяме</param>
        private void addNewRecord(Users u)
        {
            usersArray.Add(u);
        }
    }
}
