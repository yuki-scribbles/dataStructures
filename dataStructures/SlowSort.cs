using System;

namespace dataStructures
{
    public class SlowSort
    {
        //takes an array and does insertion sort
        public void insertionSort(int[] arr) {
            int sortPos, key;

            //starting at position 1, for every item in the array, you compare it with the item on the left and keep swapping as long as the item on the left is < the current value.

            for(int i = 1; i < arr.Length; i++)
            {
                sortPos = i - 1;
                key = arr[i];
                
                while (sortPos >= 0 && key < arr[sortPos])
                {
                    arr[sortPos + 1] = arr[sortPos];
                    sortPos--;
                }
                arr[sortPos + 1] = key;
            }

            printArray(arr);
        }

        //method to print an array
        public static void printArray(int[] array)
        {
            string arr = "[";
            arr += array[0];
            for (int i = 1; i < array.Length; i++)
            {
                arr += ", " + array[i];
            }
            arr += "]";
            Console.WriteLine(arr);
        }
    }
}

