// -----------------------------------------------------------------------
// <copyright file="SpecificationsLinqExtensions..cs" company="Inflexion Software">
//      Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
// Based on https://github.com/cmendible/Hexa.Core/blob/master/Hexa.Core/Domain/Specification/SpecificationModel.cs
namespace Inflexion2.Extensions
{
    using Inflexion2.Domain.Specification;
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public static class SpecificationsLinqExtensions
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static ISpecification<T> AndAlso<T>(this ISpecification<T> query, string column, object value,
                string operation)
        where T : class
        {
            return query.AndAlso(CreateSpecification<T>(column, value, operation));
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static ISpecification<T> CreateSpecification<T>(string column, object value, string operation)
        where T : class
        {
            Type inspectedType = typeof(T);

            ParameterExpression parameter = Expression.Parameter(inspectedType, "p");
            MemberExpression memberAccess = _GetMemberAccess(inspectedType, column, parameter);

            if (memberAccess.Type == typeof(DateTime))
            {
                column += ".Date";
                memberAccess = _GetMemberAccess(inspectedType, column, parameter);
            }

            if (memberAccess.Type == typeof(System.Nullable<DateTime>))
            {
                column += ".Value";
                memberAccess = _GetMemberAccess(inspectedType, column, parameter);
            }

            //change param value type
            //necessary to getting bool from string
            ConstantExpression filter = Expression.Constant
                                        (
                                            Convert.ChangeType(value, memberAccess.Type)
                                        );

            Expression condition = null;
            LambdaExpression lambda = null;
            switch (operation)
            {
                //equal ==
            case "IsEqualTo":
                condition = Expression.Equal(memberAccess, filter);

                lambda = Expression.Lambda(condition, parameter);
                break;
                //not equal !=
            case "IsNotEqualTo":
                condition = Expression.NotEqual(memberAccess, filter);
                lambda = Expression.Lambda(condition, parameter);
                break;
                //string.Contains()
            case "Contains":
                condition = Expression.Call(memberAccess,
                                            typeof(string).GetMethod("Contains"),
                                            Expression.Constant(value));

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "StartsWith":
                condition = Expression.Call(memberAccess,
                                            typeof(string).GetMethod("StartsWith", new[] { typeof(string) }),
                                            Expression.Constant(value));

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "EndsWith":
                condition = Expression.Call(memberAccess,
                                            typeof(string).GetMethod("EndsWith", new[] { typeof(string) }),
                                            Expression.Constant(value));

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "IsGreaterThan":
                condition = Expression.GreaterThan(memberAccess, filter);

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "IsGreaterThanOrEqualTo":
                condition = Expression.GreaterThanOrEqual(memberAccess, filter);

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "IsLessThan":
                condition = Expression.LessThan(memberAccess, filter);

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "IsLessThanOrEqualTo":
                condition = Expression.LessThanOrEqual(memberAccess, filter);

                lambda = Expression.Lambda(condition, parameter);
                break;
            case "DoesNotContain":
                condition = Expression.Call(memberAccess,
                                            typeof(string).GetMethod("Contains"),
                                            Expression.Constant(value));

                condition = Expression.Not(condition);

                lambda = Expression.Lambda(condition, parameter);

                break;
            default:
                throw new ArgumentOutOfRangeException("operation");
            }

            Expression<Func<T, bool>> hLambda = Expression.Lambda<Func<T, bool>>(condition, parameter);

            return new DirectSpecification<T>(hLambda);
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static ISpecification<T> OrElse<T>(this ISpecification<T> query, string column, object value,
                string operation)
        where T : class
        {
            return query.OrElse(CreateSpecification<T>(column, value, operation));
        }

        private static MemberExpression _GetMemberAccess(Type inspectedType, string column, ParameterExpression parameter)
        {
            Type typeToInspect = inspectedType;

            MemberExpression memberAccess = null;
            foreach (string property in column.Split('.'))
            {
                //if (property == typeToInspect.Name)
                //{
                //    continue;
                //}

                PropertyInfo propertyInfo = typeToInspect.GetProperty(property);
                if (propertyInfo == null && typeToInspect.IsInterface)
                {
                    Type[] implementedInterfaces = typeToInspect.GetInterfaces();
                    foreach (Type implementedInterface in implementedInterfaces)
                    {
                        propertyInfo = implementedInterface.GetProperty(property);
                        if (propertyInfo != null)
                        {
                            typeToInspect = implementedInterface;
                            break;
                        }
                    }
                }

                if (propertyInfo == null)
                {
                    throw new MissingMemberException(inspectedType.FullName, column);
                }

                memberAccess = Expression.Property
                               (memberAccess ?? (parameter as Expression), propertyInfo);

                typeToInspect = propertyInfo.PropertyType;
            }
            return memberAccess;
        }

        #endregion Methods
    }
}
