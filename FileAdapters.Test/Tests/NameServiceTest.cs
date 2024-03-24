using FileAdapters.Infrastucture.Models;
using FileAdapters.Test;
using FileAdapters.Test.Fixtures;

namespace FileAdapters.Service.Test.Tests
{
    [TestClass]
    public class NameServiceTest : FunctionalTestBase
    {
        [TestMethod]
        public async Task GetSortListBaseOnLastNameAsync_When_InputList_IS_NULL_ReturnsNull()
        {
            //Act
            var result = await NameService.GetSortListBaseOnLastNameAsync(null);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetSortListBaseOnLastNameAsync_When_Input_HAS_ONE_Line_ReturnsSame()
        {
            var people =new List<Person> { PersonFixtures.PersonWith1GivenName };
            //Act
            var result = await NameService.GetSortListBaseOnLastNameAsync(people);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count==1);
            Assert.IsTrue(people.First().Name == result.First().Name);
        }

        [TestMethod]
        public async Task GetSortListBaseOnLastNameAsync_When_Input_HAS_Person_With_TWO_GivenNames_ReturnsSorted()
        {
            var people = new List<Person> { PersonFixtures.PersonWith1GivenName, PersonFixtures.PersonWith2GivenNames };
            //Act
            var result = await NameService.GetSortListBaseOnLastNameAsync(people);

            //Assert

            Assert.IsTrue(result.Count == people.Count);
        }

        [TestMethod]
        public async Task GetSortListBaseOnLastNameAsync_When_Input_HAS_Person_With_Three_GivenNames_ReturnsSorted()
        {
            var people = new List<Person> { PersonFixtures.PersonWith1GivenName, PersonFixtures.PersonWith3GivenNames };

            //Act
            var result = await NameService.GetSortListBaseOnLastNameAsync(people);

            //Assert

            Assert.IsTrue(result.Count == people.Count);
        }
    }
}
