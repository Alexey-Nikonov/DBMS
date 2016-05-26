using System;
using System.Collections;
using System.Collections.Generic;

namespace DBMS
{
    class Collection<T> : IEnumerable<T>, IEnumerator<T>
    {
        readonly ArrayList elements = null;

        public Collection()
        {
            this.elements = new ArrayList();
        }

        public T this[int index]
        {
            get { return (T)this.elements[index]; }
            set { this.elements[index] = value; }
        }

        int position = -1;

        // implementation of IEnumerable<T>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        // implementation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        // implementation of IEnumerator<T>
        T IEnumerator<T>.Current
        {
            get { return this[position]; }
        }

        // implementation of IEnumerator
        object IEnumerator.Current
        {
            get { return this[position]; }
        }

        bool IEnumerator.MoveNext()
        {
            if (this.position < this.elements.Count - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        void IEnumerator.Reset()
        {
            this.position = -1;
        }

        // implementation of IDisposable
        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }

        // additional methods
        public void Add(T item)
        {
            this.elements.Add(item);
        }

        public void Delete(T item)
        {
            this.elements.Remove(item);
        }

        public int Length
        {
            get { return this.elements.Count; }
        }
    }
}
