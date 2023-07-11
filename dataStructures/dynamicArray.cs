using System;
using System.ComponentModel;

namespace dataStructures {
    public class dynamicArray<Atype>
    {
        private int size; //size of the whole array, including empty spaces
        Atype[] array; 
        private int numElements; //number of elements inside the array

        //creates an empty array of a certain size to be filled
        public dynamicArray(int size){
            array = new Atype[size];
            this.size = size;
            numElements = 0;
        }

        /* @Param item: data of new item
         * @param pos: position you want to add item at. If there's already an item there, it'll push the item and everything after it +1 position.
         */
        public void Add(Atype item, int pos){
            //2 cases: Outside of input bounds, and inside bounds
            if (pos > numElements || pos < 0) {
                throw new ArgumentOutOfRangeException();
            } else {
                if (numElements == size)
                {
                    SizeUp(15);
                }
                
                //Shift other elements to place the new item
                ShiftDown(pos);
                array[pos] = item;
                numElements++;
            }
        }

        /*@param pos: position of item you want to remove
         */
        public Atype remove(int pos) {
            if (pos >= numElements || pos < 0){
                throw new ArgumentOutOfRangeException();
            }
            else{
                Atype temp = array[pos];
                ShiftUp(pos);
                numElements--;
                //If there's alot of gaps, size the array down
                if (numElements <= size - 20) {
                    SizeDown();
                }
                return temp;
            }
        }

        //gets value of item at [pos]
        public Atype get(int pos){
            if (pos >= numElements|| pos < 0){
                throw new ArgumentOutOfRangeException();
            }
            else{
                return array[pos];
            }
        }

        //Swaps the item at [pos] with another value
        public Atype Set(Atype val, int pos){
            if (pos >= numElements || pos < 0){
                throw new ArgumentOutOfRangeException();
            }
            else{
                Atype temp = array[pos];
                array[pos] = val;
                return temp;
            }
        }

        //size getter
        public int Size() {
            return (numElements);
        }

        //shifts all elements right of pos to go down one position
        public void ShiftDown(int pos){
            int shiftPos = numElements;
            while (shiftPos > pos){
                array[shiftPos] = array[shiftPos - 1];
                shiftPos --;
            }
        }

        //shifts all elements right of pos to go up one position
        public void ShiftUp(int pos) {
            int shiftPos = pos;
            while (shiftPos < numElements - 1){
                array[shiftPos] = array[shiftPos + 1];
                shiftPos++;
            }
        }

        //increases size of array
        public void SizeUp(int upgrade){
            Atype[] large = new Atype[size + upgrade];
            for (int i = 0; i < size; i++) {
                large[i] = array[i];
            }
            array = large;
            size += upgrade;
        }

        //decreases size of array
        public void SizeDown()
        {
            Atype[] large = new Atype[size - 10];
            for (int i = 0; i < size; i++)
            {
                large[i] = array[i];
            }
            array = large;
            size -= 10;
        }

        //prints the part of the array that has items
        public void printArray() {
            //*try to implement it so it'll work for general objects
        
            string list = "[";
            if (numElements != 0)
            {
                list += array[0];
            }

            for(int i = 1; i < numElements; i++){
                list += ", " + array[i];
            }
            list += "]";

            Console.WriteLine(list);
        }
        public void AddEnd(Atype val) {
            Add(val, numElements);
        }
        public void AddBeginning(Atype val) {
            Add(val, 0);
        }
    }
}

