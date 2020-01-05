
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    using Business;
    public class Repository
    {
        public List<Class1> Db { get; set; }

        public Repository(int totalClass1 = 2, int totalClass2 = 2, int totalClass3 = 2)
        {
            Db = new List<Class1>();

            for (int i = 1; i <= totalClass1; i++)
            {
                var c4 = new Class4() { c4Name = "c4 p1 " + i.ToString(), Id = i, c4Property = "c4 p2 " + i.ToString() };
                var c1 = new Class1() { Name = "Class1 Name " + i.ToString(), Id = i, Property = "Class1 Property " + i.ToString(), PropertyClass = c4, Class2Collection = new List<Class2>() };
             
                for (int j = 1; j <= totalClass2; j++)
                {
                    var c2 = new Class2() { Name = "Class2 Name " + j.ToString(), Id = j, IdParent = i, Property = "Class2 Property " + i.ToString()+ " " + j.ToString(), Class3Collection = new List<Class3>() };

                    for (int k = 1; k <= totalClass3; k++)
                    {
                        var c3 = new Class3() { Name = "Class3 Name " + k.ToString(), Id = k, IdParent = j, Property = "Class3 Property " + i.ToString() + " " + j.ToString() + " " + k.ToString() };
                        c2.Class3Collection.Add(c3);
                    }

                    c1.Class2Collection.Add(c2);
                }

                Db.Add(c1);
            }
        }
    }
}
