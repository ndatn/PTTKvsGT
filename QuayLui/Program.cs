// Xếp n con hậu
// Tìm tất cả các khả năng xếp n con hậu trên 
// một bàn cờ có nxn ô sao cho các con hậu 
// không tấn công nhau, nghĩa là
// - mỗi hàng chỉ chứa một con hậu
// - mỗi cột chỉ chứa một con hậu
// - mỗi đường chéo chỉ chứa một con hậuusing System;

class NQueens
{
  public static void SolveNQueens(int n)
  {
    int[] queens = new int[n];
    PlaceQueens(queens, 0);
  }

  public static void PlaceQueens(int[] queens, int row)
  {
    int n = queens.Length;
    if (row == n)
    {
      // In ra một cách xếp hậu hợp lệ
      PrintSolution(queens);
      return;
    }

    for (int col = 0; col < n; col++)
    {
      if (IsSafe(queens, row, col))
      {
        queens[row] = col;
        PlaceQueens(queens, row + 1);
      }
    }
  }

  public static bool IsSafe(int[] queens, int row, int col)
  {
    for (int prevRow = 0; prevRow < row; prevRow++)
    {
      int prevCol = queens[prevRow];

      if (prevCol == col ||                         // Kiểm tra cột
          prevRow + prevCol == row + col ||         // Kiểm tra đường chéo chính
          prevRow - prevCol == row - col)           // Kiểm tra đường chéo phụ
      {
        return false;
      }
    }

    return true;
  }

  public static void PrintSolution(int[] queens)
  {
    int n = queens.Length;
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        if (queens[i] == j)
        {
          Console.Write("Q ");
        }
        else
        {
          Console.Write(". ");
        }
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }

  static void Main()
  {
    int n = 8; // Kích thước của bàn cờ (n x n)
    SolveNQueens(n);
  }
}
