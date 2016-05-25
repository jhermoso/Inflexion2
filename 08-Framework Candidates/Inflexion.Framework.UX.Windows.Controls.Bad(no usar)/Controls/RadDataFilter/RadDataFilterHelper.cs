// -----------------------------------------------------------------------
// <copyright file="RadDataFilterHelper.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// to use this code set the  "Build Action" in Properties Window to value "Compile" 
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.Data.DataFilter;
    using Inflexion.Framework.Application.DataTransfer.Core;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RadDataFilterHelper: DependencyObject
    {
        public RadDataFilterHelper(RadDataFilter dataFilter)
        {
            dataFilter.CanUserCreateCompositeFilters = false;

            dataFilter.ViewModel.CompositeFilter.PropertyChanged += (sender, args) =>
                {
                    BuildSpecification(dataFilter);
                };

            dataFilter.ViewModel.CompositeFilter.Filters.CollectionChanged += (sender, args) =>
            {
                foreach (FilterViewModel filterViewModel in dataFilter.ViewModel.CompositeFilter.Filters)
                {
                    filterViewModel.SimpleFilter.PropertyChanged += (grid, arguments) =>
                    {
                        BuildSpecification(dataFilter);
                    };
                }
            };

            dataFilter.FilterDescriptors.Add(new Telerik.Windows.Data.FilterDescriptor("IsActive", Telerik.Windows.Data.FilterOperator.IsEqualTo, true));
            BuildSpecification(dataFilter);
        }

        public static SpecificationDto GetFilter(RadDataFilter dataFilter)
        {
            return (SpecificationDto)dataFilter.GetValue(FilterProperty);
        }

        public static void SetFilter(RadDataFilter dataFilter, SpecificationDto value)
        {
            dataFilter.SetValue(FilterProperty, value);
        }

        public static readonly DependencyProperty FilterProperty = DependencyProperty.RegisterAttached(
            "Filter",
            typeof(SpecificationDto),
            typeof(RadDataFilterHelper),
            new PropertyMetadata((o, e) =>
            {
                var dataFilter = o as RadDataFilter;
                if (dataFilter != null)
                {
                    new RadDataFilterHelper(dataFilter);
                }
            }));

        private static void BuildSpecification(RadDataFilter dataFilter)
        {
            SpecificationDto specificationDto = GetFilter(dataFilter);
            specificationDto.CompositeFilter.Filters.Clear();

            if (dataFilter.ViewModel.CompositeFilter.LogicalOperator == Telerik.Windows.Data.FilterCompositionLogicalOperator.And)
            {
                specificationDto.CompositeFilter.LogicalOperator = CompositeFilterLogicalOperator.And;
            }
            else
            {
                specificationDto.CompositeFilter.LogicalOperator = CompositeFilterLogicalOperator.Or;
            }

            foreach (FilterViewModel filter in dataFilter.ViewModel.CompositeFilter.Filters)
            {
                if (filter.SimpleFilter.Member != null)
                {
                    var rule = new Filter()
                    {
                        Property = filter.SimpleFilter.Member,
                        Operator = filter.SimpleFilter.Operator.ToString(),
                        Value = filter.SimpleFilter.Value.ToString()
                    };

                    specificationDto.CompositeFilter.Filters.Add(rule);
                }
            }
        }
    } 

}