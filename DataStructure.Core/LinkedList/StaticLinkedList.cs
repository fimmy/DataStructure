using System;

namespace DataStructure.Core.LinkedList
{
    public class StaticLinkedList<T>
    {
        private int maxSize;
        private int length = 0;
        public int Length
        {
            get { return length; }
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
        private T[] data;
        private int[] cursors;
        public StaticLinkedList(int maxSize)
        {
            this.maxSize = maxSize;
            data = new T[maxSize];
            cursors = new int[maxSize];
            for (int i = 0; i < maxSize - 1; i++)
            {
                cursors[i] = i + 1;
            }
            cursors[maxSize - 1] = 0;
        }
        /// <summary>
        /// 申请空闲的空间
        /// </summary>
        /// <returns></returns>
        private int getFreeSpaceCursor()
        {
            var index = cursors[0];
            if (index >= maxSize - 1)
            {
                throw new OutOfMemoryException("链表空间不足");
            }
            cursors[0] = cursors[index];
            return index;
        }
        /// <summary>
        /// 回收空闲的空间
        /// </summary>
        /// <param name="index"></param>
        private void recoveryFreeSpaceCursor(int index)
        {
            cursors[index] = cursors[0];
            cursors[0] = index;
        }
        private int GetCursor(int index)
        {
            if (index < 0 || index > length - 1)
            {
                throw new ArgumentOutOfRangeException("索引超出范围");
            }

            var current = cursors[maxSize - 1];
            int i = 0;
            while (i < index)
            {
                current = cursors[current];
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
            return data[GetCursor(index)];
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
            var newNodeIndex = getFreeSpaceCursor();
            int parentCursor;
            if (index == 0)
            {
                parentCursor = maxSize - 1;

            }
            else
            {
                parentCursor = GetCursor(index - 1);
            }
            cursors[newNodeIndex] = cursors[parentCursor];
            cursors[parentCursor] = newNodeIndex;
            data[newNodeIndex] = element;
            length++;
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
        /// 删除元素并返回
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Delete(int index)
        {
            int currentCursor;

            if (index == 0)
            {
                currentCursor = cursors[maxSize - 1];
                cursors[maxSize - 1] = cursors[currentCursor];
            }
            else
            {
                var parentNodeIndex = GetCursor(index - 1);
                currentCursor = cursors[parentNodeIndex];
                cursors[parentNodeIndex] = cursors[currentCursor];
            }
            recoveryFreeSpaceCursor(currentCursor);
            length--;
            return data[currentCursor];
        }
        /// <summary>
        /// 清空线性表
        /// </summary>
        public void Clear()
        {
            length = 0;
            for (int i = 0; i < length; i++)
            {
                Delete(i);
            }
        }
        /// <summary>
        /// 根据元素查询位置
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int LocateItem(T element)
        {
            var current = cursors[maxSize - 1];

            for (int i = 0; i < length; i++)
            {
                if (data[current].Equals(element))
                {
                    return i;
                }
                current = cursors[current];
            }
            return -1;
        }
        public override string ToString()
        {
            var itemStr = "";
            var current = cursors[maxSize - 1];
            for (int i = 0; i < length; i++)
            {
                itemStr += $"{data[current].ToString()},";
                current = cursors[current];
            }
            itemStr = itemStr.Trim(',');
            return $"count:{length},items:[{itemStr}]";
        }
    }
}
