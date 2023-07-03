using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class Queue_ArrayImp
    {
        private int[] list;
        private int topIndex;
        private int lastIndex;
        private int initialSize;
        public Queue_ArrayImp()
        {
            initialSize = 5;
            topIndex = -1;
            lastIndex = -1;
            list = new int[initialSize];
        }
        private void ResizeOrNot()
        {
            if (lastIndex < list.Length - 1) return;
            Console.WriteLine("Array will be resized");
            int[] newList = new int[initialSize + list.Length];
            list.CopyTo(newList, 0);
            list = newList;
        }
        public void Enqueue(int _data)
        {
            ResizeOrNot();
            if (topIndex < 0) topIndex++;
            lastIndex++;
            list[lastIndex] = _data;
        }
        public int Dequeue()
        {
            if (lastIndex > list.Length - 1) return 0;
            int data = list[topIndex];
            list[topIndex] = 0;
            topIndex++;
            return data;
        }
        public int Peek()
        {
            return list[topIndex];
        }
        public bool IsEmpty()
        {
            return lastIndex <= 0;
        }
        public int Size()
        {
            return lastIndex - topIndex + 1;
        }
        public void Print()
        {
            for (int i = topIndex; i <= lastIndex; i++)
            {
                Console.Write($"{list[i]} => ");
            }
            Console.WriteLine();
        }

    }
}
