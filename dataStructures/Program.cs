using dataStructures;
using System;
using System.Collections.Generic;

namespace dataStructures
{    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 9, 2, 10, 3, 6, 1 };

            Heapsort sort = new Heapsort();
            sort.HeapSort(arr);

        }
    }
}
