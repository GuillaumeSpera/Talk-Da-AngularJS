using System;
using System.Linq;
using App.Data;
using App.Entities.Business;

namespace App.Service.Implements
{
    /// <summary>
    /// User service implementation
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Unit of work to handle transactional mode
        /// </summary>
        public IUnitOfWork UnitOfWork { get; set; }

        public IEntityRepository<User> UserRepository { get; set; }

        public User LogIn()
        {
            try
            {
                using (UnitOfWork.Use(UserRepository))
                {
                    return UserRepository.GetAll().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
