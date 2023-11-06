//  cho n đồ vật và một ba lô có trọng lượng tối đa W
//  mỗi đồ vật i có trọng lượng wi
//  mỗi đồ vật i có giá trị vi
//  gọi xi
// là một phần của đồ vật i, 0  xi  1, xi có trọng lượng xiwi
// và giá trị xivi
//  Yêu cầu: xếp các đồ vật vào ba lô để tổng giá trị ba lô lớn nhất
//  Bài toán xếp ba lô này được gọi là xếp ba lô « từng phần »
//  có thể chỉ cần xếp vào ba lô một phần của đồ vật
//  Bài toán xếp ba lô đã gặp được gọi là xếp ba lô « 0-1 »
//  một đồ vật hoặc được xếp vào ba lô (1) hoặc không được xếp 
// vào ba lô (0)
using System;
using System.Linq;

class KnapsackFractional
{
  public class Item
  {
    public int Weight { get; set; }
    public int Value { get; set; }

    public Item(int weight, int value)
    {
      Weight = weight;
      Value = value;
    }
  }

  public static double FractionalKnapsack(Item[] items, int capacity)
  {
    // Sắp xếp các đồ vật theo tỷ lệ giá trị trên trọng lượng (vi/wi)
    items = items.OrderByDescending(item => (double)item.Value / item.Weight).ToArray();

    double totalValue = 0.0;

    foreach (var item in items)
    {
      if (capacity >= item.Weight)
      {
        totalValue += item.Value;
        capacity -= item.Weight;
      }
      else
      {
        totalValue += (double)item.Value * capacity / item.Weight;
        break;
      }
    }

    return totalValue;
  }

  static void Main()
  {
    Item[] items = new Item[]
    {
            new Item(10, 60),
            new Item(20, 100),
            new Item(30, 120)
    };

    int capacity = 50;

    double maxValue = FractionalKnapsack(items, capacity);
    Console.WriteLine("Tổng giá trị lớn nhất có thể đạt được: " + maxValue);
  }
}
