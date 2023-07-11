using System;

namespace dataStructures
{
    public class Store
    {   //you have an array to store all of the lines, size is numLines.
        line[] lines;
        int numCustomers, numLines;

        //constructor will set values of class variables and also run a simulation to print out the store
        public Store(int numLines, int numCustomers)
        {   this.numLines = numLines;
            lines = new line[numLines];
            this.numCustomers = numCustomers;
            simulate();
        }
        
        //prints a simulation of a store
        public void simulate()
        {   
            //populates the newly created lines evenly with customers. Customers have a randomized number of items from 5-25
            var rand = new Random();
            
       
            for (int i = 0; i < numLines; i++)
            {
                lines[i] = new line();
                for(int j  = 0; j < numCustomers/numLines; j++)
                {
                  lines[i].Enq_back(new Customer(rand.Next(5,25)));
                }
            }
            
            //if number of customers doesn't evenly distribute, have the rest of them in the first line
            for (int i = 0; i < numCustomers % numLines; i++) {
                lines[0].Enq_back(new Customer(rand.Next(5, 25)));
            } 
            
            //You continue rounds until there's no more customer
            while (numCustomers > 0) { 
                //for loop runs through each line
                for(int i = 0;i < numLines; i++)
                {   //if there aren't any customers in the line , grab a customer from the back of another line if the line has more than 1 customer
                    if (lines[i].getSize() == 0)
                    {
                        //if line size == 0 and if theres another line with >2 items, steal an item onto there
                        for (int j = 0; j < numLines; j++)
                        {   
                            if (lines[j].getSize() > 2) {
                                Customer transfer = lines[j].Deq_back();
                                lines[i].Enq_back(transfer);
                                break;
                            }
                        }
                    }
                    //check if there's any customers in the line after possibly customer stealing
                    //if items == 0 remove customer and numCustomer --
                    if (lines[i].getSize() > 0)
                    {
                        lines[i].Peek().setItems(lines[i].Peek().getItems() - 1);
                        if (lines[i].Peek().getItems() == 0)
                        {
                            lines[i].Deq_front();
                            numCustomers--;
                        }
                    }
                    
                }
                
                //prints out each line per round
                for (int a = 0; a < numLines; a++) { 
                    Console.WriteLine("line " + (a + 1) + ": " + lines[a].printLine());
                }
                Console.WriteLine("\n---------------------------------------------");
            }
        }
        
    }
}

       