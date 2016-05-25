// -----------------------------------------------------------------------
// <copyright file="AsyncCallResult.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AsyncCallResult
    {
        public object Result { get; private set; }
        public Exception Error { get; set; }

        public bool OperationFailed
        {
            get { return Error != null; }
        }

        public AsyncCallResult(Exception exception)
        {
            Error = exception;
        }

        public AsyncCallResult(object result)
        {
            Result = result;
        }
    }
}
