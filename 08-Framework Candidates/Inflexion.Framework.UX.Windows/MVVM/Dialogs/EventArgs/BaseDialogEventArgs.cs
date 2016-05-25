// -----------------------------------------------------------------------
// <copyright file="InteractionEventArgs.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.Dialogs
{
    using System;

    /// <summary>
    /// Event args to signal a interaction request
    /// </summary>
    public class BaseDialogEventArgs : EventArgs
    {
        private DialogResultType interactionType;

        /// <summary>
        /// Inicia una nueva instancia de la clase <see cref="BaseDialogEventArgs"/>.
        /// </summary>
        /// <param name="_type">The _type.</param>
        public BaseDialogEventArgs(DialogResultType _type)
        {
            this.Type = _type;
        }

        /// <summary>
        /// Gets type of interaction requested
        /// </summary>
        public DialogResultType Type { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Type.ToString();
        }
    }
}
