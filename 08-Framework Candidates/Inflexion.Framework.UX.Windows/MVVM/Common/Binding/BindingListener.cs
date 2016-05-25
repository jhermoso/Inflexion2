// -----------------------------------------------------------------------
// <copyright file="BindingListener.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public sealed class BindingListener : DefaultTraceListener
    {
        private static BindingListener _Listener;

        public static void SetTrace()
        { 
            SetTrace(SourceLevels.Error, TraceOptions.None); 
        }

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

        public override void Write(string message)
        { 
            _Message.Append(message); 
        }

        public override void WriteLine(string message)
        {
            _Message.Append(message);

            var final = _Message.ToString();
            _Message.Length = 0;

            Console.WriteLine(final);
        }
    }
}