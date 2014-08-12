using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace ConsoleEFApplicationtest
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntityBServices service = new EntityBServices();
           var s =  ConfigurationManager.ConnectionStrings["Sql.Connection"].ConnectionString;
           Console.WriteLine("la cadenas es '{0}'", s);
           Console.Read();

        }
    }
}
