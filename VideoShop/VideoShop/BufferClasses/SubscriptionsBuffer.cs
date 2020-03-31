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
    class SubscriptionsBuffer
    {
        private TableTemplate<Subscriptions> subscriptionTable = new TableTemplate<Subscriptions>();
        private List<Object> subsArray = new List<Object>();

        public SubscriptionsBuffer()
        {

        }

        /// <summary>
        /// Функция за връщане на пълният масив
        /// </summary>
        /// <returns>Връща масив от обекти</returns>
        public List<Object> returnRecords()
        {
            return subsArray;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeSubForUser(Users u)
        {
            if (!subscriptionTable.SelectWhereID("SUBSCRIPTIONS", subsArray, u))
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
            if (!subscriptionTable.Select("SUBSCRIPTIONS", subsArray))
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
        public bool insertRow(Subscriptions s)
        {
            if (!checkIfInside(s))
            {
                MessageBox.Show("Този град вече съществува.");
                return false;
            } 

            if (!subscriptionTable.Insert("SUBSCRIPTIONS", s))
            {
                MessageBox.Show("Неуспешен опит за извършване на операцията. ");
                return false;
            }

            addNewRecord(s);
            return true;
        }

        /// <summary>
        /// Функция за промяна на запис
        /// </summary>
        /// <param name="s">Вече промененият запис</param>
        /// <returns>Връща true ако промяната е станала успешно</returns>
        public bool changeRow(Subscriptions s)
        {
            if (!checkIfInside(s))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (Subscriptions n in subsArray)
            {
                if (n.getSubID() == s.getSubID())
                {
                    n.setEndDate(s.getEndDate());
                    
                    if (!subscriptionTable.Update("SUBSCRIPTIONS", n))
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
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="s">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfInside(Subscriptions s)
        {
            foreach (Subscriptions n in subsArray)
            {
                if (n.getUserID() == s.getUserID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Добавяне на нов запис в буферния масив
        /// </summary>
        /// <param name="s">Записът, който добавяме</param>
        private void addNewRecord(Subscriptions s)
        {
            subsArray.Add(s);
        }

    }
}
