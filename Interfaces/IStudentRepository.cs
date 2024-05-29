using System;
using System.Collections.Generic;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Interfaces {
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudent(int id);
        void UpdateStudent(Student sdt);
        void AddStudent(Student student);
        void DeleteEventFromStudent(Guid id);
        Student LoggedInStudent();
        bool IsValidUser(string username, string password);
        void LogOut();
        string AddToAttendEvent(Guid eventid);
        List<Event> GetListOfJoinedEvents(Student student);
    }

}    