using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class LinkedList
    {
        public LinkedListNode head { get; private set; }
        public LinkedListNode tail { get; private set; }
        public int length { get; private set; }
        public bool isUnique { get; private set; }

        public LinkedList()
        {
        }
        public LinkedList(bool _isUnique)
        {
            isUnique = _isUnique;
        }


        public LinkedList CopyList()
        {
            LinkedList newList = new LinkedList();
            if (this.length <= 0) return newList;
            for (LinkedListIterator itr = new LinkedListIterator(head); itr.current() != null; itr.next())
            {
                newList.InsertLast(itr.data());
            }
            return newList;
        }
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
            Console.Write($"Length : {length}");
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
            if (!CanInsert(_data)) return;
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
            IncreaseLength();
        }
        public void InsertAfter(LinkedListNode node, int _data)
        {
            if (!CanInsert(_data)) return;
            if (node == null) return;
            LinkedListNode newNode = new LinkedListNode(_data);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            IncreaseLength();
        }
        public void InsertAfter(int _existingData, int _newdata)
        {
            if (!CanInsert(_newdata)) return;
            LinkedListNode node = FindNode(_existingData);
            if (node == null) return;
            LinkedListNode newNode = new LinkedListNode(_newdata);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            IncreaseLength();
        }
        public void InsertBefore(LinkedListNode _node, int _data)
        {
            if (!CanInsert(_data)) return;
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
            IncreaseLength();
        }
        public void InsertBefore(int _existingData, int _data)
        {
            if (!CanInsert(_data)) return;
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
            IncreaseLength();
        }
        public void deleteNode(LinkedListNode node)
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
                LinkedListNode parentNode = FindParentNode(node);
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
        public void deleteNode(int _existingData)
        {
            LinkedListNode node = FindNode(_existingData);
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
                LinkedListNode parentNode = FindParentNode(node);
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
        public bool IsExist(int _data)
        {
            if (FindNode(_data) == null)
            {
                return false;
            }
            return true;
        }
        public bool CanInsert(int _data)
        {
            if (isUnique && IsExist(_data))
            {
                return false;
            }
            return true;
        }
        private void IncreaseLength()
        {
            length++;
        }
        private void DecreaseLength()
        {
            length--;
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
