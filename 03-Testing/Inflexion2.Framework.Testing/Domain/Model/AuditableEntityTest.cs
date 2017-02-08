

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;

    /// <summary>
    /// Equality testing with entities
    /// </summary>
    [TestClass]
    public class AuditableEntityTransientTest
    {
        /// <summary>
        /// first entity to compare
        /// </summary>
        public class Entity1 : AuditableEntity<Entity1, Guid>
        { }

        /// <summary>
        /// second entity to compare
        /// </summary>
        public class Entity2 : AuditableEntity<Entity2, Guid>
        { }

        /// <summary>
        /// test equality with two null entities
        /// </summary>
        [TestMethod]
        public void EqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            Entity1 e1 = null;
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with two entities
        /// </summary>
        [TestMethod]
        public void EqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity2 e2 = new Entity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with one intialized entyty and a null entity same class
        /// </summary>
        [TestMethod]
        public void EqualsWithOneNullEntityReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two differnt entities
        /// </summary>
        [TestMethod]
        public void EqualsWithTwoTransientEntitiesReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = new Entity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with same entity reference
        /// </summary>
        [TestMethod]
        public void EqualsWithSameTransientEntitieReturnTrue()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// transient test
        /// </summary>
        [TestMethod]
        public void IntEntityTransientNewEntitieReturnTrue()
        {
            Entity1 e1 = new Entity1();
            Assert.AreEqual(true, e1.IsTransient());
        }

    }
}
