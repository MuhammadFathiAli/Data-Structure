using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class Stack_ArrayBased
    {
        private int[] list;
        private int topIndex;
        private int initialSize;
        public Stack_ArrayBased()
        {
            initialSize = 5;
            topIndex = -1;
            list = new int[initialSize];
        }
        private void ResizeOrNot()
        {
            if (topIndex < list.Length - 1) return;
            Console.WriteLine("Array will be resized");
            int[] newList = new int[initialSize + list.Length];
            list.CopyTo(newList, 0);
            list = newList;
        }
        public void Push(int _data)
        {
            ResizeOrNot();
            topIndex++;
            list[topIndex] = _data;
        }
        public int Pop()
        {
            if (topIndex == -1) return 0;
            int heapData = list[topIndex];
            list[topIndex] = 0;
            topIndex--;
            return heapData;
        }
        public int Peek()
        {
            if (topIndex == -1) return 0;
            return list[topIndex];
        }
        public bool IsEmpty()
        {
            return topIndex <= 0;
        }
        public int Size()
        {
            return topIndex + 1;
        }
        public void Print()
        {
            for (int i = topIndex; i >= 0; i--)
            {
                Console.Write($"{list[i]} => ");
            }
            Console.WriteLine();
        }
    }
}