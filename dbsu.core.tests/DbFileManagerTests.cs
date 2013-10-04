using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace dbsu.core.tests
{
    [TestFixture]
    public class DbFileManagerTests
    {
        private string dbPath = @".\DB";
        
        [Test]
        public void ShouldReturnMoreThanZeroConnections()
        {   
            var dbFileManager = new DbFileManager(dbPath);
            var scriptContainer = dbFileManager.GetScripts();

            scriptContainer.Connections.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void EachConnectionShouldReturnMoreThanZeroObjectTypes()
        {
            var dbFileManager = new DbFileManager(dbPath);
            var scriptContainer = dbFileManager.GetScripts();
            foreach (var connection in scriptContainer.Connections)
            {
                connection.ObjectTypes.Count().Should().BeGreaterThan(0);
            }
            
        }

        [Test]
        public void EachObjectTypeShouldReturnMoreThanZeroScripts()
        {
            var dbFileManager = new DbFileManager(dbPath);
            var scriptContainer = dbFileManager.GetScripts();
            foreach (var connection in scriptContainer.Connections)
            {
                foreach (var objectType in connection.ObjectTypes)
                {
                    objectType.Scripts.Count().Should().BeGreaterThan(0);
                }
            }

        }


        [Test]
        public void ShouldReturnConnectionsInAnOrderedWay()
        {
            var dbFileManager = new DbFileManager(dbPath);
            var scriptContainer = dbFileManager.GetScripts();
            int order = int.MinValue;
            foreach (var connection in scriptContainer.Connections)
            {
                order.Should().BeLessOrEqualTo(connection.Order);
                order = connection.Order;
            }

        }

        [Test]
        public void ShouldReturnObjectTypesInAnOrderedWay()
        {
            var dbFileManager = new DbFileManager(dbPath);
            var scriptContainer = dbFileManager.GetScripts();
            
            foreach (var connection in scriptContainer.Connections)
            {
                int order = int.MinValue;
                foreach (var objectType in connection.ObjectTypes)
                {
                    order.Should().BeLessOrEqualTo(objectType.Order);
                    order = objectType.Order;
                }
                
            }

        }

        [Test]
        public void ShouldReturnScriptsInAnOrderedWay()
        {
            var dbFileManager = new DbFileManager(dbPath);
            var scriptContainer = dbFileManager.GetScripts();

            foreach (var connection in scriptContainer.Connections)
            {
                
                foreach (var objectType in connection.ObjectTypes)
                {
                    int order = int.MinValue;
                    foreach (var script in objectType.Scripts)
                    {
                        order.Should().BeLessOrEqualTo(script.Order);
                        order = script.Order;
                    }
                }

            }

        }


        
    }
}
