using System;
using System.Collections.Generic;

namespace ZealandZooEvent.Models;

public class FakeEventRepository
{
    private List<Event> events { get; }
    private static FakeEventRepository _instance;

    private FakeEventRepository()
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
    public static FakeEventRepository Instance
    {
        get 
        { 
            if (_instance == null)
            {
                _instance = new FakeEventRepository();
            }
            return _instance;
        }

        
    }

    public List<Event> GetAllEvents()
    {
        return events;
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

}  