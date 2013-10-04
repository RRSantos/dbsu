using dbsu.core.Persistence;
using FluentAssertions;
using NUnit.Framework;

namespace dbsu.core.tests
{
    
    [TestFixture]
    public class PersistenceFactoryTests
    {
        [Test]
        public void ShouldReturnMsSqlPersistenceIfNoPrefixWasInformed()
        {
            var connectionStirngName = "MyTestDatabase";
            var persistence = PersistenceFactory.GetPersistence(connectionStirngName);
            persistence.GetType().Should().Be(typeof(MsSqlPersistence));
            persistence.Dispose();
        }

        [Test]
        public void ShouldReturnMsSqlPersistenceIfPrefixEqualsMsSql_CaseInsensitive()
        {
            var connectionStirngName = "mssql-MyTestDatabaseA";
            var persistence = PersistenceFactory.GetPersistence(connectionStirngName);
            persistence.GetType().Should().Be(typeof(MsSqlPersistence));
            persistence.Dispose();

            connectionStirngName = "MsSql-MyTestDatabaseB";
            persistence = PersistenceFactory.GetPersistence(connectionStirngName);
            persistence.GetType().Should().Be(typeof(MsSqlPersistence));
            persistence.Dispose();

            connectionStirngName = "MSSQL-MyTestDatabaseC";
            persistence = PersistenceFactory.GetPersistence(connectionStirngName);
            persistence.GetType().Should().Be(typeof(MsSqlPersistence));
            persistence.Dispose();


            connectionStirngName = "mSsQL-MyTestDatabaseD";
            persistence = PersistenceFactory.GetPersistence(connectionStirngName);
            persistence.GetType().Should().Be(typeof(MsSqlPersistence));
            persistence.Dispose();
        }
    }
}
