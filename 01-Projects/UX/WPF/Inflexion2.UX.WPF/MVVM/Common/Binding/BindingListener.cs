// -----------------------------------------------------------------------
// <copyright file="BindingListener.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// https://msdn.microsoft.com/de-de/library/4y5y10s7(v=vs.110).aspx
    /// DefaultTraceListener 
    /// </summary>
    public sealed class BindingListener : DefaultTraceListener
    {
        private static BindingListener _Listener;

        /// <summary>
        /// set trace level to none
        /// </summary>
        public static void SetTrace()
        { 
            SetTrace(SourceLevels.Error, TraceOptions.None); 
        }

        /// <summary>
        /// set trace level option
        /// </summary>
        /// <param name="level"></param>
        /// <param name="options"></param>
        public static void SetTrace(SourceLevels level, TraceOptions options)
        {
            if (_Listener == null)
            {
                _Listener = new BindingListener();
                PresentationTraceSources.DataBindingSource.Listeners.Add(_Listener);
            }

            _Listener.TraceOutputOptions = options;
            PresentationTraceSources.DataBindingSource.Switch.Level = level;
        }

        /// <summary>
        /// close trace
        /// </summary>
        public static void CloseTrace()
        {
          if (_Listener == null)
          { return; }

          _Listener.Flush();
          _Listener.Close();
          PresentationTraceSources.DataBindingSource.Listeners.Remove(_Listener);
          _Listener = null;
        }

        private StringBuilder _Message = new StringBuilder();

        private BindingListener()
        { 
        }

        /// <summary>
        /// add message to trace
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message)
        { 
            _Message.Append(message); 
        }

        /// <summary>
        /// trace to console, command window
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            _Message.Append(message);

            var final = _Message.ToString();
            _Message.Length = 0;

            Console.WriteLine(final);
        }
    }
}