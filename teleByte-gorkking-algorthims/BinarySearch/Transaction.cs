using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Transaction
    {
        public string TransactionID { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Type { get; set; }

        public static int BinarySearchByDate(List<Transaction> Transactions, DateTime targetDate)
        {
            int left = 0;
            int right = Transactions.Count - 1;
            int mid;

            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (Transactions[mid].Date == targetDate)
                {
                    return mid;
                }
                else if (Transactions[mid].Date < targetDate)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left < Transactions.Count ? left : -1;
        }
    }
}

