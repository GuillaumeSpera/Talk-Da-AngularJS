
namespace App.Data
{
    /// <summary>
    /// Définit un repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Context liée au repository
        /// </summary>
        object Context { set; get; }
    }
}
