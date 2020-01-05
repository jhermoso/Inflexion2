// -----------------------------------------------------------------------
// <copyright file="AsyncCallResult.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Helpers
{
    using System;

    /// <summary>
    /// encapsulation of the result of an asynchronous operation.
    /// </summary>
    public class AsyncCallResult
    {
        /// <summary>
        /// Todo: update summary
        /// </summary>
        public object Result { get; private set; }

        /// <summary>
        /// Todo: update summary
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// Todo: update summary
        /// </summary>
        public bool OperationFailed
        {
            get { return Error != null; }
        }

        /// <summary>
        /// Todo: update summary
        /// </summary>
        /// <param name="exception"></param>
        public AsyncCallResult(Exception exception)
        {
            Error = exception;
        }

        /// <summary>
        /// Todo: update summary
        /// </summary>
        /// <param name="result"></param>
        public AsyncCallResult(object result)
        {
            Result = result;
        }
    }
}
