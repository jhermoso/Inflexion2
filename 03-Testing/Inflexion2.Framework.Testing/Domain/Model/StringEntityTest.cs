namespace Inflexion2.Testing
{
    using Inflexion2.Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// creates entities with string id identifier
    /// </summary>
    [TestClass]
    public class StringEntityTransientTest
    {
        /// <summary>
        /// first entity with string id
        /// </summary>
        public class Entity1 : Entity<Entity1, string>, IEquatable<Entity1>
        { }

        /// <summary>
        /// second entity with string id entity
        /// </summary>
        public class Entity2 : Entity<Entity2, string>, IEquatable<Entity2>
        { }

        /// <summary>
        /// null equality testing
        /// </summary>
        [TestMethod]
        public void StringEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            Entity1 e1 = null;
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// same content different entities testing
        /// </summary>
        [TestMethod]
        public void StringEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity2 e2 = new Entity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// compare one entity with a null entity
        /// </summary>
        [TestMethod]
        public void StringEqualsWithOneNullEntityReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// compare 2 transient entities (id=null)
        /// </summary>
        [TestMethod]
        public void StringEqualsWithTwoTransientEntitiesReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = new Entity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// equality
        /// </summary>
        [TestMethod]
        public void StringEqualsWithSameTransientEntitieReturnTrue()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

    }
}
