using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Inflexion2.Domain;
using Inflexion2;
using Inflexion2.Infrastructure;


using System.Configuration;

namespace EFexample
{
    class Program
    {

        static void Main(string[] args)
        {

            EfSqlTest s = new EfSqlTest();
            s.starter();

        }

    }
}
