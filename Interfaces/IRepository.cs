using System;
using System.Collections.Generic;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Interfaces {
    public interface IRepository {
        List<Event> GetAllEvents();
        Event GetEvent(Guid id);
        void UpdateEvent(Event ev);
        void AddEvent(Event ev);
       
        void DeleteEvent(Event ev);
        List<Event> FilterEvents(string EventName);
        public Event SearchById(Guid id);
    }
}