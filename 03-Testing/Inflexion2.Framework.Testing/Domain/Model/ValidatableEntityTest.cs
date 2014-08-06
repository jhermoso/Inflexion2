

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;


    [TestClass]
    public class ValidatableEntityTransientTest
    {

        public class Entity1 : ValidatableEntity<Entity1, Guid>
        { }

        public class Entity2 : ValidatableEntity<Entity2, Guid>
        { }

        [TestMethod]
        public void  ValidatableEntityGuidEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            Entity1 e1 = null;
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        [TestMethod]
        public void ValidatableEntityGuidEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity2 e2 = new Entity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void ValidatableEntityGuidEqualsWithOneNullEntityReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void ValidatableEntityGuidEqualsWithTwoTransientEntitiesReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = new Entity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

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
