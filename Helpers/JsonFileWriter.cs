using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Helpers {
    public class JsonFileWriter {
        public static void WriteToJsonEvent(List<Event>events,string jsonFileName)
        {
            
                string json = JsonSerializer.Serialize(events);

                File.WriteAllText(jsonFileName, json);
                

        }
        
        public static void WriteToJsonStudent(List<Student>students,string jsonFileName)
        {
            
            string json = JsonSerializer.Serialize(students);

            File.WriteAllText(jsonFileName, json);
                
        }
    }
}
