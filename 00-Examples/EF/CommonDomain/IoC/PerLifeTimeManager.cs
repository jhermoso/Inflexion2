using Microsoft.Practices.Unity;

namespace EFexample
{
    /// <summary>
    /// LifetimeManager implementation
    /// </summary>
    public class PerLifeTimeManager: LifetimeManager
    {
        /// <summary>
        /// 
        /// </summary>
        private object value;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void RemoveValue()
        {
            value = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(object newValue)
        {
            value = newValue;
        }
        
    }
}
