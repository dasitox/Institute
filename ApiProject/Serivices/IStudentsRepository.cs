using ApiProject.Models;
using System.Collections.Generic;


namespace ApiProject.Serivices
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);        
        void DeleteStudent(Student student);
        bool ExistStudent(int id);
        bool ExistStudent(string name, string surname);
        bool Save();


        

    }
}
