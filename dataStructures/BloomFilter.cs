using System;

using System;
using System.IO;
using System.Security.Cryptography;

namespace dataStructures
{
    public class BloomFilter
    {
        bool[] hashTable;

        //creates a default constructor with 100 bins
        public BloomFilter()
        {
            hashTable = new bool[100];
        }

        //creates a hashTable with numBins amount of bins
        public BloomFilter(int numBins)
        {
            hashTable = new bool[numBins];
        }

        //adds a string by running the item through a hash function, which gives 4 indices. It turns the bits in those positions in hashTable to true if its not true already
        public void Add(string item)
        {
            int[] positions = getBins(item);
            for (int i = 0; i < 4; i++) {
                hashTable[positions[i]] = true;
            }
        }

        //checks if string is already there by running string through hash and checking if the 4 positions the hash function gives are all true. It will give a true negative but may give false positives
        public bool Has(string item)
        {
            int[] positions = getBins(item);
            for (int i = 0; i < 4; i++)
            {
                if(hashTable[positions[i]] = false)
                {
                    return false;
                }
            }

            return true;
        }

        //prints the bloom filter
        public void print()
        {
            string s = "[" + hashTable[0];
            for (int i = 1; i < hashTable.Length; i++)
            {
                s += ", " + hashTable[i];
            }

            Console.WriteLine(s + "]");
        }

        //gets the 4 indice positions needed
        public int[] getBins(string item) {
            int[] binNums = new int[4];

            //Makes an array of MD5
            byte[] MD5 = CreateMD5(item);
            for (int i = 0; i < MD5.Length/2; i ++)
            {
                binNums[0] += MD5[i];
                binNums[0] %= hashTable.Length;
                binNums[0] = Math.Abs(binNums[0]);
            }
            for (int i = MD5.Length / 2; i < MD5.Length; i++)
            {
                binNums[1] += MD5[i];
                binNums[1] %= hashTable.Length;
                binNums[1] = Math.Abs(binNums[1]);
            }
            byte[] SHA256 = CreateSHA256(item);
            for (int i = 0; i < SHA256.Length / 2; i++)
            {
                binNums[2] += SHA256[i];
                binNums[2] %= hashTable.Length;
                binNums[2] = Math.Abs(binNums[2]);
            }
            for (int i = SHA256.Length / 2; i < SHA256.Length; i++)
            {
                binNums[3] += SHA256[i];
                binNums[3] %= hashTable.Length;
                binNums[3] = Math.Abs(binNums[3]);
            }

            return binNums;
        }

        //gets a string and returns a byte array after doing MD5 hash
        public static byte[] CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return hashBytes;
            }
        }

        //gets a string and returns a byte array after doing SHA256
        public static byte[] CreateSHA256(string input) {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                // Compute and print the hash values for each file in directory.
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = mySHA256.ComputeHash(inputBytes);
                return hashBytes;
            }
        }
    }
}

