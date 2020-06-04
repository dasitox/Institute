using System.Collections.Generic;
using ApiProject.Models;
using ApiProject.Serivices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;


namespace ApiProject.Controllers
{            
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsRepository _studentsRepository;
        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet()]
        public IActionResult GetStudents()
        {
            var students = _studentsRepository.GetStudents();
            var result = Mapper.Map<IEnumerable<ViewStudentDTO>>(students);             
            return Ok(result);
        }

        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(int studentId)
        {
            var student = _studentsRepository.GetStudent(studentId);
            if (student == null) return BadRequest();
            var result = Mapper.Map<ViewStudentDTO>(student);
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddStudent([FromBody] StudentsDTO studentsDTO)
        {
            if (studentsDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_studentsRepository.ExistStudent(studentsDTO.name, studentsDTO.surname)) return StatusCode(500, "Student Exits");
            var newStudent = Mapper.Map<Student>(studentsDTO);
            var maxId = _studentsRepository.GetStudents();
            int foundMaxId = 0;
            foreach( var stuId in maxId)
            {
                if (stuId.Id > foundMaxId) foundMaxId = stuId.Id;
            }
            newStudent.studentID = foundMaxId + 1;
            _studentsRepository.AddStudent(newStudent);            
            if (!_studentsRepository.Save()) return StatusCode(500, "Please verify your data");
            return CreatedAtRoute("GetStudent", new {studentId = newStudent.Id}, newStudent);
        }

        [HttpPut("{studentId}")]
        public IActionResult PutStudent(int studentId, [FromBody] StudentsDTO studentDTO)
        {
            if (studentDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var student = _studentsRepository.GetStudent(studentId);
            if (student == null) return NotFound();
            Mapper.Map(studentDTO, student);
            if (!_studentsRepository.Save()) return StatusCode(500, "Please verify your data");
            var studentResult = Mapper.Map<ViewStudentDTO>(student);
            return CreatedAtRoute("GetStudent", new { studentId = studentId }, studentResult);
        }

        [HttpPatch("{studentId}")]
        public IActionResult PatchStudent(int studentId,[FromBody] JsonPatchDocument<StudentsDTO> patchDocument)
        {
            if (patchDocument == null) return BadRequest(ModelState);
            if (!_studentsRepository.ExistStudent(studentId)) return StatusCode(500, "Student Exits");
            var student = _studentsRepository.GetStudent(studentId);
            if (student == null) return BadRequest();
            var updateStudent = Mapper.Map<StudentsDTO>(student);
            patchDocument.ApplyTo(updateStudent, ModelState);
            TryValidateModel(updateStudent);
            if (!ModelState.IsValid) return BadRequest();
            Mapper.Map(updateStudent, student);
            if (!_studentsRepository.Save()) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            var studentOrDelete = _studentsRepository.GetStudent(studentId);
            _studentsRepository.DeleteStudent(studentOrDelete);
            if(!_studentsRepository.Save()) return StatusCode(500, "Please verify your data");
            return NoContent();
        }


    }
}