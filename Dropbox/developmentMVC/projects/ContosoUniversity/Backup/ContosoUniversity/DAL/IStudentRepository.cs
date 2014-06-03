using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public interface IStudentRepository : IDisposable
    {
        //CRUD methods
        IEnumerable<Student> GetStudents(); //Returns all students
        Student GetStudentByID(int studentId);  //Returns a single student entity by ID
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
        void Save();
    }
}