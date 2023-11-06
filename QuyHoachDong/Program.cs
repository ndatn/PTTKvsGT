using System;

class LongestCommonSubsequence
{
  public static string FindLCS(string X, string Y, out string[,] path)
  {
    int m = X.Length;
    int n = Y.Length;

    int[,] dp = new int[m + 1, n + 1];

    path = new string[m + 1, n + 1];

    for (int i = 0; i <= m; i++)
    {
      for (int j = 0; j <= n; j++)
      {
        if (i == 0 || j == 0)
        {
          dp[i, j] = 0;
          path[i, j] = "";
        }
        else if (X[i - 1] == Y[j - 1])
        {
          dp[i, j] = dp[i - 1, j - 1] + 1;
          path[i, j] = "diagonal";
        }
        else
        {
          if (dp[i - 1, j] > dp[i, j - 1])
          {
            dp[i, j] = dp[i - 1, j];
            path[i, j] = "up";
          }
          else
          {
            dp[i, j] = dp[i, j - 1];
            path[i, j] = "left";
          }
        }
      }
    }

    int length = dp[m, n];
    char[] lcs = new char[length];
    int k = length;

    int p = m, q = n;
    while (p > 0 && q > 0)
    {
      if (path[p, q] == "diagonal")
      {
        lcs[k - 1] = X[p - 1];
        p--;
        q--;
        k--;
      }
      else if (path[p, q] == "up")
      {
        p--;
      }
      else
      {
        q--;
      }
    }

    return new string(lcs);
  }

  public static void PrintLCSProcess(string X, string Y, string[,] path)
  {
    int m = X.Length;
    int n = Y.Length;

    Console.WriteLine("LCS Process:");

    int i = m;
    int j = n;

    while (i > 0 && j > 0)
    {
      if (path[i, j] == "diagonal")
      {
        Console.WriteLine($"Match: X[{i - 1}] = Y[{j - 1}] = '{X[i - 1]}'");
        i--;
        j--;
      }
      else if (path[i, j] == "up")
      {
        Console.WriteLine($"Skip: X[{i - 1}] = '{X[i - 1]}'");
        i--;
      }
      else
      {
        Console.WriteLine($"Skip: Y[{j - 1}] = '{Y[j - 1]}'");
        j--;
      }
    }
  }

  static void Main()
  {
    string X = "ABCBDAB";
    string Y = "BDCAB";

    string[,] path;
    string lcs = FindLCS(X, Y, out path);

    Console.WriteLine("Longest Common Subsequence (LCS): " + lcs);
    PrintLCSProcess(X, Y, path);
  }
}
