using System;
using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Services;

public class FakeStudentRepository : IStudentRepository
{
    private List<Student> students { get; set; }
    

    // public FakeStudentRepository()
    // {
    //     students = new List<Student>();
    //     students.Add(new Student()
    //     {
    //         Id = 1,
    //         Name = "Ole",
    //         Email = "",
    //         Telephone = ""
    //     });
    //     students.Add(new Student()
    //     {
    //         Id = 2,
    //         Name = "Else",
    //         Email = "",
    //         Telephone = ""
    //     });
    //
    // }

    

    public List<Student> GetAllStudents()
    {
        return students;
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
    //     if (@evt != null)
    //     {
    //         foreach (var e in GetAllEvents())
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
    // }
    
    public void AddStudent(Student student)
    {
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

    }

    public List<Student> FilterStudents(string studentName)
    {
        List<Student> filteredStudentList = new List<Student>();
        foreach (var student in GetAllStudents())
        {
            if (student.Name.Contains(studentName))
            {
                filteredStudentList.Add(student);
            }
        }
        return filteredStudentList;
    }



}