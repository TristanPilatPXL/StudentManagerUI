using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StudentManager.Domain;

namespace StudentManager.Infrastructure
{
    public class StudentCsvRepository
    {

        private readonly List<Student> _students = new();
        public void Add(Student student) => _students.Add(student);
        public List<Student> All() => _students;



        public void checkCreate()
        {
            string folder = @"C:\Users\Trist\Desktop\Graduaat\C-Advanced\StudentManagerUI\StudentManagerUI\StudentManager.Infrastructure\Data";//specifieke route meegeven
            string filePath = Path.Combine(folder, "data.txt");

            // Maak de Data-map aan als die nog niet bestaat
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

           

            File.Create(filePath).Close();
        }

        public List<Student> alles()
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader("data.csv"))
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

            return students;  //return type


        }

        public void add(Student student)
        {
            string line = $"{student.FirstName};{student.LastName}";

            // StreamWriter met append: true → overschrijft NIET
            using (StreamWriter writer = new StreamWriter("data.csv", append: true))
            {
                writer.WriteLine(line);
            }
        }






    }
}


