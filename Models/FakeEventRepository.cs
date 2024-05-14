using System;
using System.Collections.Generic;
using System.Linq;

namespace ZealandZooEvent.Models;

public class FakeEventRepository
{
    private List<Event> events { get; }

    public FakeEventRepository()
    {
        events = new List<Event>();
        events.Add(new Event()
        {
            Id = 1, Name = "Zealand Festival", Price = 100, Location = "Roskilde", Time = new DateTime(2024, 5, 17, 16, 0, 0),
            Description = "Musik og ting"
        });
        events.Add(new Event()
        {
            Id = 2, Name = "Fodbold", Price = 10, Location = "Roskilde", Time = new DateTime(2024, 6, 20, 16, 0, 0),
            Description = "Fodbold og ting"
        });

    }

    public List<Event> GetAllEvents()
    {
        return events;
        
    }

    public void AddEvent(Event ev)
    {
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
    }

}  