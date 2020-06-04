using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Serivices
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeachers();
        Teacher GetTeacher(int teacherId);
        void AddTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
        bool ExistTeacher(int id);
        bool ExistTeacher(string name, string surname);
        bool Save();
    }
}
