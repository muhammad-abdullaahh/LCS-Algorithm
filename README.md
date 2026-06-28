# LCS Plagiarism Checker

A robust and efficient web-based plagiarism detection tool built with C# console. This application utilizes the **Longest Common Subsequence (LCS)** algorithm to compare two bodies of text and determine their similarity score, highlighting potential plagiarism.

## 🚀 Features

- **Accurate Similarity Calculation:** Employs the Longest Common Subsequence (LCS) algorithm for precise text comparison.
- **Text Normalization:** Automatically tokenizes text, removes punctuation, and converts to lowercase to ensure accurate matching regardless of formatting.
- **Detailed Results:** Provides a percentage-based similarity score and categorizes the result severity (e.g., Exact Match, High Similarity, Low Similarity).
- **Matched Sequence Highlighting:** Reconstructs and returns the exact sequence of matched words between the two texts.
- **Clean UI:** Built with ASP.NET Core Razor Pages for a seamless and responsive user experience.

## 🛠️ Tech Stack

- **Framework:** .NET 8 / ASP.NET Core (Razor Pages)
- **Language:** C#

## 🧠 How It Works

1. **Tokenization (`SimilarityCalculator.cs`):** Both input texts are cleaned (punctuation removed) and split into arrays of words (tokens).
2. **LCS Algorithm (`LcsAlgorithm.cs`):** A dynamic programming approach is used to build a matrix and find the longest contiguous or non-contiguous sequence of matching words that appear in the same order in both texts.
3. **Scoring:** The similarity percentage is calculated using the formula:
   ```
   Similarity Score = (2 * LCS_Length) / (Total_Tokens_Text1 + Total_Tokens_Text2) * 100
   ```
4. **Classification (`Result.cshtml.cs`):** Based on the score, the application assigns a label ranging from "NO SIMILARITY DETECTED" (0%) to "EXACT MATCH" (100%).

## 💻 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 7.0 or 8.0 recommended)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation & Execution

1. **Clone or Extract the Repository:**
   Navigate to the project directory:
   ```bash
   cd LCS-Plagiarism-Checker
   ```

2. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Run the Application:**
   ```bash
   dotnet run
   ```

4. **Access the Web App:**
   Open your web browser and navigate to the URL provided in the console output (typically `http://localhost:5000` or `https://localhost:5001`).

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the issues page if you want to contribute.

## 📝 License

This project is open-source and available under the [MIT License](LICENSE).
