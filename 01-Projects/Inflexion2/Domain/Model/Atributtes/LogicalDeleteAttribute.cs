// derived from sharpArchitecture

namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    ///     Facilitates indicating which Classes are logical deleteable
    /// </summary>
    /// <remarks>
    ///     This is intended for use with <see cref="Entity{TIdentifier}" />.  It may NOT be used on a <see cref="ValueObject" />.
    /// </remarks>
    [Serializable]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LogicalDeleteAttribute : Attribute
    {
    }
}