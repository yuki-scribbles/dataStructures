using System;

namespace dataStructures
{
    public class stackL<Stype> : sLinkedList<Stype>
    {
        //stack extends singly linked list
        
        //base constructor with empty stack
        public stackL():base()
        {
        }

        //constructor with one item stack
        public stackL(Stype value) : base(value)
        {
        }
        
        //adds item at the top of stack
        public void Push(Stype item)
        {
            AddHead(item);
        }

        //removes item at the top of stack
        public Stype Pop()
        {
            return RemoveHead();
        }

        //looks at value of top item.
        public Stype Peek()
        {
            return get(0);
        }
    }
}

