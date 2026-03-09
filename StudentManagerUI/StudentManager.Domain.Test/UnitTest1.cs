namespace StudentManager.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ToString_ValidStudent_ReturnsFullName()
        {
            // Arrange
            Student student = new Student("Alice", "Johnson");

            // Act
            string result = student.ToString();

            // Assert
            Assert.Equal("Alice Johnson", result);
        }
    }
}