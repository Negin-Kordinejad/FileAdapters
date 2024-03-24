using FileAdapters.Infrastucture.Models;
using FileAdapters.Infrastucture.Services;
using FileAdapters.Infrastucture.Services.Base;
using Moq;

namespace FileAdapters.Test
{
    public class FunctionalTestBase
    {
        protected readonly Mock<INameFileService<Person>> NameFileService = new Mock<INameFileService<Person>>();
        protected NameService NameService;
        protected NameFileParser NameFileParser;

        [TestInitialize]
        public void Initialize()
        {
            NameService = new NameService();
            NameFileParser = new NameFileParser(NameFileService.Object);
        }
    }
}