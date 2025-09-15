

using BinarySearch;
using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        int ValueTime = 10;

        int[] Time = new int[100];

        for (int i = 0; i < 100;  i++)
        {
            Time[i] = ValueTime;
            ValueTime += 15;
        }
        
        string BankTransactionsFilePath = @"D:\CSharp\Halal almshakl\teleByte-gorkking-algorthims\BinarySearch\Data\bank_transactions.json";
        var transactions = FileReader.LoadJsonFile<Transaction>(BankTransactionsFilePath);
        string LibraryBooksFilePath = @"D:\CSharp\Halal almshakl\teleByte-gorkking-algorthims\BinarySearch\Data\library_books.json";
        var books = FileReader.LoadJsonFile<Book>(LibraryBooksFilePath);

        while (true)
        {
            Console.WriteLine("====== Binary Search System ======");
            Console.WriteLine("1. Search in Delivery Time");
            Console.WriteLine("2. Search in Transactions by Date");
            Console.WriteLine("3. Search in Books by ISBN");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Time e.g (10, 25, 40 .. etc)\nTime: ");
                    int Taraget = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    int tr = BinarySearchHelper.BinarySearchOrClosest(Time, Taraget);
                    if (tr != -1)
                    {
                        Console.WriteLine("Delivery Target Not found..");
                        Console.WriteLine($"Next Delivery Target: {Time[tr]} on index {tr}\n");
                    }
                    break;
                case "2":
                    if (transactions.Count == 0)
                    {
                        Console.WriteLine("No transactions loaded. Load data first.\n");
                        break;
                    }
                    Console.Write("Enter date to search (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime targetDate))
                    {
                        int index = Transaction.BinarySearchByDate(transactions, targetDate);
                        if (index != -1)
                        {
                            Console.WriteLine($"Closest Transaction: {transactions[index].TransactionID} on {transactions[index].Date:yyyy-MM-dd} \n" +
                                $"Amount: {transactions[index].Amount}$\n" +
                                $"Type: {transactions[index].Type}\n");
                        }
                        else
                        {
                            Console.WriteLine("No transaction found after this date.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.\n");
                    }
                    break;

                case "3":
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books loaded. Load data first.\n");
                        break;
                    }

                    Console.Write("Enter ISBN to search: ");
                    string targetISBN = Console.ReadLine();

                    int bookIndex = Book.BinarySearchByISBN(books, targetISBN);
                    if (bookIndex != -1)
                    {
                        Console.WriteLine($"Closest Book: {books[bookIndex].Title}\n" +
                            $"(ISBN: {books[bookIndex].ISBN})\n" +
                            $"Author: {books[bookIndex].Author}\n" +
                            $"Year: {books[bookIndex].Year}\n");
                    }
                    else
                    {
                        Console.WriteLine("Book would be after the last one.\n");
                    }
                    break;

                case "4":
                    Console.WriteLine("Goodbye <3 ");
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.\n");
                    break;
            }
        }
    }
}