using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {
        TreeNode Root;
        public void Insert(Tdata _data)
        {
            TreeNode newNode = new TreeNode(_data);
            if (Root == null)
            {
                Root = newNode;
                return;
            }
            Queue_LinkedListBased<TreeNode> queue = new Queue_LinkedListBased<TreeNode>();
            queue.Enqueue(Root);
            while (queue.HasData())
            {
                TreeNode currentNode = queue.Dequeue();
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(currentNode.Left);
                }
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }
        public int GetHeight()
        {
            return CalculateHeight(Root);
        }
        public void PreOrder()
        {
            InternalPreOrder(Root);
            Console.WriteLine();
        }
        public void InOrder()
        {
            InternalInOrder(Root);
            Console.WriteLine();
        }
        public void PostOrder()
        {
            InternalPostOrder(Root);
            Console.WriteLine();
        }
        public bool IsExist(Tdata _data)
        {
            if (Find(Root, _data) != null)
            {
                return true;
            }
            return false;
        }
        public Tdata GetLastItem()
        {
            TreeNode node = InternalGetLastItem(Root);
            return node.Data;
        }
        public void Delete(Tdata _data)
        {
            InternalDelete(_data);
        }
        public Tdata GetParent(Tdata _data)
        {
            if (InternalGetParentNode(Root, _data) is null)
            {
                return default(Tdata);
            }

            return InternalGetParentNode(Root, _data).Data;
        }

        private void InternalDelete(Tdata _data)
        {
            TreeNode node = Find(Root, _data);
            TreeNode lastNode = InternalGetLastItem(Root);
            if (node != null && lastNode != null)
                ReplaceNodes(node, lastNode);
        }
        private void ReplaceNodes(TreeNode node, TreeNode lastNode)
        {
            TreeNode parentLastNode = InternalGetParentNode(Root, lastNode.Data);
            if (lastNode == node)
            {
                parentLastNode.Left = null;
                parentLastNode.Right = null;
                lastNode = null;
                return;
            }
            lastNode.Right = node.Right;
            lastNode.Left = node.Left;
            TreeNode parentNode = InternalGetParentNode(Root, node.Data);
            if (parentNode == null)
            {
                Root = lastNode;
            }
            else if (parentNode.Left != null && parentNode.Left.Data.CompareTo(node.Data) == 0)
            {
                parentNode.Left = lastNode;
            }
            else if (parentNode.Right != null && parentNode.Right.Data.CompareTo(node.Data) == 0)
            {
                parentNode.Right = lastNode;
            }
            if (parentLastNode.Left != null && parentLastNode.Left.Data.CompareTo(lastNode.Data) == 0)
            {
                parentLastNode.Left = null;
                if (parentLastNode == node)
                {
                    lastNode.Left = null;
                }
            }
            else if (parentLastNode.Right != null && parentLastNode.Right.Data.CompareTo(lastNode.Data) == 0)
            {
                parentLastNode.Right = null;
                if (parentLastNode == node)
                {
                    lastNode.Right = null;
                }
            }
            node = null;
        }
        private TreeNode InternalGetParentNode(TreeNode startingNode, Tdata _data)
        {
            if (startingNode == null)
            {
                return null;
            }
            if ((startingNode?.Left == null && startingNode.Right == null) || Root.Data.Equals(_data))
            {
                return null;
            }
            if ((startingNode.Left?.Data.Equals(_data) ?? false) || (startingNode.Right?.Data.Equals(_data) ?? false))
            {
                return startingNode;
            }
            return InternalGetParentNode(startingNode.Left, _data) ?? InternalGetParentNode(startingNode.Right, _data);
        }
        private TreeNode InternalGetLastItem(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Right == null && node.Left == null)
            {
                return node;
            }
            return InternalGetLastItem(node.Right) ?? InternalGetLastItem(node.Left);
        }
        private TreeNode Find(TreeNode node, Tdata _data)
        {
            if (node == null)
            {
                return null;
            }
            if (_data.Equals(node.Data))
            {
                return node;
            }
            return Find(node.Left, _data) ?? Find(node.Right, _data);
        }
        private int CalculateHeight(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(CalculateHeight(node.Left), CalculateHeight(node.Right));
        }
        private void InternalPreOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write($"{node.Data} => ");
            InternalPreOrder(node.Left);
            InternalPreOrder(node.Right);
        }
        private void InternalInOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            InternalInOrder(node.Left);
            Console.Write($"{node.Data} => ");
            InternalInOrder(node.Right);
        }
        private void InternalPostOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            InternalPostOrder(node.Left);
            InternalPostOrder(node.Right);
            Console.Write($"{node.Data} => ");
        }

        class TreeNode
        {
            public Tdata Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode(Tdata _data)
            {
                Data = _data;
            }
        }//CLASS TREEENODE

        #region Printing Tree
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }
        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }
        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }
        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
        #endregion

    }//CLASS BINARYTREE
}//NAMESPACE
