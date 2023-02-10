
namespace Pacagroup.Ecommerce.Domain.Interface
{
    using Pacagroup.Ecommerce.Domain.Entity;


    /// <summary>
    /// 
    /// </summary>
    public interface IUsersDomain
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Users Authenticate(string userName, string password);
    }
}
