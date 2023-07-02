using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{

    public class DoublyLinkedList<T> where T : struct
    {
        public DoublyLinkedListNode<T> head { get; private set; }
        public DoublyLinkedListNode<T> tail { get; private set; }

        public DoublyLinkedListIterator<T> begin()
        {
            return new DoublyLinkedListIterator<T>(head);
        }
        public void PrintList()
        {
            for (DoublyLinkedListIterator<T> itr = begin(); itr.current() != null; itr.next())
            {
                Console.Write($"{itr.current().data} => ");
            }
            Console.WriteLine("\n");
        }
        public DoublyLinkedListNode<T> FindNode(T _data)
        {
            for (DoublyLinkedListIterator<T> itr = new DoublyLinkedListIterator<T>(head); itr.current() != null; itr.next())
            {
                if (itr.current().data.Equals(_data))
                {
                    return itr.current();
                }
            }
            return null;
        }
        public void InsertLast(T _data)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(_data);
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
        public void InsertAfter(DoublyLinkedListNode<T> node, T _data)
        {
            if (node == null) return;
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(_data);
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
        public void InsertAfter(T _existingData, T _newdata)
        {
            DoublyLinkedListNode<T> node = FindNode(_existingData);
            if (node == null) return;
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(_newdata);
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
        public void InsertBefore(DoublyLinkedListNode<T> _node, T _data)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(_data);

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
        public void InsertBefore(T _existingData, T _data)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(_data);
            DoublyLinkedListNode<T> node = FindNode(_existingData);

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

        public void deleteNode(DoublyLinkedListNode<T> node)
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
        public void deleteNode(T _existingData)
        {
            DoublyLinkedListNode<T> node = FindNode(_existingData);
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
    public class DoublyLinkedListNode<T> where T : struct
    {
        public T data;
        public DoublyLinkedListNode<T> next;
        public DoublyLinkedListNode<T> back;
        public DoublyLinkedListNode(T _data)
        {
            data = _data;
            next = null;
            back = null;
        }
    }
    public class DoublyLinkedListIterator<T> where T : struct
    {
        DoublyLinkedListNode<T> currentNode;
        public DoublyLinkedListIterator()
        {
            currentNode = null;
        }
        public DoublyLinkedListIterator(DoublyLinkedListNode<T> _currentNode)
        {
            currentNode = _currentNode;
        }
        public T data()
        {
            return currentNode.data;
        }
        public DoublyLinkedListIterator<T> next()
        {
            currentNode = currentNode.next;
            return this;
        }
        public DoublyLinkedListIterator<T> back()
        {
            currentNode = currentNode.back;
            return this;
        }
        public DoublyLinkedListNode<T> current()
        {
            return currentNode;
        }
    }
}

