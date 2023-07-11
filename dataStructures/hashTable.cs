using System;

namespace dataStructures
{
    public class HashTable <HType>
    {
        sLinkedList<HType>[] hashTable;

        //default hashTable constructor with 100 bins. Also initializes each indice so there's an empty singly linked list
        public HashTable(){
            hashTable = new sLinkedList<HType>[100];
            for (int i = 0; i < 100; i++) {
                hashTable[i] = new sLinkedList<HType>();
            }
        }

        //constructor for hashTable that has numBins amount of bins. Also initializes each indice so there's an empty singly linked list
        public HashTable(int numBins)
        {
            hashTable = new sLinkedList<HType> [numBins];
            for (int i = 0; i < numBins; i++)
            {
                hashTable[i] = new sLinkedList<HType>();
            }
        }

        //adds an item to the hashtable by running a hash function and putting it at the end of the linked list if item doesn't exist in table yet.
        public void Add(HType item) {
            if(Has(item) == false)
            {
                int hash = Math.Abs(item.GetHashCode() % hashTable.Length);
                hashTable[hash].AddTail(item);
            }
        } 

        //removes an item from the table by running it through hash and searching through the bin. If it doesn't exists, return null
        public HType? Remove(HType item) {
            int hash = Math.Abs(item.GetHashCode() % hashTable.Length);
            for (int i = 0; i < hashTable[hash].Size(); i++) {
                if (hashTable[hash].get(i).Equals(item)) { 
                    return hashTable[hash].RemoveAt(i);
                }
            }
            return default(HType);
        }

        //checks if hashtable has an item by running through hash and searhcing through the linked list at the hash position
        public bool Has(HType item)
        {
            int hash = Math.Abs(item.GetHashCode() % hashTable.Length);
            for (int i = 0; i < hashTable[hash].Size(); i++)
            {
                if (hashTable[hash].get(i).Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        //prints each bin
        public void print() { 
            for(int i = 0;i < hashTable.Length;i++)
            {
                hashTable[i].printList();
            }
        }
    }
}
