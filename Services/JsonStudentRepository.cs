using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Helpers;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services;

public class JsonStudentRepository : IStudentRepository
{
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

    // public void UpdateEvent(Event @evt)
    // {
    //     List<Student> @students = GetAllStudents().ToList();
    //     if (@evt != null)
    //     {
    //         foreach (var e in @students)
    //         {
    //             if (e.Id == @evt.Id)
    //             {
    //                 e.Id = evt.Id;
    //                 e.Name = evt.Name;
    //                 e.Price = evt.Price;
    //                 e.Description = evt.Description;
    //                 e.Time = evt.Time;
    //                 e.Location = evt.Location;
    //             }
    //         }
    //     }
    //
    //     JsonFileWriter.WriteToJsonStudent(@events, JsonFileName);
    // }

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


}