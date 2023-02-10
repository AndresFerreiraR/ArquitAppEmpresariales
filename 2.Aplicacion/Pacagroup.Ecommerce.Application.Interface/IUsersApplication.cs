
namespace Pacagroup.Ecommerce.Application.Interface
{
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Transversal.Common;

    /// <summary>
    /// 
    /// </summary>
    public interface IUsersApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Response<UsersDto> Authenticate(string userName, string password);
    }
}
