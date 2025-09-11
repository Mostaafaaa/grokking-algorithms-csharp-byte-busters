using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__streamReader_Problem
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






    //  the class helper has alot of calsses that helps you with your probelms
    public class Helper
    {
        //  checking the File path if it exist

        public static String PathCheck(String FilePath)
        {
            if (File.Exists(FilePath))
            {
                String CheckedFilePath = FilePath;
                return CheckedFilePath;
            }
            else
            {
                throw new ArgumentException("File path doesn't exist",nameof(FilePath));
            }
        }

        //  This class Read the File using StreamReader by
        //  1. First checking the File path using the class above if it exist
        //  2. Reading using stream Reader then
        //  3. geting two values Words and Lines and retuning them using (out)
        public static void FileStreamReader(String FilePath,out List<String> Lines ,out List<String> Words)
        {
            String CheckedFilePath = PathCheck(FilePath);
            using(StreamReader Reader = new StreamReader(CheckedFilePath))
            {
                String Line ;
                Lines = new List<String>();
                Words = new List<String>();
                
                while ((Line = Reader.ReadLine()) != null) 
                {
                    Lines.Add(Line);
                    Words.AddRange(Line.Split(' '));
                }
            }
        }

        //  this class count the number of times the word baghad has metioned in the File
        public static int BaghdadWordCounter(List<String> Words)
        {
            int WordCounter = Words.Where(x => x.Equals("Baghdad", StringComparison.OrdinalIgnoreCase)).Count();
            return WordCounter;
        }


        public static void FileStreamWriter(List<String> Lines)
        {
            String FilePath = "summary.txt";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            using (StreamWriter Wirter = new StreamWriter(FilePath))
            {
                foreach(String line in Lines)
                {
                    Wirter.WriteLine(line);
                }
            }
        }




    }
}
