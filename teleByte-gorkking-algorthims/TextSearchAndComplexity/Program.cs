using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextSearchAndComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            string FolderPath = @"D:\CSharp\notes";
            FileHelper.ReadAllTextFiles(FolderPath);
            Console.Write("\n--> Press any key to exit..");
            Console.ReadKey();
        }
    }
    public static class FileHelper
    {
        // This Function To Read all text file in spesific folder
        public static void ReadAllTextFiles(string folderPath)
        {
            /* Directory is static class is the system.io
            it provides methods for working with folders (directories) on my computer
            it used to create, delete, move, search. (folder manager)
            */
            if (Directory.Exists(folderPath))
            {
                /* here i use the GetFile Method to return files in folder
                   we have a filter here "*.txt" mean any file end with txt
                   The SearchOption is take all files and subfiles in folder
                */

                string[] textFiles = Directory.GetFiles(folderPath, "*.txt", SearchOption.AllDirectories);
                foreach (string filePath in textFiles)
                {
                    Console.WriteLine($"File: {Path.GetFileName(filePath)}");
                    ProcessFile(filePath);
                }
            }
            else
                Console.WriteLine("Error! Folder not found...");
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
