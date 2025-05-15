using BasicDBWebApp.Controllers;
using BasicDBWebApp.Dtos;
using BasicDBWebApp.Models;
using BasicDBWebApp.Services;
using Moq;
using NUnit.Framework;

namespace BasicDBWebApp.Tests.ControllerTests
{
    [TestFixture]
    public class StudentControllerTests
    {
        private StudentController _controller;
        private Mock<ILogger<StudentController>> _logger;
        private Mock<IStudentService> _service;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IStudentService>();
            _logger = new Mock<ILogger<StudentController>>();
            _controller = new StudentController(
                _logger.Object,
                _service.Object);
        }
        [Test]
        public async Task CreateStudent_Success()
        {
            //arrange          
            var guid = Guid.NewGuid();
            _service.Setup(
                s => s.CreateStudentAsync(It.IsAny<CreateStudentRequest>()))
                .ReturnsAsync(guid);

            //act
            var result = await _controller.CreateStudentAsync("name", "email");

            //assert
            Assert.That(result, Is.EqualTo(guid));
        }

        [Test]
        public async Task GetStudentByName_Success()
        {
            //arrange
            var student = new StudentDto
            {
                StudentID = Guid.NewGuid(),
                StudentName = "Name",
                StudentEmail = "Email"
            };
            _service.Setup(s => s.GetStudentByNameAsync(It.IsAny<GetStudentByNameRequest>()))
                .ReturnsAsync(student);

            //act
            var result = await _controller.GetStudentByNameAsync("Name");

            //assert
            Assert.That(result, Is.EqualTo(student));
        }

        [Test]
        public void GetStudentByName_Fail()
        {
            //arrange
            _service.Setup(s => s.GetStudentByNameAsync(It.IsAny<GetStudentByNameRequest>()))
                .ThrowsAsync(new FileNotFoundException());

            //act + assert
            Assert.ThrowsAsync<FileNotFoundException>(() => _controller.GetStudentByNameAsync("ERROR"));
        }

        [Test]
        public async Task GetStudentByGuid_Success()
        {
            //arrange
            var student = new StudentDto
            {
                StudentID = Guid.NewGuid(),
                StudentName = "Name",
                StudentEmail = "Email"
            };
            _service.Setup(s => s.GetStudentByGuidAsync(It.IsAny<GetStudentByGuidRequest>()))
                .ReturnsAsync(student);

            //act
            var result = await _controller.GetStudentByGuidAsync(Guid.NewGuid());

            //assert
            Assert.That(result, Is.EqualTo(student));
        }

        [Test]
        public void GetStudentByGuid_Fail()
        {
            //arrange
            _service.Setup(s => s.GetStudentByGuidAsync(It.IsAny<GetStudentByGuidRequest>()))
                .ThrowsAsync(new FileNotFoundException());

            //act + assert
            Assert.ThrowsAsync<FileNotFoundException>(() => _controller.GetStudentByGuidAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task GetStudents_Success()
        {
            //arrange
            var students = new List<StudentDto> {
                new() {
                    StudentID = Guid.NewGuid(),
                    StudentName = "Name",
                    StudentEmail = "Email"
                }
            };

            _service.Setup(s => s.GetStudentsAsync())
                .ReturnsAsync(students);

            //act
            var result = await _controller.GetStudentsAsync();

            //assert
            Assert.That(result, Is.EqualTo(students));
        }

        [Test]
        public async Task SetStudentGrade_Success()
        {
            //arrange
            var student = new StudentDto
            {
                GradeID = Guid.NewGuid(),
                StudentName = "Name",
                StudentEmail = "Email",
                StudentID = Guid.NewGuid()
            };
            _service.Setup(s => s.SetStudentGradeAsync(It.IsAny<SetStudentGradeRequest>()))
                .ReturnsAsync(student);

            //act
            var result = await _controller.SetStudentGradeAsync(Guid.NewGuid(), Guid.NewGuid());

            //assert
            Assert.That(result, Is.EqualTo(student));
        }

        [Test]
        public void SetStudentGrade_Fail()
        {
            //arrange
            _service.Setup(s => s.SetStudentGradeAsync(It.IsAny<SetStudentGradeRequest>()))
                .ThrowsAsync(new FileNotFoundException());

            //act + assert
            Assert.ThrowsAsync<FileNotFoundException>(() => _controller.SetStudentGradeAsync(Guid.NewGuid(), Guid.NewGuid()));
        }

        [Test]
        public async Task SetStudentCourse_Success()
        {
            //arrange
            var studentCourse = new StudentCourseDto
            {
                CourseID = Guid.NewGuid(),
                StudentName = "Name",
                CourseName = "Course",
                StudentID = Guid.NewGuid()
            };
            _service.Setup(s => s.SetStudentCourseAsync(It.IsAny<SetStudentCourseRequest>()))
                .ReturnsAsync(studentCourse);

            //act
            var result = await _controller.SetStudentCourseAsync(Guid.NewGuid(), Guid.NewGuid());

            //assert
            Assert.That(result, Is.EqualTo(studentCourse));
        }

        [Test]
        public void SetStudentCourse_Fail()
        {
            //arrange
            _service.Setup(s => s.SetStudentCourseAsync(It.IsAny<SetStudentCourseRequest>()))
                .ThrowsAsync(new FileNotFoundException());

            //act + assert
            Assert.ThrowsAsync<FileNotFoundException>(() => _controller.SetStudentCourseAsync(Guid.NewGuid(), Guid.NewGuid()));
        }
    }
}
