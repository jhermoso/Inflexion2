

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inflexion2.Domain;

    [TestClass]
    public class EqualityValueObject
    {
        public class SimpleValueObject : ValueObject<SimpleValueObject>
        {
            public string s { get; set; }
            public int    i { get; set; }
        }

        public class OtherSimpleValueObject : ValueObject<OtherSimpleValueObject>
        {
            public string s { get; set; }
            public int    i { get; set; }
        }

        public class NestedValueObject : ValueObject<NestedValueObject>
        {
            public string            s { get; set; }
            public int               i { get; set; }
            public SimpleValueObject n { get; set; }
        }

        [TestMethod]
        public void EqualsWithTwoNullsValueObjectsReturnTrue()
        {
            SimpleValueObject vo1 = null;
            SimpleValueObject vo2 = null;
            var equality = Equals(vo1, vo2);
            Assert.AreEqual(true, equality);
        }


        [TestMethod]
        public void EqualsWithOneNullValueObjectReturnFalse()
        {
            SimpleValueObject vo1 = new SimpleValueObject();
            SimpleValueObject vo2 = null;
            var equality = Equals(vo1, vo2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void EqualsWithEmptyValueObjectsReturnTrue()
        {
            SimpleValueObject vo1 = new SimpleValueObject();
            SimpleValueObject vo2 = new SimpleValueObject();
            var equality = vo1.Equals( vo2 );
            Assert.AreEqual(true, equality);
        }

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
