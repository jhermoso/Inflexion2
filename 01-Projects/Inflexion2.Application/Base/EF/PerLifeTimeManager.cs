

namespace Inflexion2.Application
{
    using Microsoft.Practices.Unity;


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
