

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;


    /// <summary>
    /// test equality with entities based on id with guid
    /// </summary>
    [TestClass]
    public class GuidEntityTransientTest
    {
        /// <summary>
        /// first entity
        /// </summary>
        public class Entity1 : Entity<Entity1, Guid>
        { }

        /// <summary>
        /// second entity
        /// </summary>
        public class Entity2 : Entity<Entity2, Guid>
        { }

        /// <summary>
        /// test equality with two null entities
        /// </summary>
        [TestMethod]
        public void GuidEntityEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            Entity1 e1 = null;
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with two different entities
        /// </summary>
        [TestMethod]
        public void GuidEntityEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity2 e2 = new Entity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with one null entity
        /// </summary>
        [TestMethod]
        public void GuidEntityEqualsWithOneNullEntityReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two transient entities
        /// </summary>
        [TestMethod]
        public void GuidEntityEqualsWithTwoTransientEntitiesReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = new Entity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two same guid entities
        /// </summary>
        [TestMethod]
        public void GuidEntityEqualsWithSameTransientEntitieReturnTrue()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test transient
        /// </summary>
        [TestMethod]
        public void GuidEntityTransientNewEntitieReturnTrue()
        {
            Entity1 e1 = new Entity1();
            Assert.AreEqual(true, e1.IsTransient());
        }
    }
}
