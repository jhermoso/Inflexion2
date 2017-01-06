// -----------------------------------------------------------------------
// <copyright file="GeneralHelper.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.Helpers
{

    using System.Windows.Controls;
    using System.Windows.Media;


    /// <summary>
    /// Clase pública utilzada como ayuda adicional a acciones habituales o generales.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class GeneralHelper
    {

        #region FUNCTIONS

            /// <summary>
            /// Función pública estática, encargada de obtener un elemento.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="parent"></param>
            /// <returns></returns>
            public static T GetVisualChild<T>(Visual parent) where T : Visual
            {
                T child = default(T);
                int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < numVisuals; i++)
                {
                    Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                    child = v as T;
                    if (child == null)
                    {
                        child = GetVisualChild<T>(v);
                    }
                    if (child != null)
                    {
                        break;
                    }
                }
                return child;
            } // GerVisualChild

        #endregion

    } // GeneralHelper

} // Company.Product.Shared.SharedCore.UI.MVVM.ValueConverters