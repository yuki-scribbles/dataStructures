using System;

namespace dataStructures
{
    public class Heapsort
    {
        dynamicArray<int> heapArray;
        //dynamicArray for implementing array form of heap
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
                swap(1, heapArray.Size());
                heapArray.printArray();
                int temp = heapArray.remove(heapArray.Size() - 1);
                bubbleDown(1);
                return temp;
            }
        }

        //method to sort an array. takes the array and adds each item onto the heapArray
        public void HeapSort(int[] arr)
        {   
            //refreshes the heapArray if there's any elements
            heapArray = new dynamicArray<int> (arr.Length);

            //Adds each item of arr into the heap
            foreach (int item in arr) {
                Add(item);
            }

            //Removes the greatest item from HeapArray onto the arr and repeats until all items are sorted
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Next();
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

        //swaps a parent with the greater of its children
        void bubbleDown(int pos)
        {   //you stop if the node is a leaf. If pos is out of bounds, you exit
            if (pos * 2 > heapArray.Size() )
            {
                return;
            }
            else if (pos < 0 || pos > heapArray.Size())
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


        //swaps 2 items at i and j position in 1 index
        void swap(int i, int j) {
            int temp = heapArray.get(i - 1);
            heapArray.Set(heapArray.get(j - 1), i - 1);
            heapArray.Set(temp, j - 1);
        }


    }
}

