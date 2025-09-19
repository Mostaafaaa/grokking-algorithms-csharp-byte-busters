using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Transaction
    {// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
       
            public String TransactionID { get; set; }
            public DateOnly Date { get; set; }

            public double Amount { get; set; }
            public String Type { get; set; }
        
        //  making a list for date only
        public static List<DateOnly> dateOnlies = new List<DateOnly>();



        //  making a fuction to collect the values for the date list
        public static void MakingDateOnlyList(List<Transaction> transactions)
        {
            dateOnlies.AddRange(transactions.Select(x=>x.Date));

            
        }

    }


}
