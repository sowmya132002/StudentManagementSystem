using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            // Business Logic

            var students = await _studentRepository.GetAllAsync();

            if (students.Any(s => s.Email.ToLower() == student.Email.ToLower()))
            {
                throw new Exception("Email already exists.");
            }

            student.CreatedDate = DateTime.UtcNow;

            return await _studentRepository.AddAsync(student);
        }

        public async Task<Student?> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }
    }
}
