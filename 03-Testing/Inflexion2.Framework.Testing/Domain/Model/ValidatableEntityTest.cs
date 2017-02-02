

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;

    /// <summary>
    /// validetable entities testing
    /// </summary>
    [TestClass]
    public class ValidatableEntityTransientTest
    {
        /// <summary>
        /// first validatable entity
        /// </summary>
        public class Entity1 : ValidatableEntity<Entity1, Guid>
        { }

        /// <summary>
        /// second validatable entity
        /// </summary>
        public class Entity2 : ValidatableEntity<Entity2, Guid>
        { }

        /// <summary>
        /// test equality with two nulls entities
        /// </summary>
        [TestMethod]
        public void  ValidatableEntityGuidEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            Entity1 e1 = null;
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with one null entity
        /// </summary>
        [TestMethod]
        public void ValidatableEntityGuidEqualsWithOneNullEntityReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two trasient entities
        /// </summary>
        [TestMethod]
        public void ValidatableEntityGuidEqualsWithTwoTransientEntitiesReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = new Entity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with same entity
        /// </summary>
        [TestMethod]
        public void ValidatableEntityGuidEqualsWithSameTransientEntitieReturnTrue()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }
    }
}
