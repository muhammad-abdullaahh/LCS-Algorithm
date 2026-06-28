using System;
using System.Collections.Generic;

namespace LCSPlagiarismChecker.Core
{
    public class LcsAlgorithm
    {
        public int ComputeLength(string[] tokens1, string[] tokens2)
        {
            var dp = BuildDpTable(tokens1, tokens2);
            return dp[tokens1.Length, tokens2.Length];
        }

        public List<string> ReconstructSequence(string[] tokens1, string[] tokens2)
        {
            var dp = BuildDpTable(tokens1, tokens2);
            var sequence = new List<string>();
            int i = tokens1.Length;
            int j = tokens2.Length;

            while (i > 0 && j > 0)
            {
                if (tokens1[i - 1] == tokens2[j - 1])
                {
                    sequence.Add(tokens1[i - 1]);
                    i--;
                    j--;
                }
                else if (dp[i - 1, j] > dp[i, j - 1])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            sequence.Reverse();
            return sequence;
        }

        private int[,] BuildDpTable(string[] tokens1, string[] tokens2)
        {
            int m = tokens1.Length;
            int n = tokens2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (tokens1[i - 1] == tokens2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp;
        }
    }
}
