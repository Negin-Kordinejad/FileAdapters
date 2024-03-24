namespace FileAdapters.Services
{
    /// <summary>
    ///  A front end service just for readabilty;
    /// </summary>
    public interface INameSorterService
    {
        /// <summary>
        /// Take a path of source file, read data to a list person model sort it base on last Name, Then save it to destination
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        Task GenerateSortedFileAsync(string sourse, string destination);
    }
}
