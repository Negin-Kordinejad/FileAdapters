using FileAdapters.Infrastucture.Models;

namespace FileAdapters.Infrastucture.Services.Base
{
    public interface INameFileService<T>
    {
        Task<List<T>> GetDataFromReaderAsync(StreamReader reader);
        Task ExportDataToFileUsingWriterAsync(StreamWriter writer, IList<T> records);
    }

}