namespace DesignPatterns.BehavioralPatterns.IteratorExample
{
    using System;
    using System.Collections.Generic;

    internal class Node<T>
    {        
        public Node<T> Next { get; set; }

        public T Item { get; set; }
    }

    public class CustomList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private int count = 0;

        public int Count
        {
            get { return this.count; }
        }

        public bool IsEmpty 
        { 
            get { return this.count == 0; }
        }

        public void Add(T value)
        {
            if (value != null)
            {
                if (this.head != null)
                {
                    var newNode = new Node<T>();
                    newNode.Item = value;

                    var current = this.head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = newNode;
                }
                else
                {
                    this.head = new Node<T>();
                    this.head.Item = value;
                }

                this.count++;
            }
            else
            {
                throw new ArgumentNullException("Cannot add null to a linked list.");
            }
        }

        public void Remove(T value)
        {
            var current = this.head;
            var beforeCurrent = current;
            while (current != null)
            {
                if (current.Item.CompareTo(value) == 0)
                {
                    beforeCurrent.Next = current.Next;
                    this.count--;
                    break;
                }
                beforeCurrent = current;
                current = current.Next;
            }
        }

        public void Clear()
        {
            var current = this.head;
            do
            {
                var temp = current.Next;
                current.Item = default(T);
                current = null;
                current = temp;
            } while (current != null);

            count = 0;
        }

        public bool Contains(T value)
        {
            var current = this.head;
            do
            {
                if (current.Item.CompareTo(value) == 0)
                {
                    return true;
                }
                current = current.Next;
            } while (current != null);

            return false;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException("Index was outside of the bounds of the linked list.");
                }

                var current = this.head;
                int i = 0;
                while (i < index)
                {
                    current = current.Next;
                    i++;
                }

                return current.Item;
            }            
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                yield return current.Item;
                current = current.Next;
            }
        }        
    }
}