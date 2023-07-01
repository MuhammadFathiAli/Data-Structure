using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class LinkedList
    {
        LinkedListNode head;
        LinkedListNode tail;
        public LinkedListIterator begin()
        {
            return new LinkedListIterator(head);
        }
        public void PrintList()
        {
            for (LinkedListIterator itr = begin(); itr.current() != null; itr.next())
            {
                Console.WriteLine($"DATA : {itr.current().data}");
            }
        }
        public void InsertLast(int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }
    }
    public class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode(int _data)
        {
            data = _data;
            next = null;
        }
    }
    public class LinkedListIterator
    {
        LinkedListNode currentNode;
        public LinkedListIterator()
        {
            currentNode = null;
        }
        public LinkedListIterator(LinkedListNode _currentNode)
        {
            currentNode = _currentNode;
        }
        public int data()
        {
            return currentNode.data;
        }
        public LinkedListIterator next()
        {
            currentNode = currentNode.next;
            return this;
        }
        public LinkedListNode current()
        {
            return currentNode;
        }
    }
}
