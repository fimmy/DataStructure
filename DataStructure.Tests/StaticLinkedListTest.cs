using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure.Core.LinkedList;
namespace DataStructure.Tests
{
    [TestClass]
    public class StaticLinkedListTest
    {
        [TestMethod]
        public void Test()
        {
            var intList = new StaticLinkedList<int>(10);
            Console.WriteLine(intList);
            intList.Append(2);
            Console.WriteLine(intList);
            intList.Append(1);
            Console.WriteLine(intList);
            intList.Append(3);
            Console.WriteLine(intList);
            intList.Delete(1);
            Console.WriteLine(intList);
            intList.Insert(1, 8);
            Console.WriteLine(intList);
            intList.Insert(0, 7);
            Console.WriteLine(intList);
            intList.Delete(1);
            Console.WriteLine(intList);
            intList.Insert(3, 9);
            Console.WriteLine(intList);
            Console.WriteLine(intList.LocateItem(9));
            Console.WriteLine(intList.LocateItem(8));
            Console.WriteLine(intList.LocateItem(10));
            intList.Clear();
            Console.WriteLine(intList);
            intList.Append(1);
            intList.Append(2);
            intList.Append(3);
            Console.WriteLine(intList);
        }
    }
}
