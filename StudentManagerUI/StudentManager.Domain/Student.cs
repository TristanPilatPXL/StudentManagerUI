namespace StudentManager.Domain
{
    //Het domein beschrijft wat een student is, en bevat regels die altijd moeten gelden. Hier voeren we validatie uit op voornaam en achternaam.
    public class Student
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Voornaam is verplicht.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Achternaam is verplicht.");

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
