using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextSearchAndComplexity
{
    public class UsingFileStream
    {
        public static string[] ReadFolder(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                Console.WriteLine("Error.. Folder Path Doesn't Exists!");
                return new string[0];
            }
            return Directory.GetFiles(FolderPath, "*txt", SearchOption.AllDirectories);
        }

        public static void FilesProsses(string folderPath, bool printLines = false)
        {
            int i = 0; // O(1) constant.
            string[] files = ReadFolder(folderPath); // O(n)
            foreach (string filepath in files)  // O(n)
            {
                i++;  // O(1)
                Console.WriteLine($"-------  File {i}  -------");   // O(1)
                Console.WriteLine($"File Name : {Path.GetFileName(filepath)}"); // O(1)
                using (StreamReader FileReader = new StreamReader(filepath)) // O(1)
                {
                    int WordsInFile = 0;
                    int Baghdadat = 0;
                    string? line;
                    var TotalLinesInFile = 0;
                    List<string> AllWords = new List<string>();
                    // O(1)
                    while ((line = FileReader.ReadLine()) != null) // O(m) where m = number of lines in the file
                    {
                        TotalLinesInFile++;  // O(1)

                        var CountedWordsInLine = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
                        // O(k) per line, k = number of words in the line
                        WordsInFile += CountedWordsInLine.Count();
                        // O(1)
                        Baghdadat += CountedWordsInLine.Count(w => w.Equals("baghdad", StringComparison.OrdinalIgnoreCase));
                        // O(1)
                        AllWords.AddRange(CountedWordsInLine.Select(w => w.ToLower()));
                        // O(k)
                    }
                    var top5 = AllWords.GroupBy(w => w).OrderByDescending(g => g.Count()).Take(5);

                    // O(W + W log W) where W = total words in file
                    // GroupBy = O(W)
                    // OrderByDescending = O(W log W)
                    // Take(5) = O(1)

                    Console.WriteLine($"Total Lines in File: {TotalLinesInFile}");
                    Console.WriteLine($"Words Count in File: {WordsInFile}");
                    Console.WriteLine($"Baghdadat Count in File: {Baghdadat}");
                    Console.WriteLine($"Top Five Words in File:");
                    // O(1)
                    foreach (var group in top5)  //O(5) = O(1)
                    {
                        Console.WriteLine($"{group.Key} --> {group.Count()}");
                    }
                }
                Console.WriteLine();
                // O(1)
            }
        }
        public static void WriteSummary(string filePath)
        {
            if (File.Exists(filePath))
                Console.WriteLine("File Already Exists..");

            string summary = @"Overall Time Complexity per file:
                 - O(m*k + W log W) 
                  where m = lines per file, k = words per line, W = total words in file (≈ m*k)
                 - For n files: O(n * (m*k + W log W))";
            using (StreamWriter writer = new StreamWriter("summary.txt"))
            {
                writer.Write(summary);
            }
            Console.WriteLine("Summary written to summary.txt using StreamWriter");
        }
        public static void ShowFiles(string filePath, bool IsPrint)
        {
            using (StreamReader FileReader = new StreamReader(filePath))
            {
                string? line;
                while ((line = FileReader.ReadLine()) != null)
                {
                    if (IsPrint)
                        Console.WriteLine(line);
                }
            }
        }
    }
}

