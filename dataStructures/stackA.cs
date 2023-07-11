using System;

namespace dataStructures {
    public class stackA<Stype> : dynamicArray<Stype>{
        public stackA(int size):base(size)
        {
        }
        public void Push(Stype item) { 
            AddEnd(item);
        }
        public Stype Pop()
        {
            return remove(Size()  - 1);
        }
        public Stype Peek() {
            return get(Size() - 1);
        }
        public int Size() {
            return Size();
        }
    }
}
