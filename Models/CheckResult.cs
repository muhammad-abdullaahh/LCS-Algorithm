using System.Collections.Generic;

namespace LCSPlagiarismChecker.Models
{
    public class CheckResult
    {
        public double SimilarityScore { get; set; }
        public List<string> MatchedWords { get; set; } = new List<string>();
        public string[] Text1Tokens { get; set; } = System.Array.Empty<string>();
        public string[] Text2Tokens { get; set; } = System.Array.Empty<string>();
        public string Text1Original { get; set; } = string.Empty;
        public string Text2Original { get; set; } = string.Empty;
    }
}
