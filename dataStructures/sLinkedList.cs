using dataStructures;
using System;
using System.Data;

namespace dataStructures
{
    public class sLinkedList<Ltype>
    {
        private SLnode<Ltype>? head, tail; //References to head and tail node
        private int size; //number of elements in linked list

        //Constructor for a linked list node that has reference to the next and the nodes data
        internal class SLnode<Ltype> : node<Ltype>
        {
            public SLnode<Ltype>? next;
            public SLnode(Ltype val, SLnode<Ltype>? next) : base(val)
            {
                this.next = next;
            }

        }

        //default constructor for a linked list. Makes a size 0 linked list with null reference to head and tail
        public sLinkedList() { 
            head = null;
            tail = null;
            size = 0;
        }

        //constructor for a linked list with the first element
        public sLinkedList(Ltype first) {
            this.head = new SLnode<Ltype> (first,null);
            this.tail = head;
            size = 1;
        }

        //size getter and setter
        public int Size()
        {
            return size;
        }
        public void SetSize(int size)
        {
            this.size = size;
        }

        //gets data of node at pos
        public Ltype get(int pos) {

            //if position is the tail, use tail reference, otherwise, navigate to node from the head
            if (pos >= size)
            {
                throw new IndexOutOfRangeException();
            }
            else if (pos == size - 1) {
                return tail.Data;
            }
            else
            {
                SLnode<Ltype> current = head;
                for (int i = 0; i < pos; i++)
                {
                    current = current.next;
                }
                return current.Data;
            }
        }


        //@param item: value of the newNode to be added
        //@param pos: position 0 index of new node to be added
        public void AddAt(Ltype item, int pos) {

            if (pos > size)
            {
                throw new IndexOutOfRangeException();
            }

            SLnode<Ltype> newNode = new SLnode<Ltype>(item, null);

            //1st case if you're adding at the head and there's already elements, make it refer to old head node and update head reference to newNode. If no elements already, then make head and tail reference to it
            //2nd case: tail. make old tail refer to newNode and then make tail reference to newNode
            //3rd case: in the middle. Go to node right before the position you want NewNode to be at. Make it refer to newNode and make newNode refer to the node after it
            if (pos == 0)
            {
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    newNode.next = head;
                    head = newNode;
                }
            }
            else if (pos == size) {
                tail.next = newNode;
                tail = newNode;
            } 
            else
            {
                SLnode<Ltype> current = head;
                for (int i = 1; i < pos; i++)
                {
                    current = current.next;
                }
                //you move to the node right before the position you want the new node to be

                SLnode<Ltype> temp = current.next;
                current.next = newNode;
                newNode.next = temp;
            }
            size++;
        }

        //adds a node with data @param item at the head
        public void AddHead(Ltype item)
        {
            SLnode<Ltype> newNode = new SLnode<Ltype>(item, null);
            
            //if linked list has no elements, make it the head and tail
            //else, make the new head refer to the old head and update references
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
            size++;
        }

        //adds a node with data value of @param item at the tail
        public void AddTail(Ltype item) {
            SLnode<Ltype> newNode = new SLnode<Ltype>(item, null);

            //if there's no items in the list, make the new node the head and tail
            //else, make the old tail refer to the new node and update tail reference
            if (tail == null) {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            size++;
        }

        public Ltype RemoveTail()
        {
            return RemoveAt(size  - 1);
        }

        //@param pos: position of node you want to remove
        public Ltype RemoveAt(int pos) {
            if (pos >= size)
            {
                throw new IndexOutOfRangeException();
            }

            SLnode<Ltype> current = head;
            SLnode<Ltype> removeNode = current.next;
            
            //if node to be removed is head or after head
            if (pos == 0)
            {   // 2 cases: if there's more than just the head in the list, and if there's only one element
                // 1st case: remove head's refernce to next node and then make the next node the new head
                // 2nd case: make both head and tail reference null
                if (size > 1)
                {
                    head.next = null;
                    head = removeNode;
                }
                else
                {
                    head = null;
                    tail = null;
                }
                SetSize(size - 1);
                return current.Data;
            }
            else {
                //goes to the node right before node you want to remove
                for (int i = 1; i < pos; i++)
                {
                    current = current.next;
                }

                //if the node you want to remove is the tail, update tail to be the current node and make new tail next null
                //else, make current node refer to the node after the node you want to remove and make removed node's next value null
                if (removeNode.next == null)
                {
                    current.next = null;
                    tail = current;
                }
                else
                {
                    SLnode<Ltype> temp = removeNode.next;
                    removeNode.next = null;
                    current.next = temp;
                }

                size--;
                return removeNode.Data;
            }
        }
        public Ltype RemoveHead() {
            SLnode<Ltype> oldHead = head;
            SLnode<Ltype> newHead = oldHead.next;

            if (size == 0) { 
                throw new ArgumentException();
            }
            else if (size > 1){
                head.next = null;
                head = newHead;
            }
            else{
                head = null;
                tail = null;
            }
            size--;
            return oldHead.Data;
        }
        
        //prints the list
        public void printList()
        {
            String print = "[";
                
            if(size > 0)
            {
                print += head.Data;
                SLnode<Ltype> current = head.next;
                while (current != null)
                {
                    print += " -> " + current.Data;
                    current = current.next;
                }
            }          

            print += "]";
            System.Console.WriteLine(print);
        }        


    }
}


