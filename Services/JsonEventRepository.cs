using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Helpers;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services;

public class JsonEventRepository : IRepository
{
    string JsonFileName = @"Data/JsonEvents.json";

    public List<Event> GetAllEvents()
    {
        List<Event>events = JsonFileReader.ReadToJsonEvent(JsonFileName);
        List<Event> OrderedEvents = events.OrderBy(evt=>evt.Time).ToList();
        return OrderedEvents;
    }

    public Event GetEvent(Guid id)
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
                    if (e.Id == @evt.Id)
                    {
                        e.Id = evt.Id;
                        e.Name = evt.Name;
                        e.Price = evt.Price;
                        e.Description = evt.Description;
                        e.Time = evt.Time;
                        e.Location = evt.Location;
                        e.PictureUrl = evt.PictureUrl;
                    }
                }
            }
        }

        JsonFileWriter.WriteToJsonEvent(@events, JsonFileName);
    }

    


    public void AddEvent(Event ev)
    {
        List<Event> @events = GetAllEvents().ToList();
        Guid UniqueId = Guid.NewGuid();
        ev.Id = UniqueId;

        //List<Event> @events = GetAllEvents().ToList();
        //List<int> eventIds = new List<int>();
        //foreach (var evt in events)
        //{
        //    eventIds.Add(evt.Id);
        //}
        //events[0].maxId += 1;
        //ev.Id = events[0].maxId;

        //if (eventIds.Count != 0)
        //{
        //    int start = eventIds.Max();
        //    ev.Id = start + 1;
        //}
        //else
        //{
        //    ev.Id = 1;
        //}

        events.Add(ev);
        JsonFileWriter.WriteToJsonEvent(@events, JsonFileName);
    }

    public void DeleteEvent(Event ev)
    {
        List<Event> events = GetAllEvents().ToList();
        
        // Use reverse loop to avoid issues with modifying the collection while iterating
        for (int i = events.Count - 1; i >= 0; i--)
        {
            if (ev.Id == events[i].Id)
            {
                events.RemoveAt(i);
            }
        }

        JsonFileWriter.WriteToJsonEvent(events, JsonFileName);
    }



    public List<Event> FilterEvents(string eventName)
    {
        List<Event>FilteredList = new List<Event>();
        List<Event>@events = GetAllEvents().ToList();
        string lowerEventName = eventName.ToLower();
        foreach (var ev in @events)
        {
            if(ev.Name.ToLower().Contains(lowerEventName))
            {
                FilteredList.Add(ev);
            }
        }
        if (eventName != null)
        {
            return FilteredList;
        }
        return @events;
    }
    public Event SearchById(Guid id)
    {
        Event EventWithId = null;
        foreach (var v in GetAllEvents())
        {
            if (v.Id == id)
            {
                EventWithId = v;
            }
        }
        return EventWithId;
    }


}