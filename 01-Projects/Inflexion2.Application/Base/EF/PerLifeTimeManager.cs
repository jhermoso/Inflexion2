

namespace Inflexion2.Application
{
    using Microsoft.Practices.Unity;

    /// <summary>
    /// implementation of LiftimeManager from Unity 2.1
    /// </summary>
    public class PerLifeTimeManager: LifetimeManager
    {
        private object value;
        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return value;
        }

        /// <summary>
        /// delete
        /// </summary>
        public override void RemoveValue()
        {
            value = null;
        }

        /// <summary>
        /// setter
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(object newValue)
        {
            value = newValue;
        }
    }
}
