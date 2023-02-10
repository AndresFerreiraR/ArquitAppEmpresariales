
namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    using Pacagroup.Ecommerce.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public interface IUsersRepository
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
