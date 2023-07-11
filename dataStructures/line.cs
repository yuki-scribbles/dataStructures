
namespace dataStructures
{
    public class line
    {
        sLinkedList<Customer> queue;
        //the double ended customer queue will be implemented using a single linked list

        //constructor to create a line
        public line()
        {
            queue = new sLinkedList<Customer>();
        }

        //adds @param customer to the back of the line
        public void Enq_back(Customer customer)
        {
            queue.AddTail(customer);
        }

        //removes a customer from the front and returns the customer
        public Customer Deq_front()
        {
            return queue.RemoveHead();
        }

        //removes a customer from the back and returns the customer
        public Customer Deq_back()
        {
            return queue.RemoveTail();
        }

        //looks at the customer in front of the line
        public Customer Peek()
        {
            return queue.get(0);
        }

        //gets size of the queue
        public int getSize()
        {
            return queue.Size();
        }

        //prints the queue
        public string printLine() {
            String print = "";

            if (queue.Size() > 0)
            {
                print += "C1: " + queue.get(0).getItems();
                for (int i = 1; i < queue.Size(); i++)
                {
                    print += ", C" + (i + 1) + ": " + queue.get(i).getItems();
                }
                
            }
            return print;
        }
    }
}

