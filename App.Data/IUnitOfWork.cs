using System;

namespace App.Data
{
    /// <summary>
    /// Définit une unité de travail pour gérer le mode transactionnel
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit la transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Ajoute un Repository utilisable dans la transaction
        /// </summary>
        /// <param name="repository">Repository à utiliser dans la transaction</param>
        IUnitOfWork Use(IRepository repository);
    }
}
