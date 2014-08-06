// utilidad de wpf para cambiar el tema con los estilos a aplicar a una aplicación en tiempo de ejecución.


//using System.Windows.Markup; // para incluir Xmlnsdefinition necesitamos este using fuera del namespace
//    //// Registramos los namespace entrecomillados siguiendo la forma de un schema sobre un unico prefijo
//[assembly: XmlnsDefinition("http://schemas.Inflexion.com/xaml/presentation", "Inflexion2.UX.WPF.Utilities")]

////// Asignamos un unico prefijo por defecto para el eschema definido anteriormente
//[assembly: XmlnsPrefix("http://schemas.Inflexion.com/xaml/presentation", "ISth")]
namespace Inflexion.Framework.UserInterface.Wpf.Utilities
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows; // dll: WindowsBase.dll v4.0.30319

    /// <summary>
    /// Esta clase contiene el método para aplicar un fichero de estilo implementado como diccionario de recursos
    /// </summary>
    public class ThemeSelector : DependencyObject
    {

        #region campos publicos
        /// <summary>
        /// Propiedad de dependencia "attachable" de tipo booleano para especificar si el framework element al que se asocia
        /// es actualizable con el estilo de skin aue se ha asociado  a la propiedad CurrentThemeDictionaryProperty.
        /// el funcionamiento es que CurrentThemeDictionaryProperty contiene el uri del estilo que se desea aplicar como skin.
        /// y para las ventanas que en un momento dado se encuentran activas si tienen ApplyGlobalThemeProperty =  true 
        /// estaran referenciadas por la propiedad interna de elementsWithGlobalTheme que mantiene un registro de las ventanas abiertas que se han 
        /// marcado como actualizables en el skin.
        /// Como es una propiedad observable cada vez que se produce un cambio del contenido del uri el callback de aplyGlobalthemeProperty se encarga de actualizar 
        /// todas las ventanas que mantiene en su registro.
        /// La forma correcta de aplicar esta propiedad es asociarla a elemento raiz de la ventana o user control cuyo skin queremos controlar.
        /// No es posible asociar varios valores de ture y false simultanemente dentro de un mismo arbol visual.
        /// </summary>
        public static readonly DependencyProperty ApplyGlobalThemeProperty =
                                                            DependencyProperty.RegisterAttached(
                                                                                                "ApplyGlobalTheme",
                                                                                                typeof(bool),
                                                                                                typeof(ThemeSelector),
                                                                                                new UIPropertyMetadata(false, ApplyGlobalThemeChanged));

        /// <summary>
        /// Registramos la propiedad de dependencia con el uri que ha de apuntar al tema cargado en un momento dado
        /// La implementación de una propiedad de dependencia tiene tres pasos
        /// 1º)el registo de la propiedad.
        /// 2º)implemtar el metodo de callback.
        /// 3º)(opcional)la implantación de los seters y geters. 
        ///     nota:  el codigo generado desde xaml no pasa por estos getters y seters. 
        ///     por lo que para implementar logica es necesario buscar otros metodos.
        /// </summary>
        public static readonly DependencyProperty CurrentThemeDictionaryProperty =
            DependencyProperty.RegisterAttached(
                                                 "CurrentThemeDictionary",   // <param> nombre de la nueva propiedad de dependencia a registrar 
                                                 typeof(Uri),                // <param> nuevo tipo de la propiedad de dependencia es un uri para poder 
                                                 typeof(ThemeSelector),      // <param> tipo o clase propietaria de la propiedad de dependencia
                                                 new UIPropertyMetadata(null, CurrentThemeDictionaryChanged)); // <params> valor por defecto, property Changed Callback*/

        #endregion

        #region campos privados
        /// <summary>
        /// Registro donde almacenamos la lisa de ventanas abiertas con skin actualizable de forma dinamica.
        /// Este registro se actualiza en el proceos de inicilización de la ventana cuando la propiedad ApplyGlobalThemeProperty vale "True"
        /// </summary>
        private static List<FrameworkElement> elementsWithGlobalTheme = new List<FrameworkElement>();

        /// <summary>
        /// Guardamos en esta uri la referencia al estilo que queremos aplicar de forma global.
        /// </summary>
        private static Uri globalThemeDictionary = null;
        #endregion

        #region Propiedades publicas

        /// <summary>
        /// soporte publico al campo privado globalThemeDictionary
        /// </summary>
        public static Uri GlobalThemeDictionary
        {
            get
            {
                return globalThemeDictionary;
            }
            set
            {
                globalThemeDictionary = value;

                // Se aplica a todos los elementos registrados para usar el skin global 
                foreach (FrameworkElement element in elementsWithGlobalTheme)
                {
                    if (GetApplyGlobalTheme(element))
                    {
                        ApplyTheme(element, globalThemeDictionary);
                    }

                }
            }
        }
        #endregion

        /// <summary>
        /// Obtenemos el uri que actualmente esta activado como tema de la aplicación
        /// </summary>
        /// <param name="obj">La propiedad de dependencia </param>
        /// <returns>El uri con el tema cargado</returns>
        public static Uri GetCurrentThemeDictionary(DependencyObject obj) // 3º Paso Implementamos los setters y getters
        {
            if (obj != null)
            {
                return (Uri)obj.GetValue(CurrentThemeDictionaryProperty); //obtenemos el valor del theme aplicado como un uri
            }
            return null;
        }

        /// <summary>
        /// Establecemos el nuevo valor de al propiedad de dependencia
        /// </summary>
        /// <param name="obj">La propiedad de dependencia que deseamos establecer</param>
        /// <param name="value">El uri con el nuevo tema a aplicar</param>
        public static void SetCurrentThemeDictionary(DependencyObject obj, Uri value)
        {
            if (obj != null)
            {
                obj.SetValue(CurrentThemeDictionaryProperty, value);   //establecemos el valor del theme aplicado
            }

        }



        #region Global Theme


        /// <summary>
        /// obtiene el tema que esta aplicado al objeto de dependencia que pasamos como parametro
        /// </summary>
        /// <param name="obj"> objeto del arbol visual del que queremos conocer el skin asignado</param>
        /// <returns>devuelve el tipo de tema aplicado al objeto</returns>
        public static bool GetApplyGlobalTheme(DependencyObject obj)
        {
            if (obj != null)
            {
                return (bool)obj.GetValue(ApplyGlobalThemeProperty);
            }
            return false;
        }

        /// <summary>
        /// Almacena para el objeto al se ha asociado la propiedad de dependencia si se aplica el skin "valor true" o no se aplica "valor false"
        /// </summary>
        /// <param name="obj">elemento del arból visual que se deseaman tener sincronizado con el tema o no.</param>
        /// <param name="value">valor true para mantener la sincronización false para no mantenerla</param>
        public static void SetApplyGlobalTheme(DependencyObject obj, bool value)
        {
            if (obj != null)
            {
                obj.SetValue(ApplyGlobalThemeProperty, value);
            }
        }


        /// <summary>
        /// Aplicamos un "tema" referenciado por el nombre de fichero "lose" xaml 
        /// con los estilos del tema 
        /// a un objeto de tipo FrameworkElement
        /// Si este elemento es el contenedor raiz de la ventana, o control de usuario
        /// el nuevo estilo se aplica a todo el contenido
        /// </summary>
        /// <param name="targetElement"> corresponde al valor de la propiedad "Name" de un panel en xaml </param>
        /// <param name="dictionaryUri">coorresponde al path con el que localizamos el fichero loose xaml con el estilo deseado
        /// el fichero se ha de localizar dentro de la carpeta Themes ubicada a su vez en la carpeta en la que se ejecuta la aplicación.
        /// el formato del uri coresponde a la cadena formada por ("/ThemeSelector;component/Themes/" + FileNameTheme)
        /// Para mas información sobre los uris consultar http://msdn.microsoft.com/en-us/library/aa970069.aspx
        /// </param>
        private static void ApplyTheme(FrameworkElement targetElement, Uri dictionaryUri)
        {
            if (targetElement == null)
            {
                return;
            }
            try
            {
                // Los temas se almacenan en dicionarios de recursos que ha su vez se coleccionan en diccionarios mezclados.
                ResourceDictionary themeDictionary = null;
                if (dictionaryUri != null)
                {
                    themeDictionary = new ResourceDictionary();
                    themeDictionary.Source = dictionaryUri;

                    // añadimos el nuevo diccionario a la colección de diccionarios mezclados en el objeto al que queremos aplicar el tema.
                    targetElement.Resources.MergedDictionaries.Insert(0, themeDictionary);
                }


                //Comprobamos si el objeto al que queremos aplicar el nuevo tema tiene previamente un tema asociado.
                List<ResourceDictionary> existingDictionaries =
                    (from dictionary in targetElement.Resources.MergedDictionaries.OfType<ResourceDictionary>()
                     select dictionary).ToList();

                // eliminamos los diccionarios previamente asociados  
                foreach (ResourceDictionary thmDictionary in existingDictionaries)
                {
                    if (themeDictionary == thmDictionary)
                    {
                        continue;  // excepto el que acabamos de añadir.
                    }
                    targetElement.Resources.MergedDictionaries.Remove(thmDictionary);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 2º Paso Implementamos el metodo de callback mediante un evento de cambio en una propiedad de dependencia.
        /// el objeto del callBack es realizar una validación sobre el objeto que se la pasa
        /// en este caso si el objeto es correcto aplicamos el tema y si no lo es no hacemos nada.
        /// si implementamos esta llamda en el elemento raiz del la ventana nunca tendremos ningun problema.
        /// una posibilidad seria comprobara que ademas de ser un frameworlelement es un elemento raiz pero de esta forma 
        /// no podriamos utilizar esta clase para cambiar el tema a otro conjunto de elementos.
        /// </summary>
        /// <param name="obj">Objeto sobre el que se aplica el nuevo tema</param>
        /// <param name="e">Referencia uri del nuevo tema</param>
        private static void CurrentThemeDictionaryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is FrameworkElement) // El cambio de tema solo se puede aplicar a objetos que deriven del FrameworkElement
            // como por ejemplo cualquiera de los paneles que actuan como contenedores 
            {                            // Para cambiar por completo el aspecto de la aplicación es necesario que lo apliquemos al elemnto raiz.
                ApplyTheme(obj as FrameworkElement, GetCurrentThemeDictionary(obj));
            }
        }

        /// <summary>
        /// manejador del evnto de cambio del skin 
        /// </summary>
        /// <param name="obj">objeto origen del evento</param>
        /// <param name="e">evento de cambio </param>
        private static void ApplyGlobalThemeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is FrameworkElement)
            {
                FrameworkElement element = obj as FrameworkElement;
                if ((bool)e.NewValue)  // si la propieda se cambia a 'true',entonces añadimos a lalista de elementos a aplicar el estilo del skin.
                {
                    if (!elementsWithGlobalTheme.Contains(element))
                    {
                        elementsWithGlobalTheme.Add(element);
                    }
                    // aplicacmos el estilo del skin
                    ApplyTheme(element, GlobalThemeDictionary);
                }
                else
                {
                    if (elementsWithGlobalTheme.Contains(element))
                    {
                        elementsWithGlobalTheme.Remove(element);
                    }
                    //  aplicamos el skin del tema local en vez del skin global apply 
                    ApplyTheme(element, GetCurrentThemeDictionary(element));
                }
            }
        }

        #endregion

    } // ThemeSelector

} // Inflexion.Framework.Interface.WPF.Utilities