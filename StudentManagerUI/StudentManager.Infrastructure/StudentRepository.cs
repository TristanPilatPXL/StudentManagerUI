using StudentManager.Domain;


namespace StudentManager.Infrastructure
{
    public class StudentRepository
    {
        private readonly List<Student> _students = new();

        public void Add(Student student) => _students.Add(student);

        public List<Student> All() => _students;
    }
}
