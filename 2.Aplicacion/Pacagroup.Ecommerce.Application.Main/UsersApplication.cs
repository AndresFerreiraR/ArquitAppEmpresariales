
namespace Pacagroup.Ecommerce.Application.Main
{
    using AutoMapper;
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Application.Interface;
    using Pacagroup.Ecommerce.Domain.Interface;
    using Pacagroup.Ecommerce.Transversal.Common;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class UsersApplication : IUsersApplication
    {

        /// <summary>
        /// 
        /// </summary>
        private IUsersDomain _usersDomain;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            this._usersDomain = usersDomain;
            this._mapper = mapper;
        }

        public Response<UsersDto> Authenticate(string userName, string password)
        {
            var response = new Response<UsersDto>();

            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                response.Message = "Los parametros no pueden ser vacios";
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(userName, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion exitosa!";
            }
            catch(InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
