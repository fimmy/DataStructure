using System;

namespace DataStructure.Core.LinkedList
{
    public class SingleLinkedList<T>
    {
        private LinkedNode<T> head = null;
        private int length = 0;
        public int Length
        {
            get { return length; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SingleLinkedList()
        {
        }
        /// <summary>
        /// 线性表是否为空
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return length == 0;
            }
        }
        private LinkedNode<T> GetNode(int index)
        {
            if (index < 0 || index > length - 1)
            {
                throw new ArgumentOutOfRangeException("索引超出范围");
            }

            var current = head;
            int i = 0;
            while (i < index)
            {
                current = current.next;
                i++;
            }
            return current;
        }
        /// <summary>
        /// 根据索引获取元素
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public T GetItem(int index)
        {
            return GetNode(index).data;
        }
        /// <summary>
        /// 指定位置插入元素
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="element">元素</param>
        public void Insert(int index, T element)
        {
            if (index < 0 || index > length)
            {
                throw new ArgumentOutOfRangeException("索引超出范围");
            }

            if (index == 0)
            {
                var newNode = new LinkedNode<T>(element, head);
                head = newNode;
            }
            else
            {
                var parentNode = GetNode(index - 1);
                var nextNode = parentNode.next;
                var newNode = new LinkedNode<T>(element, nextNode);
                parentNode.next = newNode;
            }
            length++;
        }
        /// <summary>
        /// 删除元素并返回
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Delete(int index)
        {
            LinkedNode<T> currentNode;

            if (index == 0)
            {
                currentNode = head;
                head = head.next;
            }
            else
            {
                var parentNode = GetNode(index - 1);
                currentNode = parentNode.next;
                var nextNode = currentNode.next;
                parentNode.next = nextNode;
            }
            length--;
            return currentNode.data;
        }
        /// <summary>
        /// 在线性表最后追加元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public void Append(T element)
        {
            Insert(length, element);
        }
        /// <summary>
        /// 清空线性表
        /// </summary>
        public void Clear()
        {
            length = 0;
            head = null;
        }
        /// <summary>
        /// 根据元素查询位置
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int LocateItem(T element)
        {
            var current = head;

            for (int i = 0; i < length; i++)
            {
                if (current.data.Equals(element))
                {
                    return i;
                }
                current = current.next;
            }
            return -1;
        }
        public override string ToString()
        {
            var itemStr = "";
            var current = head;
            for (int i = 0; i < length; i++)
            {
                itemStr += $"{current.data.ToString()},";
                current = current.next;
            }
            itemStr = itemStr.Trim(',');
            return $"count:{length},items:[{itemStr}]";
        }
    }
}
