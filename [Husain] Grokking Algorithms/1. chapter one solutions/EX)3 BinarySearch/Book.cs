using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Book
    {
        /*"ISBN": "978-0-1000001",
        "Title": "Book Title 1",
        "Author": "Author 1",
        "Year": 1993*/
        public String ISBN { get; set; }
        public String Title { get; set; }
        public String Author {get ; set;}
        public int Year {get ; set;}

        //  making a list for date only
        public static List<long> ISBN_List = new List<long>();

        //making a fuction to collect the values for the date list
        public static void MakingISBN_List(List<Book> book)
        {
            ISBN_List.AddRange(book.Select(x => Helper.ISBN_StringToLong_Converter(x.ISBN)));
        }


    }
}
