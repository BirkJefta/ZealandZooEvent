using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Helpers;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services;

public class JsonStudentRepository : IStudentRepository
{
    static private Student  _loggedInStudent;
    string JsonFileName = @"Data/JsonStudents.json";

    public List<Student> GetAllStudents()
    {
        return JsonFileReader.ReadToJsonStudent(JsonFileName);
    }

    public Student GetStudent(int id)
    {
        foreach (var v in GetAllStudents())
        {
            if (v.Id == id)
            {
                return v;
            }
        }

        return new Student();
    }

    public void UpdateStudent(Student updatedStudent)
    {
        List<Student> students = GetAllStudents();

        if (updatedStudent != null)
        {
            foreach (var student in students)
            {
                if (student.Id == updatedStudent.Id)
                {
                    student.Name = updatedStudent.Name;
                    student.Telephone = updatedStudent.Telephone;
                    student.Email = updatedStudent.Email;
                    student.Password = updatedStudent.Password;
                    student.IdJoinedEvents = updatedStudent.IdJoinedEvents;

                    // Opdater den indloggede student, hvis det er den samme som den opdaterede student
                    if (_loggedInStudent != null && _loggedInStudent.Id == updatedStudent.Id)
                    {
                        _loggedInStudent = student;
                    }

                    break; // Stop loopet, når den opdaterede student er fundet
                }
            }
        }

        JsonFileWriter.WriteToJsonStudent(students, JsonFileName);
    }


    public void AddStudent(Student student)
    {
        List<Student> @students = GetAllStudents().ToList();
        List<int> studentIds = new List<int>();
        foreach (var s in students)
        {
            studentIds.Add(s.Id);
        }
        
        if (studentIds.Count != 0)
        {
            int start = studentIds.Max();
            student.Id = start + 1;
        }
        else
        {
            student.Id = 1;
        }

        students.Add(student);
        JsonFileWriter.WriteToJsonStudent(@students, JsonFileName);
    }


    public bool IsValidUser(string username, string password)
    {
        bool isvalid = false;
        foreach (var v in GetAllStudents())
        {
            if (v.Email == username && v.Password == password)
            {
                isvalid = true;
                _loggedInStudent = v;
            }
        }
        return isvalid;
    }
    public Student LoggedInStudent()
    {
        return _loggedInStudent;
    }
    public void LogOut()
    {
        _loggedInStudent = null;
    }

    public string AddToAttendEvent(Guid eventid)
    {
        
        var student = LoggedInStudent();
        if (student != null)
        {
            if (student.IdJoinedEvents == null)
            {
                student.IdJoinedEvents = new List<Guid>();
            }
            if (student.IdJoinedEvents.Contains(eventid))
            {
                return "AlreadyAdded";
            }
            else
            {
                student.IdJoinedEvents.Add(eventid);
                UpdateStudent(student);
                return "Success";
            }
        }
        return "Failed";
    }
    public void DeleteEventFromStudent(Guid eventid) 
    {
        foreach (var student in GetAllStudents())
        {
            if (student.IdJoinedEvents.Contains(eventid))
            {
                int index = student.IdJoinedEvents.IndexOf(eventid);
                student.IdJoinedEvents.RemoveAt(index);
            }
            UpdateStudent(student);
        }
        
    }
    public List<Event> GetListOfJoinedEvents(Student student)
    {
        IRepository repository = new JsonEventRepository();
        List<Event> events = new List<Event>();

        if (student.IdJoinedEvents != null)
        {
            foreach (Guid joinedid in student.IdJoinedEvents)
            {
                events.Add(repository.SearchById(joinedid));
            }
        }

        return events;
    }
    
     


}