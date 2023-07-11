using System;

namespace dataStructures {
    public class Customer
    {
        public int items;
        
        //constructor to set customers amount of items
        public Customer(int items)
        {
            this.items = items;
        }
        
        //getter and setter for items
        public int getItems()
        {
            return items;
        }

        public void setItems(int items) { 
            this.items = items;
        }

    }
}

