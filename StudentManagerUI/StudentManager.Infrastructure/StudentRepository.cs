using StudentManager.Domain;


namespace StudentManager.Infrastructure
{
    //De repository beheert de opslag van studenten. In dit voorbeeld is dat een lijst in het geheugen. Deze laag gebruikt het domein, maar kent verder geen businesslogica.
    public class StudentRepository
    {
        private readonly List<Student> _students = new();

        public void Add(Student student) => _students.Add(student);

        public List<Student> All() => _students;
    }
}
