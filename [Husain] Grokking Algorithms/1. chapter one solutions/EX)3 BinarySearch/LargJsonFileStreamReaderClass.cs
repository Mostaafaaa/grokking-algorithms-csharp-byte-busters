using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BinarySearch
{
    public class LargJsonFileStreamReaderClass
    {

        //public static List<Book> Books = new List<Book>();

        public static void NewList<T>(String JsonFilePath,List<T> list)
        {
            
            using (var Reader = new StreamReader(JsonFilePath))
            using (var jsonTextReader = new JsonTextReader(Reader))
            {

                while (jsonTextReader.Read())
                {
                    var Serializer = new JsonSerializer();
                    if (jsonTextReader.TokenType == JsonToken.StartObject)
                    {
                        var Obj = Serializer.Deserialize<T>(jsonTextReader);
                        if (Obj != null)
                            list.Add(Obj);
                    }
                }
            }
        }
    }
}
