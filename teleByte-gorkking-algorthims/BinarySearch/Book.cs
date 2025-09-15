using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public static int BinarySearchByISBN(List<Book> list, string targetISBN)
        {
            int left = 0;
            int right = list.Count - 1;
            int mid;
            int compre;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                compre = string.Compare(list[mid].ISBN, targetISBN);

                if (compre == 0)
                    return mid; 
                else if (compre < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left < list.Count ? left : -1;
        }
    }
}
