using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31
{
    class DBItem <T>
    {
        public List<T> Items { get; set; }
        public DBItem()
        {
            this.Items = new List<T>();
        }
        public void AddItem(T item) 
        {
            Items.Add(item);
        }
    }
}
