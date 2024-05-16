using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Helpers;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services
{
    public class JsonEventRepository : IRepository
    {
        string JsonFileName = @"Data/JsonEvents.json";

        public List<Event> GetAllEvents()
        {
            return JsonFileReader.ReadToJson(JsonFileName);
        }

        public Event GetEvent(int id)
        {
            foreach (var v in GetAllEvents())
            {
                if (v.Id == id)
                {
                    return v;
                }
            }

            return new Event();
        }

        public void UpdateEvent(Event @evt)
        {
            List<Event> @events = GetAllEvents().ToList();
            if (@evt != null)
            {
                foreach (var e in @events)
                {
                    if (e.Id == @evt.Id)
                    {
                        e.Id = evt.Id;
                        e.Name = evt.Name;
                        e.Price = evt.Price;
                        e.Description = evt.Description;
                        e.Time = evt.Time;
                        e.Location = evt.Location;
                    }
                }
            }

            JsonFileWriter.WriteToJson(@events, JsonFileName);
        }

        public void AddEvent(Event ev)
        {
            List<Event> @events = GetAllEvents().ToList();
            List<int> eventIds = new List<int>();
            foreach (var evt in events)
            {
                eventIds.Add(evt.Id);
            }

            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                ev.Id = start + 1;
            }
            else
            {
                ev.Id = 1;
            }

            events.Add(ev);
            JsonFileWriter.WriteToJson(@events, JsonFileName);
        }

    }
}
