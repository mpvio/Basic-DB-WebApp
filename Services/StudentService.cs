using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using Azure.Core;
using BasicDBWebApp.Dtos;
using BasicDBWebApp.Entities;
using BasicDBWebApp.Models;
using BasicDBWebApp.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace BasicDBWebApp.Services
{
    public class StudentService : IStudentService
    {
        private ApplicationDbContext _context;
        private ILogger<StudentService> _logger;

        public StudentService(
            ApplicationDbContext context,
            ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<StudentDto> GetStudentByNameAsync(
            GetStudentByNameRequest request)
        {
            var student = await _context.Students
                .Where(s => s.StudentName == request.StudentName)
                .Include(s => s.Grade)
                .FirstOrDefaultAsync();

            if (student is not null)
            {
                return new StudentDto
                {
                    StudentID = student.StudentID,
                    StudentEmail = student.StudentEmail,
                    StudentName = student.StudentName,
                    GradeID = student.GradeID,
                    GradeName = student.Grade?.GradeName
                };
            } else
            {
                throw new FileNotFoundException();
            }
            
        }

        public async Task<StudentDto> GetStudentByGuidAsync(
            GetStudentByGuidRequest request)
        {
            var student = await _context.Students
                .Where(s => s.StudentID.Equals(request.Id))
                .Include(s => s.Grade)
                .FirstOrDefaultAsync();

            if (student is not null)
            {
                return new StudentDto
                {
                    StudentID = student.StudentID,
                    StudentEmail = student.StudentEmail,
                    StudentName = student.StudentName,
                    GradeID = student.GradeID,
                    GradeName = student.Grade?.GradeName
                };
            }
            else
            {
                throw new FileNotFoundException();
            }

        }

        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            var students = await _context.Students
                .Include(s => s.Grade)
                .ToListAsync();

            var studentsDto = new List<StudentDto>();

            foreach (var student in students)
            {
                studentsDto.Add(new StudentDto
                {
                    StudentID = student.StudentID,
                    StudentEmail = student.StudentEmail,
                    StudentName = student.StudentName,
                    GradeID = student.GradeID,
                    GradeName = student.Grade?.GradeName
                });
            }

            return studentsDto;
        }

        public async Task<Guid> CreateStudentAsync(
            CreateStudentRequest request)
        {
            var student = new Student
            {
                StudentName = request.Name,
                StudentEmail = request.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student.StudentID;
        }

        public async Task<StudentDto> SetStudentGradeAsync(
            SetStudentGradeRequest request)
        {
            var grade = await _context.Grades
                .Where(g => g.GradeID.Equals(request.GradeID))
                .FirstOrDefaultAsync();

            var student = await _context.Students
                .Where(s => s.StudentID.Equals(request.StudentID))
                .Include(s => s.Grade)
                .FirstOrDefaultAsync();

            if (grade is null)
            {
                throw new FileNotFoundException(message: "Grade Not Found.");
            }

            if (student is null)
            {
                throw new FileNotFoundException(message: "Student Not Found.");
            }

            student.Grade = grade;
            student.GradeID = grade.GradeID;
            if (grade.Students is null)
            {
                grade.Students = [student];
            }
            else
            {
                grade.Students.Add(student);
            }

            await _context.SaveChangesAsync();

            return new StudentDto
            {
                StudentID = student.StudentID,
                StudentEmail = student.StudentEmail,
                StudentName = student.StudentName,
                GradeID = student.GradeID,
                GradeName = student.Grade.GradeName
            };

        }

        public async Task<StudentCourseDto> SetStudentCourseAsync(
            SetStudentCourseRequest req)
        {
            var course = await _context.Courses
                .Where(g => g.CourseID.Equals(req.CourseID))
                .FirstOrDefaultAsync();

            var student = await _context.Students
                .Where(s => s.StudentID.Equals(req.StudentID))
                .FirstOrDefaultAsync();

            if (course is null)
            {
                throw new FileNotFoundException(message: "Course Not Found.");
            }

            if (student is null)
            {
                throw new FileNotFoundException(message: "Student Not Found.");
            }

            var studentCourse = new StudentCourse
            {
                CourseID = course.CourseID,
                Course = course,
                Student = student,
                StudentID = student.StudentID
            };

            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();

            return new StudentCourseDto
            {
                CourseID = studentCourse.CourseID,
                StudentID = studentCourse.StudentID,
                CourseName = studentCourse.Course.CourseName,
                StudentName = studentCourse.Student.StudentName
            };
        }
    }
}
