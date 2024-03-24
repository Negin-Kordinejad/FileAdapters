using FileAdapters.Infrastucture.Models;
using FileAdapters.Infrastucture.Services;
using FileAdapters.Infrastucture.Services.Base;
using Microsoft.Extensions.Logging;

namespace FileAdapters.Services
{
    public class NameSorterService : INameSorterService
    {
        private readonly IFileParser<Person> _fileParser;
        private readonly INameService _nameService;
        private readonly ILogger<NameSorterService> _logger;

        public NameSorterService(ILogger<NameSorterService> logger, IFileParser<Person> fileParser, INameService nameService)
        {
            _fileParser = fileParser;
            _nameService = nameService;
            _logger = logger;
        }

        public async Task GenerateSortedFileAsync(string sourse, string destination)
        {
            _logger.LogInformation($"Start loading {Path.GetFileName(sourse)} in {Path.GetDirectoryName(sourse)}");

            var unSortedData = await _fileParser.ParseAsync(sourse);
            if (unSortedData == null)
            {
                throw new ArgumentNullException(nameof(sourse), "No data is loaded to sort.");
            }

            _logger.LogInformation($"{unSortedData.Count} records has loaded for sorting successfully");

            var sortedData = await _nameService.GetSortListBaseOnLastNameAsync(unSortedData);
            if (sortedData == null)
            {
                throw new ArgumentNullException(nameof(sourse), "GetSortListBaseOnLastName returs null.");
            }

            _logger.LogInformation($"{sortedData.Count} records has sorted successfully");

            await _fileParser.WriteAsync(destination, sortedData);

            _logger.LogInformation($"Sorted data is exported to {Path.GetFileName(destination)} in {Path.GetDirectoryName(destination)}");
        }
    }
}
