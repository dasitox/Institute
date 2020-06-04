using System.Collections.Generic;
using ApiProject.Serivices;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiProject.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeacherRepository _teacherRepository;
        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet()]
        public IActionResult GetTeachers()
        {
            var teacher = _teacherRepository.GetTeachers();
            var result = Mapper.Map<IEnumerable<ViewTeacherDTO>>(teacher);
            return Ok(result);
        }

        [HttpGet("{teacherId}", Name ="GetTeacher")]
        public IActionResult GetTeacher(int teacherId)
        {
            var teacher = _teacherRepository.GetTeacher(teacherId);
            if (teacher == null) return NotFound();
            var result = Mapper.Map<ViewTeacherDTO>(teacher);
            return Ok(teacher);
        }

        [HttpPost()]
        public IActionResult AddTeacher([FromBody] TeachersDTO teacherDTO)
        {
            if (teacherDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_teacherRepository.ExistTeacher(teacherDTO.name,teacherDTO.surname)) return StatusCode(500, "Student Exits");
            var newTeacher = Mapper.Map<Teacher>(teacherDTO);
            var maxId = _teacherRepository.GetTeachers();
            int foundMaxId = 0;
            foreach (var teacherId in maxId)
            {
                if (teacherId.Id > foundMaxId) foundMaxId = teacherId.Id;
            }
            newTeacher.teacherID = foundMaxId + 1;
            newTeacher.Id = foundMaxId + 1;
            _teacherRepository.AddTeacher(newTeacher);
            if (!_teacherRepository.Save()) return StatusCode(500, "Please verify your data");
            return CreatedAtRoute("GetTeacher", new { teacherId = newTeacher.Id }, newTeacher);
        }

        [HttpPut("{teacherId}")]
        public IActionResult PutStudent(int teacherId, [FromBody] TeachersDTO teacherDTO)
        {
            if (teacherDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var teacher = _teacherRepository.GetTeacher(teacherId);
            if (teacher == null) return NotFound();
            Mapper.Map(teacherDTO, teacher);
            if (!_teacherRepository.Save()) return StatusCode(500, "Please verify your data");
            var teacherResult = Mapper.Map<ViewTeacherDTO>(teacher);
            return CreatedAtRoute("GetTeacher", new { studentId = teacherId }, teacherResult);
        }

        [HttpPatch("{teacherId}")]
        public IActionResult PatchTeacher(int teacherId, [FromBody] JsonPatchDocument<TeachersDTO> patchDocument)
        {
            if (patchDocument == null) return BadRequest(ModelState);
            if (!_teacherRepository.ExistTeacher(teacherId)) return StatusCode(500, "Student Exits");
            var teacher = _teacherRepository.GetTeacher(teacherId);
            if (teacher == null) return BadRequest();
            var updateTeacher = Mapper.Map<TeachersDTO>(teacher);
            patchDocument.ApplyTo(updateTeacher, ModelState);
            TryValidateModel(updateTeacher);
            if (!ModelState.IsValid) return BadRequest();
            Mapper.Map(updateTeacher,teacher);
            if (!_teacherRepository.Save()) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{teacherId}")]
        public IActionResult DeleteTeacher(int teacherId)
        {
            var teacherOrDelete = _teacherRepository.GetTeacher(teacherId);
            if (teacherOrDelete == null) return BadRequest();
            _teacherRepository.DeleteTeacher(teacherOrDelete);
            if (!_teacherRepository.Save()) return StatusCode(500, "Please verify your data");
            return NoContent();
        }



        
    }
}