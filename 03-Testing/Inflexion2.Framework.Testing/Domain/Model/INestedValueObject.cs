

namespace Inflexion2.Testing
{
    using Inflexion2.Domain;

    /// <summary>
    /// 
    /// </summary>
    public interface INestedValueObject : IValueObject
    {
        int i { get; set; }
        EqualityValueObject.SimpleValueObject n { get; set; }
        string s { get; set; }
    }
}