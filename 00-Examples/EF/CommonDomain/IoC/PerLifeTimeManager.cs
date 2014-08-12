using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Inflexion2;

namespace EFexample
{
    public class PerLifeTimeManager: LifetimeManager
    {
        private object value;

        public override object GetValue()
        {
            return value;
        }

        public override void RemoveValue()
        {
            value = null;
        }

        public override void SetValue(object newValue)
        {
            value = newValue;
        }
    }
}
