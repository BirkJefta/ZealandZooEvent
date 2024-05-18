using System.Collections.Generic;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Interfaces {
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        Student GetStudent(int id);

        //void UpdateStudent(Event ev);
        void AddStudent(Student student);

        void DeleteStudent(Student student);
        List<Student> FilterStudents(string StudentName);

    }

}    