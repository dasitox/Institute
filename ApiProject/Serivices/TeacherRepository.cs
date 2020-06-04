using ApiProject.EFModels;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Serivices
{
    public class TeacherRepository : ITeacherRepository
    {
        private IadesContext _context;
        public TeacherRepository(IadesContext context)
        {
            _context = context;
        }

        public void AddTeacher(Teacher teacher)
        {
            _context.teachers.Add(teacher);
        }

        public void DeleteTeacher(Teacher teacher)
        {
            _context.teachers.Remove(teacher);
        }

        public bool ExistTeacher(int id)
        {
            return _context.teachers.Any(c => c.teacherID == id);
        }

        public bool ExistTeacher(string name, string surname)
        {
            return _context.teachers.Any(t => t.name == name && t.surname == surname);
        }

        public Teacher GetTeacher(int teacherID)
        {
            return _context.teachers.Where(t => t.Id == teacherID).FirstOrDefault();
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.teachers.ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
