using App.Data.Implements.Context;

namespace App.Data.Implements.Repositories
{
    /// <summary>
    /// Définit une unité de travail pour gérer le mode transactionnel
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DiocesesContext
        /// </summary>
        private DataContext Context { get; set; }

        /// <summary>
        /// Crée une nouvelle instance de UnitOfWork
        /// </summary>
        public UnitOfWork()
        {
            Context = new DataContext();
        }

        /// <summary>
        /// Commit la transaction
        /// </summary>
        public void Commit()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Ajoute un Repository utilisable dans la transaction
        /// </summary>
        /// <param name="repository">Repository à utiliser dans la transaction</param>
        public IUnitOfWork Use(IRepository repository)
        {
            repository.Context = Context;
            return this;
        }

        /// <summary>
        /// Dispose le UnitOfWork
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
