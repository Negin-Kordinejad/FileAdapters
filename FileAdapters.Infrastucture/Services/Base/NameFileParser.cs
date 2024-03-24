using FileAdapters.Infrastucture.Models;
using System.Reflection;

namespace FileAdapters.Infrastucture.Services.Base
{
    /// <summary>
    /// An implantation name parser for Person entity.
    /// </summary>
    public class NameFileParser : IFileParser<Person>
    {
        private readonly INameFileService<Person> _nameFileService;

        public NameFileParser(INameFileService<Person> nameFileService)
        {
            _nameFileService = nameFileService;
        }

        public async Task<List<Person>> ParseAsync(string resourceName)
        {

            List<Person> records;

            var assembly = Assembly.GetEntryAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException(resourceName);
                }
                using (var reader = new StreamReader(stream))
                {
                    records = await _nameFileService.GetDataFromReaderAsync(reader);
                }
            }
            return records.ToList();
        }

        public async Task WriteAsync(string resourceName, List<Person> records)
        {
            var fileStream = File.Create(resourceName);
            using (var writer = new StreamWriter(fileStream))
            {
                await _nameFileService.ExportDataToFileUsingWriterAsync(writer, records);

            }
        }
    }
}