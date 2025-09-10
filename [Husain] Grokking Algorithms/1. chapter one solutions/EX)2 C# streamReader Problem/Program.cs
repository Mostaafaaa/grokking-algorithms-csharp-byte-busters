namespace C__streamReader_Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {



            /*
             * Requirements

Read a text file using StreamReader.

Count:

Total lines

Total words

Occurrences of the word “Baghdad” (case-insensitive).

Use LINQ to get the Top 5 most common words.

Write the summary into a new file (summary.txt) using StreamWriter.
             */

            //  path for file
            String FilePath = "TextFile.txt";

            //  line and words init for method FileStreamReader

            List<String> lines;
            List<String> words;

            Helper.FileStreamReader(FilePath,out lines,out words);

            //  get name for show the file name to user

            String FileName = Path.GetFileName(FilePath);


            //  calling Baghdad word counter

            int BaghdadCount = Helper.BaghdadWordCounter(words);




            //  last showing all wanted stuff to the user

            Console.WriteLine($"File: {FileName}");
            Console.WriteLine($"Has a {lines.Count} lines");
            Console.WriteLine($"Has a {words.Count} words");
            Console.WriteLine($"Has a {BaghdadCount} Baghadad word repearted");


            Helper.FileStreamWriter(lines);
            Console.WriteLine("The summary.txt has been written...");





        }
    }
}
