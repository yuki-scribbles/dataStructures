using System;

namespace dataStructures { 
	public class node <T>
	{
		private T data;
        public node(T val){
            data = val;
        }

        /**
         * Shorthand to create a Getter and Setter method for Data
         */
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}

