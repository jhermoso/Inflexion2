//----------------------------------------------------------------------------------------------
// <copyright file="EntityFrameworkUnitOfWork.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Data.Entity;

    /// <summary>
    /// Entity Framework Unit Of Work adapter class
    /// </summary>
    public class EntityFrameworkUnitOfWork : IEntityFrameworkUnitOfWork
    {
        #region fields
        private DbContext dbContext;
        private bool disposed;
        #endregion

        #region constructors
        /// <summary>
        /// parametrized constructor of a Entity Framework Unit Of Work
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkUnitOfWork(DbContext context)
        {
            this.dbContext = context;
        }
        #endregion

        #region methods adapted
        /// <summary>
        /// commit changes adaptor for EF
        /// </summary>
        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        /// <summary>
        /// Implement IDisposable.
        /// Do not make this method virtual.
        /// A derived class should not be able to override this method.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// in EF don't call the save changes in a transaction is equivalent to rool back
        /// </summary>
        public void RollbackChanges()
        {
            
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();

                    this.dbContext = null;
                }

                // Note disposing has been done.
                this.disposed = true;
            }
        }
        #endregion
    }
}