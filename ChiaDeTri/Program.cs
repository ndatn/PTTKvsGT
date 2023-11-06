//Nhân 2 ma trận
using System;

class MatrixMultiplication
{
  public static int[,] MatrixMultiply(int[,] A, int[,] B)
  {
    int n = A.GetLength(0);
    int[,] C = new int[n, n];

    if (n == 1)
    {
      C[0, 0] = A[0, 0] * B[0, 0];
    }
    else
    {
      int[,] A11 = new int[n / 2, n / 2];
      int[,] A12 = new int[n / 2, n / 2];
      int[,] A21 = new int[n / 2, n / 2];
      int[,] A22 = new int[n / 2, n / 2];
      int[,] B11 = new int[n / 2, n / 2];
      int[,] B12 = new int[n / 2, n / 2];
      int[,] B21 = new int[n / 2, n / 2];
      int[,] B22 = new int[n / 2, n / 2];

      SplitMatrix(A, A11, A12, A21, A22);
      SplitMatrix(B, B11, B12, B21, B22);

      int[,] C11 = AddMatrices(MatrixMultiply(A11, B11), MatrixMultiply(A12, B21));
      int[,] C12 = AddMatrices(MatrixMultiply(A11, B12), MatrixMultiply(A12, B22));
      int[,] C21 = AddMatrices(MatrixMultiply(A21, B11), MatrixMultiply(A22, B21));
      int[,] C22 = AddMatrices(MatrixMultiply(A21, B12), MatrixMultiply(A22, B22));

      CombineMatrices(C, C11, C12, C21, C22);
    }

    return C;
  }

  public static void SplitMatrix(int[,] P, int[,] C11, int[,] C12, int[,] C21, int[,] C22)
  {
    int n = P.GetLength(0) / 2;

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        C11[i, j] = P[i, j];
        C12[i, j] = P[i, j + n];
        C21[i, j] = P[i + n, j];
        C22[i, j] = P[i + n, j + n];
      }
    }
  }

  public static void CombineMatrices(int[,] C, int[,] C11, int[,] C12, int[,] C21, int[,] C22)
  {
    int n = C.GetLength(0) / 2;

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        C[i, j] = C11[i, j];
        C[i, j + n] = C12[i, j];
        C[i + n, j] = C21[i, j];
        C[i + n, j + n] = C22[i, j];
      }
    }
  }

  public static int[,] AddMatrices(int[,] A, int[,] B)
  {
    int n = A.GetLength(0);
    int[,] C = new int[n, n];

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        C[i, j] = A[i, j] + B[i, j];
      }
    }

    return C;
  }

  public static void PrintMatrix(int[,] matrix)
  {
    int n = matrix.GetLength(0);
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        Console.Write(matrix[i, j] + " ");
      }
      Console.WriteLine();
    }
  }

  static void Main()
  {
    Console.Write("Nhập kích thước ma trận n: ");
    int n = int.Parse(Console.ReadLine());

    int[,] A = new int[n, n];
    int[,] B = new int[n, n];

    Console.WriteLine("Nhập ma trận A:");
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        A[i, j] = int.Parse(Console.ReadLine());
      }
    }

    Console.WriteLine("Nhập ma trận B:");
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        B[i, j] = int.Parse(Console.ReadLine());
      }
    }

    int[,] C = MatrixMultiply(A, B);
    Console.WriteLine("Ma trận kết quả C:");
    PrintMatrix(C);
  }
}
