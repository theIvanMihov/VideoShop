using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoShop.TableClasses;
using VideoShop.Classes;

namespace VideoShop.BufferClasses
{
    class BufferTemplate <T>
    {
        private T t;
        private List<T> dataArray = new List<T>();
        private TableTemplate<T> tableClass = new TableTemplate<T>();

        public BufferTemplate(T t)
        {
            this.t = t;
        }

        public void initializeArray()
        {
            
        }


    }
}
