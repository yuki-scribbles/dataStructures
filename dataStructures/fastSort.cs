using System;

namespace dataStructures
{
    public class fastSort
    {

        public void quickSort(int[] array) { 
            quicksorting(array, 0, array.Length);
        }

        //it recursively quick sorts 2 separate sections of the array
        public static void quicksorting(int[] array, int from, int to)
        {
            if (from >= to) { return; }
            int p = partition(array, from, to);
            quicksorting(array, from, p);
            quicksorting(array, p + 1, to);
        }

        //partitions into 2 sections: one greater than the pivot and ones less than. Sorts from position int from to position int to
        private static int partition(int[] a, int from, int to) {
            
            int pivot = a[from];
            int i = from - 1;
            int j = to + 1;


            while (i < j) {
                //from the left side of the partition, move right until you reach a number greater than the pivot
                i++;
                while (a[i] < pivot) {
                    i++;
                }

                //from the right side, move left until you reach a number less than partitaion
                j--;
                while (a[i] > pivot)
                {
                    j--;
                }

                //switch the two values if the two poitns still haven't touched each other.
                if (i < j)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }

            }
            
            return j;
        }
    }
}

