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
            //UsingFile.ReadAllTextFiles(FolderPath);
            UsingFileStream.FilesProsses(FolderPath);
            UsingFileStream.WriteSummary(@"D:\CSharp\summary.txt");
            UsingFileStream.ShowFiles("summary.txt", true);
            Console.Write("\n--> Press any key to exit..");
            Console.ReadKey();

        }
    }


}
