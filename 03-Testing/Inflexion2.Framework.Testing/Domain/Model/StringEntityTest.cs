

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;


    [TestClass]
    public class StringEntityTransientTest
    {

        public class Entity1 : Entity<Entity1, string>
        { }

        public class Entity2 : Entity<Entity2, string>
        { }




        [TestMethod]
        public void StringEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            Entity1 e1 = null;
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        [TestMethod]
        public void StringEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity2 e2 = new Entity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void StringEqualsWithOneNullEntityReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void StringEqualsWithTwoTransientEntitiesReturnFalse()
        {
            Entity1 e1 = new Entity1();
            Entity1 e2 = new Entity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

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
