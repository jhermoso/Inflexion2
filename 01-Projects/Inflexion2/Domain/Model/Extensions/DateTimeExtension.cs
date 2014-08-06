// -----------------------------------------------------------------------
// <copyright file="DateTimeExtension.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Clase estática que define métodos extensores para la clase
    /// <see cref="T:System.DateTime"/>.
    /// </summary>
    /// <remarks>
    /// Para utilizar los métodos extensores es necesario incluir el
    /// espacio de nombres <see cref="N:Inflexion2.Domain.Extensions"/>.
    /// </remarks>
    public static class DateTimeExtension
    {
        #region Methods

        /// <summary>
        /// Método que compara dos fechas teniendo en cuenta que el día empieza a las 6:00 y termina a las 5:59.
        /// </summary>
        /// <param name="date">
        /// Parámetro que indica la fecha a comparar.
        /// </param>
        /// <param name="value">
        /// Parámetro que indica el valor de la fecha a comparar.
        /// </param>
        /// <returns>
        /// - Un valor menor que cero indica que esta fecha es anterior al valor comparado.
        /// - Un valor mayor que cero indica que esta fecha es posterior al valor comparado.
        /// - Un valor igual a cero indica que ambas fechas comparadas son iguales.
        /// </returns>
        public static int CompareTo24(this DateTime date, DateTime value)
        {
            DateTime dt1 = date.Normalize(true);
            DateTime dt2 = value.Normalize(true);

            return dt1.CompareTo(dt2);
        }

        /// <summary>
        /// Compone un campo DateTime con la fecha y hora combinadas a partir de dos campos datetime separados.
        /// </summary>
        /// <param name="dia">
        /// Parámetro que indica el valor para el dia.
        /// </param>
        /// <param name="hora">
        /// Parámetro que indica el valor para la hora.
        /// </param>
        /// <returns>
        /// Devuelve el dia / hora combinados.
        /// </returns>
        public static DateTime Compose(this DateTime dia, DateTime? hora)
        {
            if (hora.HasValue)
            {
                return new DateTime(dia.Year, dia.Month, dia.Day, hora.Value.Hour, hora.Value.Minute, hora.Value.Second);
            }
            else
            {
                return new DateTime(dia.Year, dia.Month, dia.Day);
            }
        }

        /// <summary>
        /// Método que compara una fecha, su hora de inicio y su hora de fin.
        /// </summary>
        /// <param name="date">
        /// Parámetro que indica la fecha.
        /// </param>
        /// <param name="time1">
        /// Parámetro que indica la hora de inicio.</param>
        /// <param name="time2">
        /// Parámetro que indica laa hora de fin.
        /// </param>
        /// <returns>
        /// - Un valor menor que cero indica que hora1 es anterior a hora2.
        /// - Un valor mayor que cero indica que hora1 es posterior a hora2.
        /// - Un valor igual a cero indica que ambas horas comparadas son iguales.
        /// </returns>
        public static int ComposeAndCompareTo24(this DateTime date, DateTime time1, DateTime time2)
        {
            DateTime dt1 = date.Compose(time1);
            DateTime dt2 = date.Compose(time2);

            return dt1.CompareTo24(dt2);
        }

        /// <summary>
        /// Compone un campo DateTime con la fecha y hora combinadas a partir de dos campos datetime separados.
        /// </summary>
        /// <remarks>
        /// Utilizar este método únicamente en la parrilla.
        /// </remarks>
        /// <param name="dia">
        /// Parámetro que indica valor para el dia.
        /// </param>
        /// <param name="hora">
        /// Parámetro que indica el valor para la hora.</param>
        /// <returns>
        /// Devuelve el dia / hora combinados.
        /// </returns>
        public static DateTime ComposeForSchedule(this DateTime dia, DateTime? hora)
        {
            // Si la hora es menor que 6, debe adelantarse un día para que la parrilla se muestre correctamente.
            return dia.Compose(hora).Normalize(true);
        }

        /// <summary>
        /// Obtiene un DateTime con exclusivamente la parte fecha de otro DateTime.
        /// </summary>
        /// <param name="dateTime">
        /// Parámetro que indica el valor con día y hora.
        /// </param>
        /// <returns>
        /// Devuelve el valor sólo de fecha.
        /// </returns>
        public static DateTime GetDateOnly(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// Utilizar este método únicamente en la parrilla.
        /// Obtiene un DateTime con exclusivamente la parte fecha de otro DateTime.
        /// </summary>
        /// <param name="dateTime">
        /// Parámetro que indica el valor con dia y hora.
        /// </param>
        /// <returns>
        /// Devuelve el valor sólo con fecha.
        /// </returns>
        public static DateTime GetDateOnlyForSchedule(this DateTime dateTime)
        {
            // Si la hora es menor que 6, debe atrasarse un día para que la parrilla se muestre correctamente.
            return dateTime.Normalize(false).GetDateOnly();
        }

        /// <summary>
        /// Obtiene un DateTime con exclusivamente la parte horaria de otro DateTime.
        /// </summary>
        /// <param name="dateTime">
        /// Parámetro que indica el valor con día y hora.
        /// </param>
        /// <returns>
        /// Devuelve el valor sólo con las horas.
        /// </returns>
        public static DateTime GetTimeOnly(this DateTime dateTime)
        {
            return new DateTime(1900, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Kind);
        }

        /// <summary>
        /// Función pública estática que devuelve el número de la semana correspondiente a la
        /// <paramref name="date"/> especificada, en función de los
        /// parámetros culturales del sistema donde se ejecute.
        /// </summary>
        /// <remarks>
        /// Esta función estática devuelve el número de semana de acuerdo a
        /// una fecha dada.
        /// </remarks>
        /// <param name="date">
        /// Pasamos la fecha para la cual queremos obtener el numero de la semana.
        /// </param>
        /// <returns>
        /// Número de la semana para <paramref name="date"/>.
        /// </returns>
        public static int WeekNumber(this DateTime date)
        {
            // Obtenemos la cultura utilizada actualmente.
            DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
            // Obtenemos el calendario activo de la cultura.
            Calendar calendar = dateTimeFormatInfo.Calendar;
            // Calculamos el número de la semana para la fecha especificada.
            int resultado = calendar.GetWeekOfYear(
                                date,
                                dateTimeFormatInfo.CalendarWeekRule,
                                dateTimeFormatInfo.FirstDayOfWeek);
            // Devolvemos el resultado.
            return resultado;
        }

        /// <summary>
        /// Función pública estática que devuelve el número de la semana correspondiente a la
        /// <paramref name="date"/> especificada, en función de los
        /// parámetros culturales del sistema donde se ejecute.
        /// </summary>
        /// <remarks>
        /// Esta función estática devuelve el número de semana de acuerdo a
        /// una fecha dada.
        /// </remarks>
        /// <param name="date">
        /// Pasamos la fecha para la cual queremos obtener el numero de la semana.
        /// </param>
        /// <param name="dateTimeFormatInfo">
        /// Indicamos el formato de fecha y hora de la cultura pasada como argumento.
        /// </param>
        /// <returns>
        /// Número de la semana para <paramref name="date"/>.
        /// </returns>
        public static int WeekNumber(
            this DateTime date,
            DateTimeFormatInfo dateTimeFormatInfo)
        {
            // Obtenemos el calendario activo de la cultura pasada como argumento.
            Calendar calendar = dateTimeFormatInfo.Calendar;
            // Calculamos el número de la semana para la fecha especificada.
            int resultado = calendar.GetWeekOfYear(
                                date,
                                dateTimeFormatInfo.CalendarWeekRule,
                                dateTimeFormatInfo.FirstDayOfWeek);
            // Devolvemos el resultado.
            return resultado;
        }

        /// <summary>
        /// Método empleado para añadir o eliminar un día a la fecha especificada, si la hora es menor que hourShift.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="dateTime">
        /// Parámetro que indica la fecha a arreglar.
        /// </param>
        /// <param name="addDay">
        /// Parámetro indica: <c>True</c> añade un día, <c>false</c> retrasa un día.</param>
        /// <param name="hourShift">
        ///
        /// </param>
        /// <returns>
        /// Devuelve el valor de la fecha normalizado.
        /// </returns>
        private static DateTime Normalize(this DateTime dateTime, bool addDay, int hourShift = 6)
        {
            // Si la hora es menor que hourShift, debe ajustarse de la manera solicitada un día para que la
            // parrilla se muestre correctamente.
            if (dateTime.Hour < hourShift)
            {
                return dateTime.AddDays(addDay ? 1 : -1);
            }
            // Devolvemos la respuesta.
            return dateTime;
        }

        #endregion Methods
    }
}