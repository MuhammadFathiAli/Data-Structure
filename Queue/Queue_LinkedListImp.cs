using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class Queue_LinkedListBased<T> 
    {
        public LinkedList<T> list { get; private set; }
        public Queue_LinkedListBased()
        {
            list = new LinkedList<T>(true);
        }
        public void Enqueue(T _data)
        {
            list.InsertLast(_data);
        }
        public T Dequeue()
        {
            T data = list.head.data;
            list.DeleteHead();
            return data;
        }
        public T Peek()
        {
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
