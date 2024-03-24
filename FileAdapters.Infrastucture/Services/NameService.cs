using FileAdapters.Infrastucture.Models;

namespace FileAdapters.Infrastucture.Services
{
    public class NameService : INameService
    {
        public async Task<List<Person>> GetSortListBaseOnLastNameAsync(List<Person> people)
        {
            if (people == null)
            {
                return default;
            }

            if (people.Count == 1)
            {
                return people;
            }

            people.Sort((s1, s2) => s1.LastName.CompareTo(s2.LastName));

            return people;

        }
    }
}