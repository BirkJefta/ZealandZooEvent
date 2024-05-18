using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Helpers {
    
    public class JsonFileReader {
        public static List<Event>ReadToJsonEvent(string JsonFileName)
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Event>>(jsonFileReader.ReadToEnd());
            }
        }
        
        public static List<Student>ReadToJsonStudent(string JsonFileName)
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Student>>(jsonFileReader.ReadToEnd());
            }
        }
    }

}
