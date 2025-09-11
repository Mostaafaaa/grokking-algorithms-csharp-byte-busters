using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileStream_BaghdadTask
{
    internal class Program
    {
        /*
        Requirements:
        Read a text file using StreamReader.
        Count:
        Total lines
        Total words
        Occurrences of the word “Baghdad” (case-insensitive).
        Use LINQ to get the Top 5 most common words.
        Write the summary into a new file (summary.txt) using StreamWriter.*/

        public static void ReadAndAnalyzeFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read the entire file content
                    string content = reader.ReadToEnd();
                    // Split content into lines and words
                    string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    int totalLines = lines.Length;
                    // \r means carriage return, \n means new line, \t means tab
                    string[] words = content.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    int totalWords = words.Length;
                    // using linq to count occurrences of "Baghdad" (case-insensitive) and for all the other operations
                    int baghdadCount = words.Count(zeo => string.Equals(zeo, "Baghdad", StringComparison.OrdinalIgnoreCase));
                    var topWords = words
                        // CultureInfo.InvariantCulture means that the comparison is culture-insensitive which means that it will not be affected by the current culture of the system
                        .GroupBy(zeo => zeo.ToLower(CultureInfo.InvariantCulture))
                        // OrderByDescending is used to sort the groups in descending order based on their count
                        .OrderByDescending(zeo => zeo.Count())
                        // Select the top 5 most common words
                        .Take(5)
                        // Create an anonymous object with Word and Count properties to hold the word and its count
                        .Select(zeo => new { Word = zeo.Key, Count = zeo.Count() })
                        // Convert the result to a list
                        .ToList();

                    // Now Finally write the summary to a new file called summary.txt using StreamWriter :)
                    using (StreamWriter writer = new StreamWriter("summary.txt"))
                    {
                        writer.WriteLine($"We have ({totalLines}) Lines, ({totalWords}) Words and ({baghdadCount}) Occurrences of 'Baghdad' in this file.");
                        writer.WriteLine("\nAnd we have the following top 5 most common words:\n");
                        int rank = 1;
                        foreach (var word in topWords)
                        {
                            writer.WriteLine($"{rank}. \"{word.Word}\" Appears {word.Count} Times!");
                            rank++;
                        }
                    }
                }
                // The Big O Notation of this code is O(n).
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ReadFile method has thrown an error: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            string path = "E:\\Problems_Solver_Bootcamp\\VS_projects\\FileStream_BaghdadTask\\Baghdad.txt";
            ReadAndAnalyzeFile(path);
        }
    }
}
