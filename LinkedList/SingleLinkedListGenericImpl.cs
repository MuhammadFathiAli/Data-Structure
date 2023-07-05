using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> head { get; private set; }
        public LinkedListNode<T> tail { get; private set; }
        public int Length { get; private set; }
        public bool isUnique { get; private set; }

        public LinkedList()
        {
        }
        public LinkedList(bool _isUnique)
        {
            isUnique = _isUnique;
        }
        public void PrintList()
        {
            for (LinkedListIterator<T> itr = begin(); itr.current() != null; itr.next())
            {
                Console.Write($"{itr.current().data} => ");
            }
            Console.Write($"Length : {Length}");
            Console.WriteLine("\n");
        }
        public LinkedListIterator<T> begin()
        {
            return new LinkedListIterator<T>(head);
        }
        public LinkedListNode<T> FindNode(T _data)
        {
            for (LinkedListIterator<T> itr = new LinkedListIterator<T>(head); itr.current() != null; itr.next())
            {
                if (itr.current().data.Equals(_data))
                {
                    return itr.current();
                }
            }
            return null;
        }
        private LinkedListNode<T> FindParentNode(LinkedListNode<T> node)
        {
            for (LinkedListIterator<T> itr = new LinkedListIterator<T>(head); itr.current() != null; itr.next())
            {
                if (itr.current().next.Equals(node))
                {
                    return itr.current();
                }
            }
            return null;
        }
        public LinkedListNode<T> FindParentNode(T _existingData)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(_existingData);
            for (LinkedListIterator<T> itr = new LinkedListIterator<T>(head); itr.current() != null; itr.next())
            {
                if (itr.current().next.data.Equals(node.data))
                {
                    return itr.current();
                }
            }
            return null;
        }
        public void InsertFirst(T _data)
        {
            if (!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
            IncreaseLength();
        }
        public void DeleteHead()
        {
            if (head == null) return;
            head = head.next;
            DecreaseLength();
        }
        public void InsertLast(T _data)
        {
            if (!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
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
            IncreaseLength();
        }
        public void InsertAfter(LinkedListNode<T> node, T _data)
        {
            if (!CanInsert(_data)) return;
            if (node == null) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            IncreaseLength();
        }
        public void InsertAfter(T _existingData, T _newdata)
        {
            if (!CanInsert(_newdata)) return;
            LinkedListNode<T> node = FindNode(_existingData);
            if (node == null) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_newdata);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            IncreaseLength();
        }
        public void InsertBefore(LinkedListNode<T> _node, T _data)
        {
            if (!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            LinkedListNode<T> parentNode = FindParentNode(_node);

            newNode.next = _node;
            if (parentNode == null)
            {
                head = newNode;
            }
            else
            {
                parentNode.next = newNode;
            }
            IncreaseLength();
        }
        public void InsertBefore(T _existingData, T _data)
        {
            if (!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            LinkedListNode<T> node = FindNode(_existingData);
            LinkedListNode<T> parentNode = FindParentNode(_existingData);

            newNode.next = node;
            if (parentNode == null)
            {
                head = newNode;
            }
            else
            {
                parentNode.next = newNode;
            }
            IncreaseLength();
        }
        public void deleteNode(LinkedListNode<T> node)
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
            }
            else
            {
                LinkedListNode<T> parentNode = FindParentNode(node);
                if (tail == node)
                {
                    tail = parentNode;
                    parentNode.next = null;
                }
                else
                {
                    parentNode.next = node.next;
                }
            }
            DecreaseLength();
        }
        public void deleteNode(T _existingData)
        {
            LinkedListNode<T> node = FindNode(_existingData);
            if (node == null) return;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if (head == node)
            {
                head = node.next;
            }
            else
            {
                LinkedListNode<T> parentNode = FindParentNode(node);
                if (tail == node)
                {
                    tail = parentNode;
                    parentNode.next = null;
                }
                else
                {
                    parentNode.next = node.next;
                }
            }
            DecreaseLength();
        }
        public LinkedList<T> CopyList()
        {
            LinkedList<T> newList = new LinkedList<T>();
            if (this.Length <= 0) return newList;
            for (LinkedListIterator<T> itr = begin(); itr.current() != null; itr.next())
            {
                newList.InsertLast(itr.data());
            }
            return newList;
        }

        public bool IsExist(T _data)
        {
            if (FindNode(_data) == null)
            {
                return false;
            }
            return true;
        }
        public bool CanInsert(T _data)
        {
            if (isUnique && IsExist(_data))
            {
                return false;
            }
            return true;
        }
        private void IncreaseLength()
        {
            Length++;
        }
        private void DecreaseLength()
        {
            Length--;
        }
    }
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;
        public LinkedListNode(T _data)
        {
            data = _data;
            next = null;
        }
    }
    public class LinkedListIterator<T>
    {
        LinkedListNode<T> currentNode;
        public LinkedListIterator()
        {
            currentNode = null;
        }
        public LinkedListIterator(LinkedListNode<T> _currentNode)
        {
            currentNode = _currentNode;
        }
        public T data()
        {
            return currentNode.data;
        }
        public LinkedListIterator<T> next()
        {
            currentNode = currentNode.next;
            return this;
        }
        public LinkedListNode<T> current()
        {
            return currentNode;
        }
    }
}
