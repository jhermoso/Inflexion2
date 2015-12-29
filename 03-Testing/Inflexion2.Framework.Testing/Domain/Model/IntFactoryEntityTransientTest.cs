

namespace Inflexion2.Testing
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.ComponentModel.DataAnnotations;
    using Inflexion2.Domain;


    [TestClass]
    public class EntityTransientTest
    {

        public class IntEntity1 : Entity<IntEntity1, int>
        {
            [Required]
            string Name { get; set; }

            protected IntEntity1(): base()
            { }

            protected IntEntity1(int id)
                : base(id)
            { }

            protected IntEntity1(string name)               
            {
                this.Name = name;
            }

             public static IntEntity1 Create()
            {
                return new IntEntity1();
            }

             public static IntEntity1 Create(string name)
             {
                 return new IntEntity1(name);
             }

             public static IntEntity1 Create(int id) // esta factoria solo se ha construido para efectos de testing
             {
                 return new IntEntity1(id);
             }

        }

        public class IntEntity2 : Entity<IntEntity2, int>
        {
            public string Name { get; set; }

            protected IntEntity2()
                : base()
            { }

            protected IntEntity2(int id)
                : base(id)
            { }

            protected IntEntity2(string name)               
            {
                this.Name = name;
            }

            public static IntEntity2 Create()
            {
                return new IntEntity2();
            }

            public static IntEntity2 Create(string name)
            {
                return new IntEntity2(name);
            }

            public static IntEntity2 Create(int id) // esta factoria solo se ha cosntruido para efectso de testing
            {
                return new IntEntity2(id);
            }
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
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity2 e2 = IntEntity2.Create();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithOneNullEntityReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoTransientEntitiesReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity1 e2 = IntEntity1.Create();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithSameTransientEntitieReturnTrue()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        [TestMethod]
        public void IntEntityTransientNewEntitieReturnTrue()
        {
            IntEntity1 e1 = IntEntity1.Create();
            Assert.AreEqual(true, e1.IsTransient());
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoSetedIdDifferentEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create(1);
            IntEntity2 e2 = IntEntity2.Create();
            
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoSetedDifferentIdSameEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create(1);
            IntEntity1 e2 = IntEntity1.Create(2);

            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        [TestMethod]
        public void IntEntityEqualsWithTwoSetedSameIdSameEntitiesTypeReturnTrue()
        {
            IntEntity1 e1 = IntEntity1.Create(1);
            IntEntity1 e2 = IntEntity1.Create(1);

            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }


    }
}
