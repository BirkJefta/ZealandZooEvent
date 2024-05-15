using System.Collections.Generic;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services {
    public class JsonEventRepository:IRepository
    {
        string JsonFileName = @"C:\Users\birko\Desktop\Datamatiker\Obligatoriske opgaver\15-5-2024\Data\JsonEvents.json";
        public static List<Event> GetAllEvents()
        {

        }
    }
}
