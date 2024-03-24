using FileAdapters.Infrastucture.Models;
using FileAdapters.Infrastucture.Services.Base;
using Moq;

namespace FileAdapters.Test.Fakes
{
    internal static class NameFileServiceFake
    {
        internal static Mock<INameFileService<Person>> ConfigureGetDataFromReaderAsyncToReturn(
            this Mock<INameFileService<Person>> instance, List<Person> response)
        {
            instance.Setup(x => x.GetDataFromReaderAsync(It.IsAny<StreamReader>()))
                .ReturnsAsync(() => response);

            return instance;
        }
    }
}
