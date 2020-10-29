using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    //singleton Class
    class DBItem <T>
    {
        private static DBItem<T> dbItem = null;

        public List<T> Items { get; set; }

        private DBItem() //have to use istance!!!
        {
            this.Items = new List<T>();
        }

        //init db
        public static DBItem<T> DBInstance()
        {
            if(dbItem == null)
            {
                dbItem = new DBItem<T>();
            }
            return dbItem;
        }
      
        public void AddItem(T item) 
        {
            Items.Add(item);
        }

        public T FindById(int id)
        {
            foreach (T item in Items)
            {
                IItem iItem = (IItem)item;
                if (iItem.Id == id) return item;
            }

            return default(T);
        }
    }
}
