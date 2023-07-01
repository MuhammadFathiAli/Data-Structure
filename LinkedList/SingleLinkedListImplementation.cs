﻿using System;
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
                Console.Write($"{itr.current().data} => ");
            }
            Console.WriteLine("\n");
        }
        public LinkedListNode FindNode(int _data)
        {
            for (LinkedListIterator itr = new LinkedListIterator(head); itr.current() != null; itr.next())
            {
                if (itr.current().data == _data)
                {
                    return itr.current();
                }
            }
            return null;
        }
        private LinkedListNode FindParentNode(LinkedListNode node)
        {
            for (LinkedListIterator itr = new LinkedListIterator(head); itr.current() != null; itr.next())
            {
                if (itr.current().next == node)
                {
                    return itr.current();
                }
            }
            return null;
        }
        public LinkedListNode FindParentNode(int _existingData)
        {
            LinkedListNode node = new LinkedListNode(_existingData);
            for (LinkedListIterator itr = new LinkedListIterator(head); itr.current() != null; itr.next())
            {
                if (itr.current().next.data == node.data)
                {
                    return itr.current();
                }
            }
            return null;
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
        public void InsertAfter(LinkedListNode node, int _data)
        {
            if (node == null) return;
            LinkedListNode newNode = new LinkedListNode(_data);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
        }
        public void InsertAfter(int _existingData, int _newdata)
        {
            LinkedListNode node = FindNode(_existingData);
            if (node == null) return;
            LinkedListNode newNode = new LinkedListNode(_newdata);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
        }
        public void InsertBefore(LinkedListNode _node, int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            LinkedListNode parentNode = FindParentNode(_node);

            newNode.next = _node;
            if (parentNode == null)
            {
                head = newNode;
            }
            else
            {
                parentNode.next = newNode;
            }
        }
        public void InsertBefore(int _existingData, int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            LinkedListNode node = FindNode(_existingData);
            LinkedListNode parentNode = FindParentNode(_existingData);

            newNode.next = node;
            if (parentNode == null)
            {
                head = newNode;
            }
            else
            {
                parentNode.next = newNode;
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
