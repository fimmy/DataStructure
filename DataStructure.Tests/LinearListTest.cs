using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure.Core.LinearList;
using System.Diagnostics;

namespace DataStructure.Tests
{
    [TestClass]
    public class LinearListTest
    {
        /// <summary>
        /// 判断线性表是否与预期数组一致
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excepted"></param>
        /// <param name="actual"></param>
        private void AreEqualList<T>(T[] excepted, LinearList<T> actual)
        {
            Assert.AreEqual(excepted.Length, actual.Length);
            for (int i = 0; i < excepted.Length; i++)
            {
                Assert.AreEqual(excepted[i], actual.GetItem(i));
            }
        }
        /// <summary>
        /// 初始化线性表
        /// </summary>
        [TestMethod]
        public void InitLinearList()
        {
            var intList = new LinearList<int>(10);
            Assert.AreEqual(0, intList.Length);
            Assert.AreEqual(10, intList.MaxSize);
        }
        /// <summary>
        /// 在线性表最前插入元素
        /// </summary>
        [TestMethod]
        public void InsertAtFirst()
        {
            var intList = new LinearList<int>(10);
            intList.Insert(0, 5);
            intList.Insert(0, 4);
            intList.Insert(0, 2);
            var excepted = new int[] { 2, 4, 5 };
            AreEqualList(excepted, intList);
        }
        /// <summary>
        /// 在线性表最后插入元素
        /// </summary>
        [TestMethod]
        public void AppendAtLast()
        {
            var intList = new LinearList<int>(10);
            intList.Append(3);
            intList.Append(2);
            intList.Append(1);
            var excepted = new int[] { 3, 2, 1 };
            AreEqualList(excepted, intList);
        }
        /// <summary>
        /// 在线性表中间插入元素
        /// </summary>
        [TestMethod]
        public void InsertAtMiddle()
        {
            var intList = new LinearList<int>(10);
            intList.Insert(0, 5);
            intList.Insert(0, 4);
            intList.Insert(0, 2);
            intList.Append(3);
            intList.Append(2);
            intList.Append(1);
            intList.Insert(2, 88);
            intList.Insert(6, 77);
            var excepted = new int[] { 2, 4, 88, 5, 3, 2, 77, 1 };
            AreEqualList(excepted, intList);
        }
        /// <summary>
        /// 删除最前元素
        /// </summary>
        [TestMethod]
        public void DeleteAtFirst()
        {
            var intList = new LinearList<int>(10);
            intList.Append(3);
            intList.Append(2);
            intList.Append(1);
            intList.Delete(0);
            var excepted = new int[] { 2, 1 };
            AreEqualList(excepted, intList);
        }
        /// <summary>
        /// 删除最后元素
        /// </summary>
        [TestMethod]
        public void DeleteAtLast()
        {
            var intList = new LinearList<int>(10);
            intList.Append(3);
            intList.Append(2);
            intList.Append(1);
            intList.Delete(intList.Length - 1);
            var excepted = new int[] { 3, 2 };
            AreEqualList(excepted, intList);
        }
        /// <summary>
        /// 删除中间元素
        /// </summary>
        [TestMethod]
        public void DeleteAtMiddle()
        {
            var intList = new LinearList<int>(10);
            intList.Append(3);
            intList.Append(2);
            intList.Append(1);
            intList.Delete(1);
            var excepted = new int[] { 3, 1 };
            AreEqualList(excepted, intList);
        }
        /// <summary>
        /// 在错误的位置插入
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertErrorIndex()
        {
            var intList = new LinearList<int>(10);
            intList.Insert(0, 5);
            intList.Insert(0, 4);
            intList.Insert(0, 2);
            intList.Insert(4, 5);
        }
        /// <summary>
        /// 插入数量大于线性表长度
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertOverMaxSize()
        {
            var intList = new LinearList<int>(4);
            intList.Append(1);
            intList.Append(2);
            intList.Append(3);
            intList.Append(4);
            intList.Append(5);
        }
        /// <summary>
        /// 判断线性表是否为空
        /// </summary>
        [TestMethod]
        public void IsEmpty()
        {
            var intList = new LinearList<int>(4);
            Assert.IsTrue(intList.IsEmpty);
            intList.Append(1);
            Assert.IsFalse(intList.IsEmpty);
        }
        /// <summary>
        /// 清空线性表
        /// </summary>
        [TestMethod]
        public void Clear()
        {
            var intList = new LinearList<int>(10);
            intList.Append(1);
            intList.Append(2);
            intList.Append(3);
            intList.Append(4);
            intList.Append(5);
            intList.Clear();
            int[] excepted = new int[] { };
            AreEqualList(excepted, intList);
            Assert.IsTrue(intList.IsEmpty);
        }
        /// <summary>
        /// 查找元素
        /// </summary>
        [TestMethod]
        public void LocateItem()
        {
            var intList = new LinearList<int>(10);
            intList.Append(1);
            intList.Append(2);
            intList.Append(3);
            intList.Append(4);
            intList.Append(5);
            Assert.AreEqual(0, intList.LocateItem(1));
            Assert.AreEqual(1, intList.LocateItem(2));
            Assert.AreEqual(2, intList.LocateItem(3));
            Assert.AreEqual(3, intList.LocateItem(4));
            Assert.AreEqual(4, intList.LocateItem(5));
            Assert.AreEqual(-1, intList.LocateItem(25));
        }
    }
}
