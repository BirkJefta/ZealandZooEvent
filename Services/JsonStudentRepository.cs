using Microsoft.Extensions.Logging;
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

    public void UpdateStudent(Student @sdt)
    {
        List<Student> @students = GetAllStudents().ToList();
        if (@sdt != null)
        {
            foreach (var s in @students)
            {
                if (s.Id == sdt.Id)
                {
                    s.Id = sdt.Id;
                    s.Name = sdt.Name;
                    s.Telephone = sdt.Telephone;
                    s.Email = sdt.Email;
                    s.Password = sdt.Password;
                    s.IdJoinedEvents = sdt.IdJoinedEvents;
                }
            }
        }

        JsonFileWriter.WriteToJsonStudent(@students, JsonFileName);
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

    public void DeleteStudent(Student student)
    {
        List<Student> students = GetAllStudents().ToList();

        // Use reverse loop to avoid issues with modifying the collection while iterating
        for (int i = students.Count - 1; i >= 0; i--)
        {
            if (student.Id == students[i].Id)
            {
                students.RemoveAt(i);
            }
        }

        JsonFileWriter.WriteToJsonStudent(students, JsonFileName);
    }



    public List<Student> FilterStudents(string studentName)
    {
        List<Student>FilteredStudentList = new List<Student>();
        List<Student>@students = GetAllStudents().ToList();
        string lowerStudentName = studentName.ToLower();
        foreach (var student in @students)
        {
            if(student.Name.ToLower().Contains(lowerStudentName))
            {
                FilteredStudentList.Add(student);
            }
        }
        if (studentName != "")
        {
            return FilteredStudentList;
        }
        return @students;
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

    public string AddToAttendEvent(int eventid)
    {
        
        var student = LoggedInStudent();
        if (student != null)
        {
            if (student.IdJoinedEvents == null)
            {
                student.IdJoinedEvents = new List<int>();
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
    public void DeleteEventFromStudent(int eventid) 
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
        foreach (int joinedid in student.IdJoinedEvents)
        {
            events.Add(repository.SearchById(joinedid));
        }
        return events;
    }
    
     


}