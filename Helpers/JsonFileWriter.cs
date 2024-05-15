using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Helpers {
    public class JsonFileWriter {
        public static void WriteToJson(List<Event>events,string jsonFileName)
        {
            using (FileStream outputStream = File.OpenWrite(jsonFileName))
            {
                var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Event[]>(writer,@events.ToArray());
            }
        }
    }
}
