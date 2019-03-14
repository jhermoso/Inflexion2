

namespace Inflexion2.Testing
{
    using Inflexion2.Domain;
    /// <summary>
    /// 
    /// </summary>
    public interface ISimpleValueObject : IValueObject
    {
        int i { get; set; }
        string s { get; set; }
    }
}