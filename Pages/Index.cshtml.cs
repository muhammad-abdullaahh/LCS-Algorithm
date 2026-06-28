using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LCSPlagiarismChecker.Models;
using LCSPlagiarismChecker.Core;
using System.Text.Json;

namespace LCSPlagiarismChecker.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CheckRequest CheckRequest { get; set; } = new CheckRequest();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var calculator = new SimilarityCalculator();
            var result = calculator.Analyze(CheckRequest.Text1, CheckRequest.Text2);
            result.Text1Original = CheckRequest.Text1;
            result.Text2Original = CheckRequest.Text2;

            TempData["ResultData"] = JsonSerializer.Serialize(result);

            return RedirectToPage("Result");
        }
    }
}
