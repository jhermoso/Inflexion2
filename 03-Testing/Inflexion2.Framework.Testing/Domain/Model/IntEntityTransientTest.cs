

namespace Inflexion2.Testing
{
    using Inflexion2.Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// test equality entities based on int id 
    /// </summary>
    [TestClass]
    public class IntEntityTransientTest
    {
        /// <summary>
        /// first entity
        /// </summary>
        public class IntEntity1 : Entity<IntEntity1, int>, IEquatable<IntEntity1>
        {
            /// <summary>
            /// parameter less constructor
            /// </summary>
            public IntEntity1(): base()
            { }

            /// <summary>
            /// parametrized constructor
            /// </summary>
            /// <param name="id"></param>
            public IntEntity1(int id)
                : base(id)
            { }
        }

        /// <summary>
        /// second entity
        /// </summary>
        public class IntEntity2 : Entity<IntEntity2, int>, IEquatable<IntEntity2>
        {
            /// <summary>
            /// parameter less constructor
            /// </summary>
            public IntEntity2()
                : base()
            { }

            /// <summary>
            /// id parametrized constructor
            /// </summary>
            /// <param name="id"></param>
            public IntEntity2(int id)
                : base(id)
            { }
        }

        /// <summary>
        /// test equality with two nulls entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoNullsEntitiesSameTypeReturnTrue()
        {
            IntEntity1 e1 = null;
            IntEntity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
            
        }

        /// <summary>
        /// test equality with two initialized entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity2 e2 = new IntEntity2();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with one null entity
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithOneNullEntityReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two transient entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoTransientEntitiesReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity1 e2 = new IntEntity1();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with same entity
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithSameTransientEntitieReturnTrue()
        {
            IntEntity1 e1 = new IntEntity1();
            IntEntity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with one transient entity
        /// </summary>
        [TestMethod]
        public void IntEntityTransientNewEntitieReturnTrue()
        {
            IntEntity1 e1 = new IntEntity1();
            Assert.AreEqual(true, e1.IsTransient());
        }

        /// <summary>
        /// test equality with two entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoSetedIdDifferentEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity2 e2 = new IntEntity2(2);
            
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two different entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoSetedDifferentIdSameEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity1 e2 = new IntEntity1(2);

            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with same entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoSetedSameIdSameEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = new IntEntity1(1);
            IntEntity1 e2 = new IntEntity1(1);

            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with same entities
        /// </summary>
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
