using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LCSPlagiarismChecker.Models;

namespace LCSPlagiarismChecker.Core
{
    public class SimilarityCalculator
    {
        private readonly LcsAlgorithm _lcsAlgorithm;

        public SimilarityCalculator()
        {
            _lcsAlgorithm = new LcsAlgorithm();
        }

        public string[] Tokenize(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return Array.Empty<string>();

            // Remove punctuation and convert to lowercase
            var cleanText = Regex.Replace(text.ToLowerInvariant(), @"[^\w\s]", "");
            
            // Split by whitespace and remove empty entries
            return cleanText.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public double ComputeSimilarity(string text1, string text2)
        {
            var tokens1 = Tokenize(text1);
            var tokens2 = Tokenize(text2);

            if (tokens1.Length == 0 && tokens2.Length == 0) return 100.0;
            if (tokens1.Length == 0 || tokens2.Length == 0) return 0.0;

            int lcsLength = _lcsAlgorithm.ComputeLength(tokens1, tokens2);
            
            return (2.0 * lcsLength) / (tokens1.Length + tokens2.Length) * 100.0;
        }

        public CheckResult Analyze(string text1, string text2)
        {
            var tokens1 = Tokenize(text1);
            var tokens2 = Tokenize(text2);

            double score = 0.0;
            List<string> sequence = new List<string>();

            if (tokens1.Length == 0 && tokens2.Length == 0)
            {
                score = 100.0;
            }
            else if (tokens1.Length > 0 && tokens2.Length > 0)
            {
                int lcsLength = _lcsAlgorithm.ComputeLength(tokens1, tokens2);
                score = (2.0 * lcsLength) / (tokens1.Length + tokens2.Length) * 100.0;
                sequence = _lcsAlgorithm.ReconstructSequence(tokens1, tokens2);
            }

            return new CheckResult
            {
                SimilarityScore = score,
                MatchedWords = sequence,
                Text1Tokens = tokens1,
                Text2Tokens = tokens2
            };
        }
    }
}
