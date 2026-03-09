using StudentManager.Infrastructure;

namespace StudentManager.Application.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddStudent_ValidStudent_AddsStudent()
        {
            // Arrange
            StudentRepository repository = new StudentRepository();
            StudentService service = new StudentService(repository);

            // Act
            service.AddStudent("Alice", "Johnson");

            // Assert
            Assert.Single(service.GetAllStudents());
            Assert.Equal("Alice", service.GetAllStudents()[0].FirstName);
            Assert.Equal("Johnson", service.GetAllStudents()[0].LastName);
        }
    }
}