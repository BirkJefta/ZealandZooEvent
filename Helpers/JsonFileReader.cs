using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Helpers {
    public class JsonFileReader {
        public static List<Event>ReadToJson(string JsonFileName)
        {
            using(var jsonFilReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Event>>(jsonFilReader.ReadToEnd());
            }
        }
    }
}
