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
      
        public T AddItem(T item) 
        {
            Items.Add(item);
            return Items[Items.Count - 1];
        }

        public T FindById(int id)
        {
            foreach (T item in Items)
            {
                IItem iItem = (IItem)item;
                if (iItem.Id == id) return item;
            }

            throw new ArgumentException("did not find object with this id", "id");
            return default(T);
        }

        public void Update(T item)
        {
            int itemIndex = Items.FindIndex(i => { IItem it = (IItem)i;
                                                    IItem uit = (IItem)item;
                                                    return it.Id == uit.Id; });
            if (itemIndex == -1) throw new ArgumentException("didn`t find item with this id", "item");
            Items[itemIndex] = item;
        }

        public void Delete(int idx)
        {
            //Console.WriteLine("-->" + idx);
            int itemIndex = Items.FindIndex(i => {
                IItem it = (IItem)i;
                return it.Id == idx;
            });
            //Console.WriteLine("<--" + itemIndex);
            if (itemIndex == -1) throw new ArgumentException("didn`t find item with this id", "item");
            Items.RemoveAt(itemIndex);
        }
    }
}
