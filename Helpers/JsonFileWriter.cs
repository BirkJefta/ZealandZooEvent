using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Helpers {
    public class JsonFileWriter {
        public static void WriteToJson(List<Event>events,string jsonFileName)
        {
            
                string json = JsonSerializer.Serialize(events);

                File.WriteAllText(jsonFileName, json);

            


        }
    }
}
