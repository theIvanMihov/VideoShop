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
    class EmployeesBuffer
    {
        private TableTemplate<Employees> employeesTable = new TableTemplate<Employees>();
        private List<Object> employeesArray = new List<Object>();

        public EmployeesBuffer()
        {

        }

        /// <summary>
        /// Функция за връщане на пълният масив
        /// </summary>
        /// <returns>Връща масив от обекти</returns>
        public List<Object> returnRecords()
        {
            return employeesArray;
        }

        /// <summary>
        /// Взима данните от базата данни и ги записва в буферния масив
        /// </summary>
        /// <returns>Връща true ако всички данни са добавени успешно</returns>
        public bool initializeServicesArray()
        {
            if (!employeesTable.Select("EMPLOYEES", employeesArray))
            {
                MessageBox.Show("Неуспешно зареждане на данните");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Функция за добавяне на запис 
        /// </summary>
        /// <param name="e">Записът, който ще добавяме</param>
        /// <returns>Връща true ако записът е добавен успешно</returns>
        public bool insertRow(Employees e)
        {
            if (!checkDuplicateRecord(e))
            {
                MessageBox.Show("Този град вече съществува.");
                return false;
            }

            if (!employeesTable.Insert("EMPLOYEES", e))
            {
                MessageBox.Show("Неуспешен опит за извършване на операцията. ");
                return false;
            }

            addNewRecord(e);
            return true;
        }

        /// <summary>
        /// Функция за промяна на запис
        /// </summary>
        /// <param name="s">Вече промененият запис</param>
        /// <returns>Връща true ако промяната е станала успешно</returns>
        public bool changeRow(Employees e)
        {
            if (!checkIfInside(e))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (Employees n in employeesArray)
            {
                if (n.getID() == e.getID())
                {   
                    n.setFirstName(e.getFirstName());
                    n.setLastName(e.getLastName());
                    n.setSalary(e.getSalary());
                    n.setPhone(e.getPhone());
                    n.setPos(e.getPos());
                    n.setCity(e.getCity());
                    if (!employeesTable.Update("EMPLOYEES", e))
                    {
                        MessageBox.Show("no");
                        return false;
                    }
                    break;
                }
            }
            return true;
        }


        /// <summary>
        /// Премахване на запис
        /// </summary>
        /// <param name="s">Записът, който ще премахваме</param>
        /// <returns>Връща true ако премахването е успешно</returns>
        public bool removeRecord(Employees e)
        {

            if (!checkIfInside(e))
            {
                MessageBox.Show("Не можe");
                return false;
            }

            foreach (Employees n in employeesArray)
            {
                if (n.getID() == e.getID())
                {                    
                    employeesArray.Remove(n);
                    if (!employeesTable.Delete(e))
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
        /// <param name="s">Записът, който търсим</param>
        /// <returns>Връща true ако записът съществува </returns>
        private bool checkIfInside(Employees e)
        {
            foreach (Employees n in employeesArray)
            {
                if (n.getID() == e.getID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверява дали има дублиращ запис
        /// </summary>
        /// <param name="e">Записът, който проверяваме</param>
        /// <returns>Връща true ако записът не се дублира</returns>
        private bool checkDuplicateRecord(Employees e)
        {
            foreach (Employees n in employeesArray)
            {
                if (n.getID() == e.getID())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Добавяне на нов запис в буферния масив
        /// </summary>
        /// <param name="e">Записът, който добавяме</param>
        private void addNewRecord(Employees e)
        {
            employeesArray.Add(e);
        }
    }
}
