using System;
using System.Collections.Generic;

namespace ZealandZooEvent.Models;

public class FakeEventRepository
{
    private List<Event> events { get; }

    public FakeEventRepository()
    {
        events = new List<Event>();
        events.Add(new Event()
        {
            Name = "Zealand Festival", Price = 100, Location = "Roskilde", Time = new DateTime(2024, 5, 17, 16, 0, 0),
            Description = "Musik og ting"
        });
        events.Add(new Event()
        {
            Name = "Fodbold", Price = 10, Location = "Roskilde", Time = new DateTime(2024, 6, 20, 16, 0, 0),
            Description = "Musik og ting"
        });

    }

    public List<Event> GetAllEvents()
    {
        return events;
        
    }

}  