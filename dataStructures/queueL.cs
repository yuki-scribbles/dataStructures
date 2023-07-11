using System;

namespace dataStructures
{
    public class queueL <Qtype> : sLinkedList<Qtype>
    {
        //a queue extending singly linked list. Base constuctor makes empty list
        public queueL() : base ()
        {   
        }

        //constructor that adds the first item
        public queueL(Qtype item) : base (item)
        {
        }

        //add an item at the end of the list
        public void Endqueue(Qtype item)
        {
            AddTail(item);
        }

        //removes an item from the front
        public Qtype Dequeue()
        {
            return RemoveHead();
        }
        //returns value of the front item
        public Qtype Peek() {
            return get(0);
        }
    }
}

