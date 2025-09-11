using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextSearchAndComplexity
{
    public static class UsingFile
    {
        // This Function To Read all text file in spesific folder
        public static void ReadAllTextFiles(string folderPath)
        {
            /* Directory is static class is the system.io
            it provides methods for working with folders (directories) on my computer
            it used to create, delete, move, search. (folder manager)
            */
            if (Directory.Exists(folderPath)) // 1
            {
                /* here i use the GetFile Method to return files in folder
                   we have a filter here "*.txt" mean any file end with txt
                   The SearchOption is take all files and subfiles in folder
                */
                Console.WriteLine("-- Using File Class, Directory Class And Regex --\n");
                string[] textFiles = Directory.GetFiles(folderPath, "*.txt", SearchOption.AllDirectories);// 1
                foreach (string filePath in textFiles) // n
                {
                    Console.WriteLine($"File: {Path.GetFileName(filePath)}"); //1
                    ProcessFile(filePath);
                }
            }
            else
                Console.WriteLine("Error! Folder not found..."); // 1
        }

        static void ProcessFile(string filePath)
        {
            string content = File.ReadAllText(filePath);
            DisplayResults(filePath, CountWords(content), CountBaghdad(content));
        }
        static int CountWords(string text)
        {
            return Regex.Matches(text, @"\b\w+\b").Count;
        }
        static int CountBaghdad(string text)
        {
            return Regex.Matches(text, @"\bBaghdad\b", RegexOptions.IgnoreCase).Count;
        }
        public static void DisplayResults(string filePath, int totalWords, int baghdadCount)
        {
            Console.WriteLine($"Total words: {totalWords}");
            Console.WriteLine($"'Baghdad' count: {baghdadCount}");
            Console.WriteLine("----------------------------------");
        }
    }
}