using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFFromClassLibrary
{
    class HelloWorldService : IHellowWorldService
    {
        public string GetMessage(string name)
        {
            return "Hello Wordl from" + name;
        }
    }
}
