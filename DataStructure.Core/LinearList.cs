using System;

namespace DataStructure.Core
{
  /// <summary>
  /// 线性表的顺序结构
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class LinearList<T>
  {
    /// <summary>
    /// 线性表长度
    /// </summary>
    private int length = 0;
    /// <summary>
    /// 线性表数据
    /// </summary>
    private T[] data;
    public int Length
    {
      get
      {
        return length;
      }
    }
    /// <summary>
    /// 线性表最大长度
    /// </summary>
    public int MaxSize
    {
      get;
      private set;
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
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="maxSize">线性表最大长度</param>
    public LinearList(int maxSize)
    {
      if (maxSize <= 0)
      {
        throw new ArgumentOutOfRangeException("线性表最大长度不可小于等于0");
      }
      MaxSize = maxSize;
      data = new T[maxSize];
    }
    /// <summary>
    /// 根据索引获取元素
    /// </summary>
    /// <param name="index">索引</param>
    /// <returns></returns>
    public T GetItem(int index)
    {
      if (index < 0 || index > length - 1)
      {
        throw new ArgumentOutOfRangeException("索引超出范围");
      }
      return data[index];
    }
    /// <summary>
    /// 指定位置插入元素
    /// </summary>
    /// <param name="index">位置</param>
    /// <param name="element">元素</param>
    public void Insert(int index, T element)
    {
      if (MaxSize - length <= 0)
      {
        throw new ArgumentOutOfRangeException("剩余空间不足");
      }
      if (index < 0 || index > length)
      {
        throw new ArgumentOutOfRangeException("索引超出范围");
      }
      for (int i = length; i > index; i--)
      {
        data[i] = data[i - 1];
      }
      length++;
      data[index] = element;
    }
    /// <summary>
    /// 删除元素并返回
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T Delete(int index)
    {
      T result;
      if (index < 0 || index > length - 1)
      {
        throw new ArgumentOutOfRangeException("索引超出范围");
      }
      result = data[index];
      for (int i = index; i < length; i++)
      {
        data[i] = data[i + 1];
      }
      data[length] = default(T);
      length--;
      return result;
    }
    /// <summary>
    /// 清空线性表
    /// </summary>
    public void Clear()
    {
      length = 0;
    }
    /// <summary>
    /// 根据元素查询位置
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public int LocateItem(T element)
    {
      for (int i = 0; i < length; i++)
      {
        if (data[i].Equals(element))
        {
          return i;
        }
      }
      return -1;
    }
    public override string ToString()
    {
      var itemStr = "";
      for (int i = 0; i < length; i++)
      {
        itemStr += $"{data[i].ToString()},";
      }
      itemStr = itemStr.Trim(',');
      return $"count:{length},items:[{itemStr}]";
    }
  }
}
