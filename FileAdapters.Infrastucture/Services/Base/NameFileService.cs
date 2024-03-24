using FileAdapters.Infrastucture.Models;

namespace FileAdapters.Infrastucture.Services.Base
{
    /// <summary>
    ///An implantation name file service for logic specification base on Person entity.
    /// </summary>
    public class NameFileService : INameFileService<Person>
    {
        const string Delimiter = " ";
        public async Task<List<Person>> GetDataFromReaderAsync(StreamReader reader)
        {
            var records = new List<Person>();

            while (!reader.EndOfStream)
            {
                var readLine = await reader.ReadLineAsync();
                if (readLine == null) continue;

                var space = readLine.LastIndexOf(Delimiter);
                if (space < 1)
                {
                    records.Add(new Person(readLine, string.Empty));
                    continue;
                }

                records.Add(new Person(readLine.Substring(0, space), readLine.Substring(space + 1)));
            }
            return records;
        }

        public async Task ExportDataToFileUsingWriterAsync(StreamWriter writer, IList<Person> records)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            var people = (List<Person>)records;

            foreach (var item in people)
            {
                await writer.WriteLineAsync($"{item.FullName}");
            }
        }
    }
}