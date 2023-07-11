using System;

namespace dataStructures {
    public class queueA <Qtype> : dynamicArray <Qtype>
    {
        public queueA(int size):base(size) 
        {
        }
        public void Endqueue(Qtype item) {
            AddEnd(item);
        }
        public Qtype Dequeue() {
            return remove(0);
        }
        public Qtype Peek() {
            return get(0);
        }
        public int Size()
        {
            return Size();
        }
    }
}

