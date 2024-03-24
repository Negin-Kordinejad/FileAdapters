using AutoFixture;
using FileAdapters.Infrastucture.Models;

namespace FileAdapters.Test.Fixtures
{
    internal static class PersonFixtures
    {
        internal static Person PersonWith1GivenName = new Fixture().Build<Person>()
            .With(x => x.Name, "Janet")
            .With(x => x.LastName, "Parsons")
            .Create();
        
        internal static Person PersonWith2GivenNames = new Fixture().Build<Person>()
            .With(x => x.Name, "Adonis Julius")
            .With(x => x.LastName, "Archer")
            .Create();

        internal static Person Person2With2GivenNames = new Fixture().Build<Person>()
            .With(x => x.Name, "Shelby Nathan")
            .With(x => x.LastName, "Yoder")
            .Create();
         
        internal static Person PersonWith3GivenNames = new Fixture().Build<Person>()
            .With(x => x.Name, "Hunter Uriah Mathew")
            .With(x => x.LastName, "Clarke")
            .Create();
    }
}
