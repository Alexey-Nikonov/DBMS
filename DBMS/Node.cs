using System;

namespace DBMS
{
    class Node : IComparable
    {
        public int Key { get; private set; }
        public int Value { get; private set; }

        public Node(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public int CompareTo(object obj)
        {
            return this.Key.CompareTo((int)obj);
        }
    }
}
