using System;

namespace DBMS
{
    class BinaryTree
    {
        Node root = null;

        public void Add(int key, int value)
        {
            if (this.root == null)
            {
                this.root = new Node(key, value);
            }
            else
            {
                AddAfterParent(root, key, value);
            }
        }

        void AddAfterParent(Node parent, int key, int value)
        {
            if (key.CompareTo(parent.Key) < 0)
            {
                if (parent.Left == null)
                {
                    parent.Left = new Node(key, value);
                }
                else
                {
                    AddAfterParent(parent.Left, key, value);
                }
            }
            else
            {
                if (parent.Right == null)
                {
                    parent.Right = new Node(key, value);
                }
                else
                {
                    AddAfterParent(parent.Right, key, value);
                }
            }
        }

        public void Show()
        {
            ShowInOrder(this.root);
        }

        void ShowInOrder(Node node) // в прямом порядке
        {
            if (node.Left != null)
            {
                ShowInOrder(node.Left);
            }

            Console.WriteLine("Key: {0} Value: {1}", node.Key, node.Value);

            if (node.Right != null)
            {
                ShowInOrder(node.Right);
            }            
        }

        public void Find(int key)
        {
            Node parent = null;
            Console.WriteLine("Строка со значением {0} имеет номер: {1}", key, FindWithParent(key, out parent).Value);
        }

        Node FindWithParent(int key, out Node parent)
        {
            Node current = this.root;
            parent = null;

            while (current != null)
            {
                if (current.CompareTo(key) > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (current.CompareTo(key) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public bool Remove(int key)
        {
            Node current = null, parent = null;

            current = FindWithParent(key, out parent);

            if (current == null)
            {
                return false;
            }

            if (current.Right == null)
            {
                if (parent == null)
                {
                    this.root = current.Left;
                }

                else
                {
                    if (parent.CompareTo(current.Key) > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (parent.CompareTo(current.Key) < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    this.root = current.Right;
                }
                else
                {
                    if (parent.CompareTo(current.Key) > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (parent.CompareTo(current.Key) < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node leftMost = current.Right.Left;
                Node leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    this.root = leftMost;
                }
                else
                {
                    if (parent.CompareTo(current.Key) > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (parent.CompareTo(current.Key) < 0)
                    {
                        parent.Right = leftMost;
                    }
                }
            }

            return true;
        }
    }
}
