namespace FileAdapters.Infrastucture.Models
{
    public class Person
    {
        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            FullName = $"{name} {lastName}";
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
    }
}
