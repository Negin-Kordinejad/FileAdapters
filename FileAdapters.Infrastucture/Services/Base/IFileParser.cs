namespace FileAdapters.Infrastucture.Services.Base
{
    /// <summary>
    /// A generic file parser for file I/O operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFileParser<T>
    {
        Task<List<T>> ParseAsync(string resourceName);
        Task WriteAsync(string resourceName, List<T> records);
    }
}
