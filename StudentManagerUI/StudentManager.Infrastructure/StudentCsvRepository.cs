using System.IO;
using StudentManager.Domain;

namespace StudentManager.Infrastructure
{
    public class StudentCsvRepository
    {
        private readonly string _dataFolder;
        private readonly string _filePath;

        public StudentCsvRepository()
        {
            //pad voor alles
            _dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            _filePath = Path.Combine(_dataFolder, "data.csv");

            //Map aanmaken als die niet bestaat
            if (!Directory.Exists(_dataFolder))
                Directory.CreateDirectory(_dataFolder);

            //bestand aanmaken ALLEEN als het nog NIET bestaat
            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
        }

        //Leest ALLES uit het bestand (StreamReader)
        public List<Student> All()
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] values = line.Split(';');
                    Student student = new Student(values[0], values[1]);
                    students.Add(student);
                }
            }

            return students;
        }

        //Voegt toe aan het BESTAND (StreamWriter met append)
        public void Add(Student student)
        {
            string line = $"{student.FirstName};{student.LastName}";

            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {
                writer.WriteLine(line);
            }
        }
    }
}
