using System;
class Program
{
  static int Fibonacci(int n)
  {
    if (n <= 1)
      return n;

    int a = 0, b = 1, temp;
    for (int i = 2; i <= n; i++)
    {
      temp = a + b;
      a = b;
      b = temp;
    }
    return b;
  }
  static void Main()
  {
    Console.Write("Nhập số nguyên dương n: ");
    if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
    {
      int result = Fibonacci(n);
      Console.WriteLine($"Số Fibonacci thứ {n} là: {result}");
    }
    else
    {
      Console.WriteLine("Không phải số nguyên dương hợp lệ.");
    }
  }
}
