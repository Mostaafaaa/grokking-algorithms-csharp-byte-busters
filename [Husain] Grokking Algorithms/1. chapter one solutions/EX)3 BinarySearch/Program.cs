using System.Text.Json;
using static System.TimeZoneInfo;
using System.Linq;

namespace BinarySearch;

internal class Program
{
    static void Main(string[] args)
    {

        //  Reading Json File And deserializing it Using StreamReader+JsonReader

        //  for bank transactions
        LargJsonFileStreamReaderClass.NewList<Transaction>("bank_transactions.json",Helper.Transactions);
        //  for Library books
        LargJsonFileStreamReaderClass.NewList<Book>("library_books.json",Helper.Books);


        //  Making list for Targeted attribute

        //  for bank transactions
        Transaction.MakingDateOnlyList(Helper.Transactions);

        //  for Library books
        Book.MakingISBN_List(Helper.Books);

        //  Book.MakingISBN_List(Helper.Books);
        while (true)
        {
            Console.Write("""
            
            ┌────────────────────────────────┐
            │         Binary Search          │
            └────────────────────────────────┘
            1) Bank Transaction
            2) Library Books
            ->
            """);
            int Choise = Convert.ToInt32(Console.ReadLine());
            switch (Choise)
            {
                case 1:
                    {
                        Console.Write("""
            
            ┌────────────────────────────────┐
            │        Bank Transaction        │
            └────────────────────────────────┘
            1) Show All Bank Transactions
            2) Search Bank Transaction
            ->
            """);
                        int TransactionChoise = Convert.ToInt32(Console.ReadLine());
                        switch (TransactionChoise)
                        {
                            case 1:
                                {
                                    Helper.ShowTransactions();
                                    break;
                                }
                            case 2:
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter the Transaction Time: ");
                                        DateOnly TimeTarget = DateOnly.Parse(Console.ReadLine());
                                        int TimeIndexIfExists = Helper.DateSearchOrCloseTo(TimeTarget, Transaction.dateOnlies, out DateOnly Right);

                                        if (TimeIndexIfExists > -1)
                                        {
                                            DateOnly TransactionTime = Transaction.dateOnlies[TimeIndexIfExists];
                                            Console.WriteLine($"Yes there is a Transaction at this time ({TransactionTime})");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"There is no Transaction at this time however There is one at {Right}");
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("You Writed the Time fromat (DD/MM/YYYY) wrong please try again...");
                                        Console.WriteLine(ex);
                                    }
                                    break;
                                }
                            default: { break; }
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("""
            
            ┌────────────────────────────────┐
            │         Library Books          │
            └────────────────────────────────┘
            1) Show All Books
            2) Search for a book
            ->
            """);
                        int LibraryChoise = Convert.ToInt32(Console.ReadLine());
                        switch (LibraryChoise)
                        {
                            case 1:
                                {
                                    Helper.ShowBooks();
                                    break;
                                }
                            case 2:
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter the Book ISBN: ");
                                        String BookTarget = Console.ReadLine();

                                        if (!Helper.Check_ISBN_Form(BookTarget))
                                        {
                                            Console.WriteLine("The Form you entered is wrong please try again with the right form...");
                                        }
                                        else
                                        {
                                            //  turning ISBN to Long so i can Do Binary Search on 

                                            long BookTargetInLongForm = Helper.ISBN_StringToLong_Converter(BookTarget);

                                            //  Searching for the book using ISBN

                                            int BookIndexIfExists = Helper.BookSearchOrCloseTo(BookTargetInLongForm, Book.ISBN_List, out int Right, out int Left);

                                            if (BookIndexIfExists > -1)
                                            {
                                                
                                                var BookWanted = Helper.Books[BookIndexIfExists];
                                                Console.WriteLine($"Yes there is the Book you wanted it ({BookWanted.Title} - {BookWanted.ISBN} - {BookWanted.Author} - {BookWanted.Year})");

                                                //  to remove the Book just bought we remove it from the Search list
                                                var BookISBNToRemove = Book.ISBN_List[BookIndexIfExists];
                                                Book.ISBN_List.Remove(BookISBNToRemove);
                                            }
                                            else
                                            {
                                                var LeftBookISBN = Helper.Books[Left].ISBN;
                                                var RightBookISBN = Helper.Books[Right].ISBN;

                                                Console.WriteLine($"There is no book with this ISBN however it should be between {LeftBookISBN} and {RightBookISBN} ");
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("You Writed the Time fromat (DD/MM/YYYY) wrong please try again...");
                                        Console.WriteLine(ex);
                                    }
                                    break;
                                }
                            default:
                                { break; }
                        }
                        break;
                    }
            }
        }
        } 
}     

