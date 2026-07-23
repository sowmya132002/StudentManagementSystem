using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using StudentManagementSystem.DTOs;

using Microsoft.AspNetCore.Authorization;


namespace StudentManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return Ok(students);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    Message = "Student not found"
                });
            }

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course
            };

            var createdStudent = await _studentService.AddStudentAsync(student);

            return CreatedAtAction(nameof(GetStudentById),
                new { id = createdStudent.Id },
                createdStudent);
        }

        // PUT: api/student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest(new
                {
                    Message = "Student Id mismatch"
                });
            }

            var updatedStudent = await _studentService.UpdateStudentAsync(student);

            if (updatedStudent == null)
            {
                return NotFound(new
                {
                    Message = "Student not found"
                });
            }

            return Ok(updatedStudent);
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    Message = "Student not found"
                });
            }

            return Ok(new
            {
                Message = "Student deleted successfully"
            });
        }
    }
}