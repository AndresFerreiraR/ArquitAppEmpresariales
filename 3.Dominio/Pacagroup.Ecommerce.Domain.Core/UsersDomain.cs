
namespace Pacagroup.Ecommerce.Domain.Core
{
    using Pacagroup.Ecommerce.Domain.Entity;
    using Pacagroup.Ecommerce.Domain.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Interface;

    /// <summary>
    /// 
    /// </summary>
    public class UsersDomain : IUsersDomain
    {

        private IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users Authenticate(string userName, string password)
        {
            return _usersRepository.Authenticate(userName, password);
        }
    }
}
