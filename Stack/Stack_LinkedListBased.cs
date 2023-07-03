using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class Stack_LinkedListBased<T> where T : struct
    {
        public LinkedList<T> list { private get; private set; }
        public Stack_LinkedListBased()
        {
            list = new LinkedList<T>(true);
        }
        public void Push(T _data)
        {
            list.InsertFirst(_data);
        }
        public T Pop()
        {
            if (IsEmpty()) return null;
            T data = list.head.data;
            list.DeleteHead();
            return data;
        }
        public T Peek()
        {
            if (IsEmpty()) return null;
            return list.head.data;
        }
        public bool IsEmpty()
        {
            return list.Length <= 0;
        }
        public int Size()
        {
            return list.Length;
        }
        public void Print()
        {
            list.PrintList();
        }

    }
}
