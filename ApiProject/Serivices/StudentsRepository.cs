using System.Collections.Generic;
using System.Linq;
using ApiProject.EFModels;
using ApiProject.Models;

namespace ApiProject.Serivices
{
    public class StudentsRepository : IStudentsRepository
    {
        private IadesContext _context;
        public StudentsRepository(IadesContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _context.students.Remove(student);
        }
                
        public bool ExistStudent(int id)
        {
            return _context.students.Any(s => s.studentID == id);
        }

        public Student GetStudent(int id)
        {
            return _context.students.Where(s => s.studentID == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.students.OrderBy(s=> s.surname).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ExistStudent(string name, string surname)
        {
            return _context.students.Any(s => s.name == name && s.surname == surname);
        }
    }
}
