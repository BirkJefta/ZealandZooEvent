using System;
using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Helpers;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services;

public class FakeEventRepository : IRepository
{
    private List<Event> events { get; }
    
    public FakeEventRepository()
    {
        events = new List<Event>();
        Guid UniqueId = Guid.NewGuid();
        events.Add(new Event()
        {
            Id = UniqueId,
            Name = "Zealand Festival",
            Price = 100,
            Location = "Roskilde",
            Time = new DateTime(2024, 5, 17, 16, 0, 0),
            Description = "Musik og ting"
        });
        events.Add(new Event()
        {
            Id = UniqueId,
            Name = "Fodbold",
            Price = 10,
            Location = "Roskilde",
            Time = new DateTime(2024, 6, 20, 16, 0, 0),
            Description = "Fodbold og ting"
        });

    }

    

    public List<Event> GetAllEvents()
    {
        return events;
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
        if (@evt != null)
        {
            foreach (var e in GetAllEvents())
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
    }
    
    public void AddEvent(Event ev)
    {
        Guid id = ev.Id;
        GetAllEvents().Add(ev);
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

    }
    
    public List<Event> FilterEvents(string eventName)
    {
        List<Event> FilteredList = new List<Event>();
        foreach (var ev in GetAllEvents())
        {
            if (ev.Name.Contains(eventName))
            {
                FilteredList.Add(ev);
            }
        }
        return FilteredList;
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