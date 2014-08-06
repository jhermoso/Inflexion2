

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;


    [TestClass]
    public class IntEntityTransientTest
    {

        public class IntEntity1 : Entity<IntEntity1, int>
        {

            public IntEntity1(): base()
            { }

            public IntEntity1(int id)
                : base(id)
            { }
        }

        public class IntEntity2 : Entity<IntEntity1, int>
        {

            public IntEntity2()
                : base()
            { }

            public IntEntity2(int id)
                : base(id)
            { }
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            IntEntity1 e1 = null;
            IntEntity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
            
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity2 e2 = new IntEntity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithOneNullEntityReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoTransientEntitiesReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity1 e2 = new IntEntity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithSameTransientEntitieReturnTrue()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        [TestMethod]
        public void IntEntityTransientNewEntitieReturnTrue()
        {
            IntEntity1 e1 = new IntEntity1();
            Assert.AreEqual(true, e1.IsTransient());
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoSetedIdDifferentEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity2 e2 = new IntEntity2(2);
            
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoSetedDifferentIdSameEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity1 e2 = new IntEntity1(2);

            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoSetedSameIdSameEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity1 e2 = new IntEntity1(1);

            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithSameEntityReturnTrue()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity1 e2 = new IntEntity1(1);

            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }
    }
}
