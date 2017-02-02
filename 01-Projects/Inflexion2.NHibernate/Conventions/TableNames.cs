namespace Inflexion2.Domain
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
    /// convention for many to many table name
    /// </summary>
    public class ManyToManyTableName : ManyToManyTableNameConvention
    {
        /// <summary>
        /// get the name of the intermediate table for M:M realtionship
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="otherSide"></param>
        /// <returns></returns>
        protected override string GetBiDirectionalTableName(
            IManyToManyCollectionInspector collection,
            IManyToManyCollectionInspector otherSide)
        {
            return Inflector.Underscore(collection.EntityType.Name + "_" + otherSide.EntityType.Name).ToUpper();
        }

        /// <summary>
        /// get the name of the father table
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return Inflector.Underscore(collection.EntityType.Name + "_" + collection.ChildType.Name).ToUpper();
        }
    }

    /// <summary>
    /// apply the convention for M:M table
    /// </summary>
    public class TableNameConvention : IClassConvention
    {
        /// <summary>
        /// get the english plural for the table name in upperr charaters
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IClassInstance instance)
        {
            instance.Table("`" + Inflector.Underscore(instance.EntityType.Name).ToUpper() + "´");
        }
    }
}