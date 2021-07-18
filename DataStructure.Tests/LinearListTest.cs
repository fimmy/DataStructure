using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure.Core;
namespace DataStructure.Tests
{
  [TestClass]
  public class LinearListTest
  {
    [TestMethod]
    public void Test()
    {
      var intList = new LinearList<int>(10);
      Console.WriteLine(intList);
      intList.Insert(intList.Length, 2);
      Console.WriteLine(intList);
      intList.Insert(intList.Length, 1);
      Console.WriteLine(intList);
      intList.Insert(intList.Length, 3);
      Console.WriteLine(intList);
      intList.Delete(2);
      Console.WriteLine(intList);
      intList.Insert(1, 8);
      Console.WriteLine(intList);
      intList.Insert(0, 7);
      Console.WriteLine(intList);
      intList.Delete(1);
      intList.Insert(3, 9);
      Console.WriteLine(intList);
      Console.WriteLine(intList.LocateItem(9));
      Console.WriteLine(intList.LocateItem(8));
      Console.WriteLine(intList.LocateItem(10));
    }
  }
}
