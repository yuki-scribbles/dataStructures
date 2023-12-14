using System;
using System.Drawing;

namespace dataStructures
{
    public class Heapsort
    {
        dynamicArray<int> heapArray;
        //dynamicArray for implementing array form of max heap
        public Heapsort()
        {   //creates a dynamic array with default size of 10 elements
            heapArray = new dynamicArray<int>(10);
        }

        //adds an item at the end of the array and swaps up higher if needed
        public void Add(int item) { 
            heapArray.AddEnd(item);
            bubbleUp(heapArray.Size());
        }

        //takes the last item of the array, swaps it with the first item that gets removed, and then bubbles the first item down if needed. returns the removed item
        public int Next()
        {   if (heapArray.Size() == 0) {
                throw new IndexOutOfRangeException();
            }
            if (heapArray.Size() == 1)
            {
                return heapArray.remove(0);
            }
            else { 
                Console.WriteLine("swapped: " + heapArray.get(0) + " " + heapArray.get(heapArray.Size() - 1));
                Console.WriteLine("Size: " + heapArray.Size());
                swap(1, heapArray.Size());
                heapArray.printArray();
                int temp = heapArray.remove(heapArray.Size() - 1);
                bubbleDown(1);
                heapArray.printArray();
                Console.WriteLine("deleted: " + temp);
                return temp;
            }
        }

        //method to sort an array. takes the array and adds each item onto the heapArray
        public void HeapSort(int[] arr)
        {   
            //copies array to dynamic array
            heapArray = new dynamicArray<int> (arr);

            //make to heap array
            Heapify();
            int[] newArr = new int[arr.Length];
            //remove elements from heap and move them onto original array
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = Next();
            }

            //copy array to heap array again
            heapArray = new dynamicArray<int>(newArr);
            heapArray.printArray();
            /*
            //Adds each item of arr into the heap
            foreach (int item in arr) {
                Add(item);
            }
            //Removes the greatest item from HeapArray onto the arr and repeats until all items are sorted
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Next();
            }*/
        }
        
        void Heapify()
        {
            for (int i = heapArray.Size() / 2; i > 0; i--)
            {
                bubbleDown(i);
            }
        }


        //runs through the heapsort on the HeapArray and returns enumerable ints
        public IEnumerable<int> SortedVals()
        {
            for (int i = 0; i < heapArray.Size(); i++)
            {
                yield return Next();
            }
        }

        //swaps an item with its parent if item is less than parent. pos of item in 1 index.
        void bubbleUp(int pos) {
            //stop once you reach first item, and throw index out of range exception if position is outside of array bounds
            if (pos == 1) {
                return;
            }
            else if (pos < 1 || pos > heapArray.Size())
            {
                throw new IndexOutOfRangeException();
            }

            //if parent is less than child, swap
            if (heapArray.get(pos/2 - 1) < heapArray.get(pos - 1))
            {
                swap(pos / 2, pos);
                bubbleUp(pos / 2);
            } else
            {
                return;
            }
        }

        /*
        //swaps a parent with the greater of its children
        //pos 1 system
        void bubbleDown(int pos)
        {   //you stop if the node is a leaf. If pos is out of bounds, you exit
            if (pos * 2 > heapArray.Size() )
            {
                return;
            }
            else if (pos <= 0 || pos > heapArray.Size())
            {
                throw new ArgumentOutOfRangeException();
            }

            //2 cases: if there's 2 children and only left child.
            if (pos * 2 + 1 <= heapArray.Size())
            {
                //check which child is greater
                //if right child is the bigger number or if left child is bigger
                if (heapArray.get(pos * 2 - 1) < heapArray.get(pos * 2))
                {

                    //if right child is bigger than the parent, initiate swap
                    if (heapArray.get(pos - 1) < heapArray.get(pos * 2))
                    {
                        swap(pos, pos * 2 + 1);
                        bubbleDown(pos * 2 + 1);
                        
                    }
                    else
                    {
                        return;
                    }
                }
                else {

                    //if left child is bigger than the parent, initiate swap
                    if (heapArray.get(pos - 1) < heapArray.get(pos * 2 - 1))
                    {
                        swap(pos, pos * 2);
                        bubbleDown(pos * 2);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else {
                //checks if only left child is greater than the parent
                if (heapArray.get(pos - 1) < heapArray.get(pos * 2 - 1))
                {
                    swap(pos, pos * 2);
                    bubbleDown(pos * 2);
                }
                else
                {
                    return;
                }
            }
        }
        */

        //brings root down to its right place. 1 index
        void bubbleDown(int root) {
            
            int bottom = heapArray.Size();
            if (root <= 0 || root > bottom)
            {
                throw new ArgumentOutOfRangeException();
            }

            //get left child
            int minChild = root * 2;
            //if leaf node, return
            //If there's also a right child
            //*If it was just left child, it would be last possible pos bottom
            if (minChild > bottom)
            {
                return;
            }
            else if (minChild < bottom)
            {
                if (heapArray.get(minChild) > heapArray.get(minChild - 1))
                {
                    minChild++;
                }
            }
            
            if (heapArray.get(root - 1) >= heapArray.get(minChild - 1))
            {
                return;
            }
            swap(minChild, root);
            //heapArray.printArray();
            bubbleDown(minChild);

        }

        //swaps 2 items at i and j position in 1 index
        void swap(int i, int j) {
            int temp = heapArray.get(i - 1);
            heapArray.Set(heapArray.get(j - 1), i - 1);
            heapArray.Set(temp, j - 1);
        }


    }
}

