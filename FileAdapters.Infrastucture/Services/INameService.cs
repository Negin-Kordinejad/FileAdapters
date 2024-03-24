using FileAdapters.Infrastucture.Models;

namespace FileAdapters.Infrastucture.Services
{
    /// <summary>
    /// Name service is responsible for sort logic.
    /// </summary>
    public interface INameService
    {
        Task<List<Person>> GetSortListBaseOnLastNameAsync(List<Person> people);
    }
}