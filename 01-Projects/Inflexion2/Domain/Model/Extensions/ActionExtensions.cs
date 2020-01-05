// <author>Christian Andritzky, centum-amm</author>
// <date>2015-12-23</date>

namespace Inflexion2
{
    using System;

    /// <summary>
    /// Extension methods for the <see cref="Action"/> delegate.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Invokes the specified action (if not null).
        /// </summary>
        /// <param name="action">The action.</param>
        public static void RaiseEvent(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        /// <summary>
        /// Invokes the specified action (if not null).
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="arg">The argument.</param>
        public static void RaiseEvent<T>(this Action<T> action, T arg)
        {
            if (action != null)
            {
                action(arg);
            }
        }
    }
}