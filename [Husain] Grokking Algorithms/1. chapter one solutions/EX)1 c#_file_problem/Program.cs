using System.Text.RegularExpressions;
using System.Diagnostics;
namespace c__file_problem
{
    internal class Program
    {


        /*Write a C# program that performs the following steps:

Search for all text files inside a folder named notes located in drive D:.✔️✅

For each file:

Count the total number of words in the file.

Count how many times the word "Baghdad" appears in the file (case-insensitive).

Display the file name (title) with the following results:

Total word count.✅

Number of times "Baghdad" appears.✅

Analyze the time complexity of your program using Big-O notation.❌*/



        
        static void Main(string[] args)
        {

           
            String FolderPath = @"D:\notes";                                                                // O(1)


            //var Files = Directory.GetFiles(FolderPath);

            //foreach (var File in Files)
            //{
            //    var FileDetails = new FileInfo(File);

            //    Console.WriteLine(FileDetails.Name);
            //}

            //  Second method which is better a bit 

            var dir = new DirectoryInfo(FolderPath);                                                        // O(1)

            var Files = dir.GetFiles();                                                                     // O(f)

          

            //  Count the total number of words in the file.
            //  to get the words count i will use the count class that i have made

            Dictionary<String ,int> FilesWordsCountDictionary = FileClasses.WordCounter(FolderPath);        // O(f x s)



          

            //  Count how many times the word "Baghdad" appears in the file (case-insensitive).

            var FilesWithFrequentWord = FileClasses.FrequentWordCounter(FolderPath,"Baghdad");              // O(f x s) 


            foreach (var file in Files)
            {
                //if(file.Name == FilesWordsCountDictionary.ContainsKey)
                Console.WriteLine($"file Name: {file.Name} \t Words count: {FilesWordsCountDictionary[file.Name]} \t Baghdad count: {FilesWithFrequentWord[file.Name]}");   // O(1)
            }



        }
    }
}
