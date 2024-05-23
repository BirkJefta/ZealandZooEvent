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
        void DeleteStudent(Student student);
        List<Student> FilterStudents(string StudentName);
        public Student LoggedInStudent();
        bool IsValidUser(string username, string password);
        void LogOut();
        public string AddToAttendEvent(Guid eventid);
        public List<Event> GetListOfJoinedEvents(Student student);
    }

}    