

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;

    /// <summary>
    /// test equality with value objects
    /// </summary>
    [TestClass]
    public class EqualityValueObject
    {
        /// <summary>
        /// first value object with 2 properties
        /// </summary>
        public class SimpleValueObject : ValueObject<SimpleValueObject>, ISimpleValueObject
        {
            /// <summary>
            /// first property
            /// </summary>
            public string s { get; set; }

            /// <summary>
            /// second property
            /// </summary>
            public int    i { get; set; }
        }

        /// <summary>
        /// second value object with 2 same properties than first object value
        /// </summary>
        public class OtherSimpleValueObject : ValueObject<OtherSimpleValueObject>, IOtherSimpleValueObject
        {
            /// <summary>
            /// first property same type and name 
            /// </summary>
            public string s { get; set; }

            /// <summary>
            /// second same property same type and name than first object value
            /// </summary>
            public int    i { get; set; }
        }

        /// <summary>
        /// composed object value
        /// </summary>
        public class NestedValueObject : ValueObject<NestedValueObject>, INestedValueObject
        {
            /// <summary>
            /// first property
            /// </summary>
            public string            s { get; set; }

            /// <summary>
            /// second property
            /// </summary>
            public int               i { get; set; }

            /// <summary>
            /// composed property
            /// </summary>
            public SimpleValueObject n { get; set; }
        }

        /// <summary>
        /// test equality with nulls
        /// </summary>
        [TestMethod]
        public void EqualsWithTwoNullsValueObjectsReturnTrue()
        {
            SimpleValueObject vo1 = null;
            SimpleValueObject vo2 = null;
            var equality = Equals(vo1, vo2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with one null
        /// </summary>
        [TestMethod]
        public void EqualsWithOneNullValueObjectReturnFalse()
        {
            SimpleValueObject vo1 = new SimpleValueObject();
            SimpleValueObject vo2 = null;
            var equality = Equals(vo1, vo2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with two object values
        /// </summary>
        [TestMethod]
        public void EqualsWithEmptyValueObjectsReturnTrue()
        {
            SimpleValueObject vo1 = new SimpleValueObject();
            SimpleValueObject vo2 = new SimpleValueObject();
            var equality = vo1.Equals( vo2 );
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with two same object values but same value properties
        /// </summary>
        [TestMethod]
        public void EqualsWithEqualsValueObjectsReturnTrue()
        {
            SimpleValueObject vo1 = new SimpleValueObject();
            SimpleValueObject vo2 = new SimpleValueObject();
            vo1.i = 1;
            vo1.s = "string";
            vo2.i = 1;
            vo2.s = "string";

            var equality = vo1.Equals(vo2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with one property different
        /// </summary>
        [TestMethod]
        public void EqualsWithOneDifferentPropertyReturnFalse()
        {
            SimpleValueObject vo1 = new SimpleValueObject();
            SimpleValueObject vo2 = new SimpleValueObject();
            vo1.i = 1;
            vo1.s = "string";
            vo2.i = 1;
            vo2.s = "s";

            var equality = vo1.Equals(vo2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with composed objects
        /// </summary>
        [TestMethod]
        public void EqualsWithNestedValueObjectReturnTrue()
        {

            NestedValueObject vo1 = new NestedValueObject();
            NestedValueObject vo2 = new NestedValueObject();

            vo1.i = 1;
            vo1.s = "s";
            vo1.n = new SimpleValueObject();
            vo1.n.i = 2;
            vo1.n.s = "s";

            vo2.i = 1;
            vo2.s = "s";
            vo2.n = new SimpleValueObject();
            vo2.n.i = 2;
            vo2.n.s = "s";

            var equality = vo1.Equals(vo2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality with different composed objects
        /// </summary>
        [TestMethod]
        public void EqualsWithNestedDifferentValueObjectReturnFalse()
        {

            NestedValueObject vo1 = new NestedValueObject();
            NestedValueObject vo2 = new NestedValueObject();

            vo1.i = 1;
            vo1.s = "s";
            vo1.n = new SimpleValueObject();
            vo1.n.i = 2;
            vo1.n.s = "s";

            vo2.i = 1;
            vo2.s = "s";
            vo2.n = new SimpleValueObject();
            vo2.n.i = 3;
            vo2.n.s = "s";

            var equality = vo1.Equals(vo2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with differnt object value
        /// </summary>
        [TestMethod]
        public void EqualsWithNestedDifferentRootValueObjectReturnFalse()
        {
            NestedValueObject vo1 = new NestedValueObject();
            NestedValueObject vo2 = new NestedValueObject();

            vo1.i = 1;
            vo1.s = "s";
            vo1.n = new SimpleValueObject();
            vo1.n.i = 2;
            vo1.n.s = "s";

            vo2.i = 3;
            vo2.s = "s";
            vo2.n = new SimpleValueObject();
            vo2.n.i = 2;
            vo2.n.s = "s";

            var equality = vo1.Equals(vo2);
            Assert.AreEqual(false, equality);
        }
    }
}
