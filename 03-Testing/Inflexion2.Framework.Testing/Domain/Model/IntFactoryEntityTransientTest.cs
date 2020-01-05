namespace Inflexion2.Testing
{
    using Inflexion2.Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// testing entities equality
    /// </summary>
    [TestClass]
    public class EntityTransientTest
    {
        /// <summary>
        /// first class
        /// </summary>
        public class IntEntity1 : Entity<IntEntity1, int>, IEquatable<IntEntity1>
        {
            [Required]
            string Name { get; set; }

            /// <summary>
            /// parameterless constructor
            /// </summary>
            protected IntEntity1(): base()
            { }

            /// <summary>
            /// initialized id constructor
            /// </summary>
            /// <param name="id"></param>
            protected IntEntity1(int id)
                : base(id)
            { }

            /// <summary>
            /// initialized propertie constructor
            /// </summary>
            /// <param name="name"></param>
            protected IntEntity1(string name)               
            {
                this.Name = name;
            }

            /// <summary>
            /// factory
            /// </summary>
            /// <returns></returns>
             public static IntEntity1 Create()
            {
                return new IntEntity1();
            }

            /// <summary>
            /// factory
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
             public static IntEntity1 Create(string name)
             {
                 return new IntEntity1(name);
             }

            /// <summary>
            /// factory entity
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
             public static IntEntity1 Create(int id) 
             {
                 return new IntEntity1(id);
             }

        }

        /// <summary>
        /// inherited entity
        /// </summary>
        public class IntEntity2 : Entity<IntEntity2, int>, IEquatable<IntEntity2>
        {
            /// <summary>
            /// test property
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// constructor
            /// </summary>
            protected IntEntity2()
                : base()
            { }

            /// <summary>
            /// constructor
            /// </summary>
            /// <param name="id"></param>
            protected IntEntity2(int id)
                : base(id)
            { }

            /// <summary>
            /// parametrized constructor 
            /// </summary>
            /// <param name="name"></param>
            protected IntEntity2(string name)               
            {
                this.Name = name;
            }

            /// <summary>
            /// factory
            /// </summary>
            /// <returns></returns>
            public static IntEntity2 Create()
            {
                return new IntEntity2();
            }

            /// <summary>
            /// factory
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static IntEntity2 Create(string name)
            {
                return new IntEntity2(name);
            }

            /// <summary>
            /// factory
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public static IntEntity2 Create(int id) 
            {
                return new IntEntity2(id);
            }
        }

        /// <summary>
        /// 
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
        /// test equality two null entities
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoNullsEntitiesDifferentTypeReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity2 e2 = IntEntity2.Create();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality one null entity
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithOneNullEntityReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity1 e2 = null;
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoTransientEntitiesReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity1 e2 = IntEntity1.Create();
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality same entity
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithSameTransientEntitieReturnTrue()
        {
            IntEntity1 e1 = IntEntity1.Create();
            IntEntity1 e2 = e1;
            var equality = Equals(e1, e2);
            Assert.AreEqual(true, equality);
        }

        /// <summary>
        /// test equality same transient entity 
        /// </summary>
        [TestMethod]
        public void IntEntityTransientNewEntitieReturnTrue()
        {
            IntEntity1 e1 = IntEntity1.Create();
            Assert.AreEqual(true, e1.IsTransient());
        }

        /// <summary>
        /// test equality with one initialized entity
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoSetedIdDifferentEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create(1);
            IntEntity2 e2 = IntEntity2.Create();
            
            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// test equality with same class diferent objects
        /// </summary>
        [TestMethod]
        public void IntEntityEqualsWithTwoSetedDifferentIdSameEntitiesTypeReturnFalse()
        {
            IntEntity1 e1 = IntEntity1.Create(1);
            IntEntity1 e2 = IntEntity1.Create(2);

            var equality = Equals(e1, e2);
            Assert.AreEqual(false, equality);
        }

        /// <summary>
        /// same class same id test 
        /// </summary>
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
