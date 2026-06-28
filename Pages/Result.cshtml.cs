using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LCSPlagiarismChecker.Models;
using System.Text.Json;

namespace LCSPlagiarismChecker.Pages
{
    public class ResultModel : PageModel
    {
        public CheckResult Result { get; set; } = new CheckResult();
        public string SimilarityLabel { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            if (TempData["ResultData"] is string resultJson)
            {
                Result = JsonSerializer.Deserialize<CheckResult>(resultJson) ?? new CheckResult();
                SetLabel();
                return Page();
            }

            return RedirectToPage("Index");
        }

        private void SetLabel()
        {
            double score = Result.SimilarityScore;
            if (score == 100) SimilarityLabel = "EXACT MATCH";
            else if (score == 0) SimilarityLabel = "NO SIMILARITY DETECTED";
            else if (score >= 81) SimilarityLabel = "VERY HIGH SIMILARITY \u2014 LIKELY PLAGIARISED";
            else if (score >= 61) SimilarityLabel = "HIGH SIMILARITY";
            else if (score >= 31) SimilarityLabel = "MODERATE SIMILARITY";
            else SimilarityLabel = "LOW SIMILARITY";
        }
    }
}
