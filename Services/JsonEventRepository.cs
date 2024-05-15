using System.Collections.Generic;
using ZealandZooEvent.Helpers;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services {
    public class JsonEventRepository:IRepository
    {
        string JsonFileName = @"C:\Users\birko\Desktop\Datamatiker\Obligatoriske opgaver\15-5-2024\Data\JsonEvents.json";
        public List<Event> GetAllEvents()
        {
            return JsonFileReader.ReadToJson(JsonFileName);
        }
    }
}
