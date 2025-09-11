using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace c__file_problem
{
    class FileClasses
    {

        //  using StreamReader to slow the Reading of file byte by byte 
       
        static public List<String> StreamReader(String FilePath)
        {

            using (StreamReader reader = new StreamReader(FilePath)) {

                String Line;
                List<String> AllWordsOfFile =new List<String>() ;
                while ((Line = reader.ReadLine()) != null)
                {
                    var WordForEachLine = Line.Split(' ');


                    AllWordsOfFile.AddRange(WordForEachLine);

                }

                return AllWordsOfFile;


            }




        }



        //  linq instead of foreach
        //  stream instead of ReadAllText
        //

        //  This method Counts the total number of words Foreach file inside a folder .

        public static Dictionary<string, int> WordCounter(string FolderPath)                            //  Total is O(f x s)
        {
            var dir = new DirectoryInfo(FolderPath);                                                    //  O(1)

            var Files = dir.GetFiles();                                                                 //  O(f) where f is the number of files



           
            //  first read the file text next count the word of the file and last return words count

            var FilesWordsCountDictionary = new Dictionary<string, int>();                               //  O(1)
            foreach (var file in Files)                                                                  //  O(f) 
            {


                //  count words using StreamReader class to read the text from file

                List<String> AllFileWords = StreamReader(file.FullName);


                int CountWords = AllFileWords.Count;                                                      // O(1)

                FilesWordsCountDictionary[file.Name] = CountWords;                                        // O(1)
            }
    
            return FilesWordsCountDictionary;
        }



        //  Count how many times the word "Baghdad" appears in the file (case-insensitive).

        public static Dictionary<string, int> FrequentWordCounter(string FolderPath,string FrequentWord)    //  Total is O(f x s)
        {
            var dir = new DirectoryInfo(FolderPath);                                                        // O(1)

            var Files = dir.GetFiles();                                                                     // O(f)



            //  first read the file text next turn String text to Word by Word match collcection
            //  next check for frequent word using linq + regex last return the word count
            var FilesWordCountDictionary = new Dictionary<string, int>();                                    // O(1)
            foreach (var file in Files)                                                                      // O(f)
            {
                List<String> AllFileWords = StreamReader(file.FullName);                            // O(s)


                //  regex to count word frequent
                               
                int CountingTheWord = 0;                                                                     // O(1)


                //foreach (var word in AllFileWords)                                                           // O(w) where w is number of Words = O(s)
                //{
                //    if (String.Compare(word.ToString(), FrequentWord, true) == 0)
                //    {

                //        CountingTheWord++;                                                                   // O(1)
                //    }
                //}
                int FequentWordsCount=0;
                FequentWordsCount += AllFileWords.Where(x => (String.Compare(x, FrequentWord) == 0)).Count();


                FilesWordCountDictionary[file.Name] = FequentWordsCount;                                       // O(1)

            }

            return FilesWordCountDictionary;
        }

    }
}
