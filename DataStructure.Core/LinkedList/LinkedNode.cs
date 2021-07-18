using System;

namespace DataStructure.Core.LinkedList
{
    public class LinkedNode<T>
    {
        public T data;
        public LinkedNode<T> next;
        public LinkedNode(T data, LinkedNode<T> next = null)
        {
            this.data = data;
            this.next = next;
        }
    }
}
