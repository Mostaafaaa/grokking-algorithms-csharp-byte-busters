using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace BinarySearch
{
    public class FileReader
    {
        public static List<T> LoadJsonFile<T>(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("\njson file not found. Returning empty list");
                return new List<T>();
            }

            string json = File.ReadAllText(FilePath);

            try
            {
                List<T>? list = JsonSerializer.Deserialize<List<T>>(json);
                if (list == null)
                    return new List<T>();

                Console.WriteLine($"Loaded {list.Count} from {Path.GetFileName(FilePath)}\n");
                
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError loading file.json: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
