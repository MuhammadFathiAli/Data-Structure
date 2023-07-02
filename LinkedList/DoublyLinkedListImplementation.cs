using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{

    public class DoublyLinkedList
    {
        public DoublyLinkedListNode head { get; private set; }
        public DoublyLinkedListNode tail { get; private set; }

        public DoublyLinkedListIterator begin()
        {
            return new DoublyLinkedListIterator(head);
        }
        public void PrintList()
        {
            for (DoublyLinkedListIterator itr = begin(); itr.current() != null; itr.next())
            {
                Console.Write($"{itr.current().data} => ");
            }
            Console.WriteLine("\n");
        }
        public DoublyLinkedListNode FindNode(int _data)
        {
            for (DoublyLinkedListIterator itr = new DoublyLinkedListIterator(head); itr.current() != null; itr.next())
            {
                if (itr.current().data == _data)
                {
                    return itr.current();
                }
            }
            return null;
        }
        public void InsertLast(int _data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(_data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.back = tail;
                tail = newNode;
            }
        }
        public void InsertAfter(DoublyLinkedListNode node, int _data)
        {
            if (node == null) return;
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(_data);
            newNode.next = node.next;
            newNode.back = node;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            else
            {
                newNode.next.back = newNode;
            }
        }
        public void InsertAfter(int _existingData, int _newdata)
        {
            DoublyLinkedListNode node = FindNode(_existingData);
            if (node == null) return;
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(_newdata);
            newNode.next = node.next;
            newNode.back = node;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            else
            {
                newNode.next.back = newNode;
            }
        }
        public void InsertBefore(DoublyLinkedListNode _node, int _data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(_data);

            newNode.next = _node;
            if (_node == head)
            {
                head = newNode;
            }
            else
            {
                _node.back.next = newNode;
                newNode.back = _node.back;
            }
            _node.back = newNode;
        }
        public void InsertBefore(int _existingData, int _data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(_data);
            DoublyLinkedListNode node = FindNode(_existingData);

            newNode.next = node;
            if (node == head)
            {
                head = newNode;
            }
            else
            {
                node.back.next = newNode;
                newNode.back = node.back;

            }
            node.back = newNode;
        }

        public void deleteNode(DoublyLinkedListNode node)
        {
            if (node == null) return;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if (head == node)
            {
                head = node.next;
                node.next.back = null;
            }
            else
            {
                if (tail == node)
                {
                    tail = node.back;
                    node.back.next = null;
                }
                else
                {
                    node.back.next = node.next;
                    node.next.back = node.back;
                }
            }
        }
        public void deleteNode(int _existingData)
        {
            DoublyLinkedListNode node = FindNode(_existingData);
            if (node == null) return;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if (head == node)
            {
                head = node.next;
                node.next.back = null;
            }
            else
            {
                if (tail == node)
                {
                    tail = node.back;
                    node.back.next = null;
                }
                else
                {
                    node.back.next = node.next;
                    node.next.back = node.back;
                }
            }
        }
    }
    public class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode back;
        public DoublyLinkedListNode(int _data)
        {
            data = _data;
            next = null;
            back = null;
        }
    }
    public class DoublyLinkedListIterator
    {
        DoublyLinkedListNode currentNode;
        public DoublyLinkedListIterator()
        {
            currentNode = null;
        }
        public DoublyLinkedListIterator(DoublyLinkedListNode _currentNode)
        {
            currentNode = _currentNode;
        }
        public int data()
        {
            return currentNode.data;
        }
        public DoublyLinkedListIterator next()
        {
            currentNode = currentNode.next;
            return this;
        }
        public DoublyLinkedListIterator back()
        {
            currentNode = currentNode.back;
            return this;
        }
        public DoublyLinkedListNode current()
        {
            return currentNode;
        }
    }
}

