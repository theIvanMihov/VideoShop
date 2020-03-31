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
    class ServicesNamesBuffer
    {
        private TableTemplate<ServicesNames> servicesTable = new TableTemplate<ServicesNames>();
        private List<Object> servicesArray = new List<Object>();

        public ServicesNamesBuffer()
        {

        }

        /// <summary>
        /// Функция за връщане на пълният масив
        /// </summary>
        /// <returns>Връща масив от обекти</returns>
        public List<Object> returnRecords()
        {
            return servicesArray;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeServicesArray()
        {
            if (!servicesTable.Select("SERVICES", servicesArray))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Функция за добавяне на запис 
        /// </summary>
        /// <param name="s">Записът, който ще добавяме</param>
        /// <returns>Връща true ако записът е добавен успешно</returns>
        public bool insertRow(ServicesNames s)
        {
            if (!checkDuplicateRecord(s))
            {
                MessageBox.Show("Този град вече съществува.");
                return false;
            }

            if (!servicesTable.Insert("SERVICES", s))
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
        public bool changeRow(ServicesNames s)
        {
            if (!checkIfInside(s))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (ServicesNames n in servicesArray)
            {
                if (n.getServID() == s.getServID())
                {
                    n.setServName(s.getServName());
                    n.setServPrice(s.getServPrice());
                    if (!servicesTable.Update("SERVICES", n))
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
        /// <param name="s">Записът, който ще премахваме</param>
        /// <returns>Връща true ако премахването е успешно</returns>
        public bool removeRecord(ServicesNames s)
        {

            if (!checkIfInside(s))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (ServicesNames n in servicesArray)
            {
                if (n.getServName() == s.getServName())
                {
                    s.setServID(n.getServID());
                    servicesArray.Remove(n);
                    if (!servicesTable.Delete(s))
                    {
                        MessageBox.Show("no");
                        return false;
                    }

                }
            }

            MessageBox.Show("yes");
            return true;
        }

        /// <summary>
        /// Проверка дали записът съществува в масива
        /// </summary>
        /// <param name="s">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfInside(ServicesNames s)
        {
            foreach (ServicesNames n in servicesArray)
            {
                if (n.getServID() == s.getServID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверява дали има дублиращ запис
        /// </summary>
        /// <param name="s">Записът, който проверяваме</param>
        /// <returns>Връща true ако записът не се дублира</returns>
        private bool checkDuplicateRecord(ServicesNames s)
        {
            foreach (ServicesNames n in servicesArray)
            {
                if (n.getServName() == s.getServName())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Добавяне на нов запис в буферния масив
        /// </summary>
        /// <param name="s">Записът, който добавяме</param>
        private void addNewRecord(ServicesNames s)
        {
            servicesArray.Add(s);
        }


    }
}
