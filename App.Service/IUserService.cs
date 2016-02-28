
using App.Entities.Business;

namespace App.Service
{
    /// <summary>
    /// User service
    /// </summary>
    public interface IUserService : IService
    {
        User LogIn();
    }
}
