// -----------------------------------------------------------------------
// <copyright file="AsyncCallHelper.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Helpers
{
    using System;
    using System.Threading;
    using System.Windows.Threading;

    /// <summary>
    /// TODO: update summary
    /// </summary>
    public partial class AsyncCallHelper
    {
        /// <summary>
        /// todo: update summary
        /// </summary>
        /// <param name="isBusy"></param>
        /// <param name="operation"></param>
        /// <param name="resultHandler"></param>
        public static void Execute(Action<bool> isBusy, Func<AsyncCallResult> operation, Action<AsyncCallResult> resultHandler)
        {
            if (isBusy == null)
                throw new ArgumentNullException("isBusy");

            if (operation == null)
                throw new ArgumentNullException("operation");

            if (resultHandler == null)
                throw new ArgumentNullException("resultHandler");

            // Get current thread dispatcher
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

            // Set the busy indicator
            isBusy.Invoke(true);

            // Crate an async operation delegate instance.
            Func<Action<bool>, AsyncCallResult> asyncOperation = new Func<Action<bool>, AsyncCallResult>((a) => { return operation.Invoke(); });

            // Start async operation.
            var operationHandler =  asyncOperation.BeginInvoke(isBusy, (ar) =>
            {
                // Retrieve the delegate instance.
                var dlgt = (Func<Action<bool>, AsyncCallResult>)ar.AsyncState;

                // Call EndInvoke to retrieve the results.
                var ret = dlgt.EndInvoke(ar);

                // Refresh UI through dispatcher
                dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate
                {
                    try
                    {
                        resultHandler.Invoke(ret);
                    }
                    finally
                    {
                        isBusy.Invoke(false);
                    }
                }, null);

            }, asyncOperation);
        }

    }
}
