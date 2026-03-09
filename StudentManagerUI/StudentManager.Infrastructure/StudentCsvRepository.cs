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

            if (File.Exists("data.txt"))
                throw new InvalidOperationException("Bestand bestaat al.");

            File.Create("data.txt");

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

        public void toeveogen()
        {
            string firstname;
            Student student = new Student(firstname, "Janssens");

            string line = $"{student.FirstName};{student.LastName}";
        }






    }
}


