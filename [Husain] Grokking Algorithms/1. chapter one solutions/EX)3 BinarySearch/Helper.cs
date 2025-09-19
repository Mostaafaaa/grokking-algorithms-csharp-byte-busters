using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace BinarySearch;

public class Helper
{
    public static void SearchOrCloseTo(int Target, int[] SortedArrayOfNumbers)
    {



        foreach (int i in SortedArrayOfNumbers)
        {
            Console.WriteLine(i);
        }

        int High = SortedArrayOfNumbers.Count() - 1;
        int Low = 0;
        int Right = 0;
        int Left = 0;

        while (High >= Low)
        {
            int Mid = (Low + High) / 2;

            if (Target == SortedArrayOfNumbers[Mid])
            {
                Console.WriteLine($"We have Found the Target {SortedArrayOfNumbers[Mid]} and it's index is {Mid}");
                break;
            }


            else if (Target > SortedArrayOfNumbers[Mid])
            {
                Low = Mid + 1;
                Left = SortedArrayOfNumbers[Mid];
            }
            else
            {
                High = Mid - 1;
                Right = SortedArrayOfNumbers[Mid];
            }

        }

        if ((Target - Left) < (Right - Target))
        {
            Console.WriteLine($"the most colse number is {Left}");
        }

        else if ((Target - Left) > (Right - Target))
        {
            Console.WriteLine($"the most colse number is {Right}");
        }
        else
        {

            Console.WriteLine($"the Target is colse to both {Left} which is left and {Right} which is Right");
        }
    }
    public static String Search(int Target, int[] SortedArrayOfNumbers)
    {

        int High = SortedArrayOfNumbers.Count() - 1;
        int Low = 0;
        int Right = 0;
        int Left = 0;

        while (High >= Low)
        {
            int Mid = (Low + High) / 2;

            if (Target == SortedArrayOfNumbers[Mid])
            {
                return Mid.ToString();

            }
            else if (Target > SortedArrayOfNumbers[Mid])
            {
                Low = Mid + 1;
                Left = SortedArrayOfNumbers[Mid];
            }
            else
            {
                High = Mid - 1;
                Right = SortedArrayOfNumbers[Mid];
            }
        }
        return null;
    }


    //  Binary Search
    //  Searches for a specific date if not fount return -1
    //  Right here is the next Transaction
    public static int DateSearchOrCloseTo(DateOnly Target, List<DateOnly> SortedArrayOfNumbers,out DateOnly Right)
    {
        int High = SortedArrayOfNumbers.Count() - 1;
        int Low = 0;
        Right = new DateOnly();
        while (High >= Low)
        {
            int Mid = (Low + High) / 2;
            if (Target == SortedArrayOfNumbers[Mid])
            {
                return Mid;
            }
            else if (Target > SortedArrayOfNumbers[Mid])
            {
                Low = Mid + 1;
            }
            else
            {
                High = Mid - 1;
                Right = SortedArrayOfNumbers[Mid];
            }
        }
        return -1;    
    }
    //  Left and Right here are the Books around the wanted book
    public static int BookSearchOrCloseTo(long Target, List<long> SortedArrayOfNumbers, out int Right, out int Left)
    {


        int High = SortedArrayOfNumbers.Count() - 1;
        int Low = 0;
        Right = new int();
        Left = new int();


        while (High >= Low)
        {
            int Mid = (Low + High) / 2;

            if (Target == SortedArrayOfNumbers[Mid])
            {
                return Mid;
            }


            else if (Target > SortedArrayOfNumbers[Mid])
            {
                Low = Mid + 1;
                Left = Mid;
            }
            else
            {
                High = Mid - 1;
                Right = Mid;
            }

        }

        //  if the book ISBN doesnt exit return -1

        return -1;
        
    }




    //  making List for Objects of Transaction

    public static List<Transaction> Transactions = new List<Transaction>();
    public static void TransactionsJsonStreamReaderClass(String JsonFilePath)
    {
        using (var Reader = new StreamReader(JsonFilePath))
        using (var jsonTextReader = new JsonTextReader(Reader))
        {
            while (jsonTextReader.Read())
            {
                Transaction transaction;
                var Serializer = new JsonSerializer();
                if (jsonTextReader.TokenType == JsonToken.StartObject)
                {
                    transaction = Serializer.Deserialize<Transaction>(jsonTextReader);               
                    if (transaction != null)
                        Transactions.Add(transaction);
                }
            }
        }
    }
    //  making List for Objects of Book

    public static List<Book> Books = new List<Book>();
    public static void BooksJsonStreamReaderClass(String JsonFilePath)
    {
        using (var Reader = new StreamReader(JsonFilePath))
        using (var jsonTextReader = new JsonTextReader(Reader))
        {
            while (jsonTextReader.Read())
            {
                Book book;
                var Serializer = new JsonSerializer();
                if (jsonTextReader.TokenType == JsonToken.StartObject)
                {
                    book = Serializer.Deserialize<Book>(jsonTextReader);
                    if (book != null)
                        Books.Add(book);
                }


            }
        }
    }



    //  show all the Transactions availabe with full details 
    public static void ShowTransactions()
    {

        Console.Write(           
            "\t\t\t┌────────────────────────────────┐\n" +
            "\t\t\t│     All Bank Transactions      │\n" +
            "\t\t\t└────────────────────────────────┘\n" );
                
        foreach (var Transaction in Transactions)
        {

            Console.WriteLine($"\tName: {Transaction.TransactionID} \tTimeStamp: {Transaction.Date} \tAmount: {Transaction.Amount} \tType: {Transaction.Type}");
        }
    }

    //  show all the books availabe with full details 
    public static void ShowBooks()
    {

        Console.Write(
            "\t\t\t┌────────────────────────────────┐\n" +
            "\t\t\t│     All Bank Transactions      │\n" +
            "\t\t\t└────────────────────────────────┘\n");

        foreach (var book in Books)
        {

            Console.WriteLine($"\tISBN: {book.ISBN} \tTitle: {book.Title} \tAuthor: {book.Author} \tYear: {book.Year}");
        }
    }



    //  ISBN Form

    //  method to make sure its in ISBN form
    //"978-0-1000005"
    public static bool Check_ISBN_Form(String FormToCheck)
    {
        bool MatchTheForm = Regex.IsMatch(FormToCheck, @"\d\d\d-\d-\d{7}");
        return MatchTheForm;
    }

    //  turning ISBN to Long so i can Do Binary Search on it
    public static long ISBN_StringToLong_Converter(String StringForm)
    {
        var P1 = StringForm.Split('-');
        var P2 = String.Concat(P1);
       
        long ISBN_CharForm = Convert.ToInt64(P2);  

        return ISBN_CharForm;
    }


}