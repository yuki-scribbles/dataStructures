using System;

namespace dataStructures
{
    public class SlowSort
    {
        //takes an array and does insertion sort
        static public void insertionSort(int[] arr) {
            int sortPos, key;

            //starting at position 1, for every item in the array, you compare it with the item on the left and keep swapping as long as the item on the left is < the current value.
            int comparisons = 0;
            int swaps = 0;

            for(int i = 1; i < arr.Length; i++)
            {
                sortPos = i - 1;
                key = arr[i];
                printArray(arr);
                Console.WriteLine("swaps: " + swaps + " comparisons: " + comparisons);
                
                if(!(sortPos >= 0 && key < arr[sortPos]))
                {
                    comparisons++;
                    swaps++;
                }
                while (sortPos >= 0 && key < arr[sortPos])
                {
                    swaps++;
                    comparisons++;
                    arr[sortPos + 1] = arr[sortPos];
                    sortPos--;
                }
                arr[sortPos + 1] = key;
            }

            printArray(arr);
            Console.WriteLine("swaps: " + swaps + " comparisons: " + comparisons);
        }

        //method to print an array
        static public void bubbleSortt(int[] arr) {
            int i, j, temp;

            int comp = 0;
            int swaps = 0;
            //bool swapped;
            for (i = 0; i < arr.Length - 1; i++)
            {
                //swapped = false;
                for (j = 0; j < arr.Length - i - 1; j++)
                {
                    comp++;
                    printArray(arr);
                    Console.WriteLine("compared: " + arr[j] + ", " + arr[j + 1] + " comparisons: " + comp + " . Swaps: " + swaps);
                    if (arr[j] > arr[j + 1])
                    {
                        swaps++;
                        // Swap arr[j] and arr[j+1]
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        //swapped = true;
                    }
                }

                // If no two elements were
                // swapped by inner loop, then break
                //if (swapped == false)
                //    break;
            }

        }

        public static void selectionSort(int[] array)
        {
            //First round finds the smallest number to place at the beginning of array
            int swaps = 0;
            int comparisons = 0;
            for (int i = 0; i < array.Length; i++)
            {
                /*each round will move up one position of the array, compares it to
                the rest of the array right of the position to find the min, and then 
                swaps the two values
                */
                int minIndex = i;
                comparisons++;
                for (int j = i + 1; j < array.Length; j++)
                {
                    comparisons++;
                    if (array[j] < array[i])
                    {
                        minIndex = j;
                    }
                }
                //swapping the two values
                swaps++;
                int smallerValue = array[minIndex];
                array[minIndex] = array[i];
                array[i] = smallerValue;
                printArray(array);
                Console.WriteLine("swaps: " + swaps + " comparisons: " + comparisons);
            }
            printArray(array);
            Console.WriteLine("swaps: " + swaps + " comparisons: " + comparisons);
        }

        public static void exchangeSort(int[] num)
        {
            int i, j, temp;
            int comparisons = 0;
            int swaps = 0;
            for (i = 0; i < num.Length - 1; i++)
            {

                // Outer Loop
                comparisons++;
                for (j = i + 1; j < num.Length; j++)
                {

                    // Inner Loop
                    // Sorting into ascending order if previous
                    // element bigger than next element we swap
                    // to make it in ascending order
                    comparisons++;
                    if (num[i] > num[j])
                    {

                        // Swapping
                        swaps++;
                        temp = num[i];
                        num[i] = num[j];
                        num[j] = temp;
                    }
                }
                printArray(num);
                Console.WriteLine("swaps: " + swaps + " comparisons: " + comparisons);
            }
        }
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

