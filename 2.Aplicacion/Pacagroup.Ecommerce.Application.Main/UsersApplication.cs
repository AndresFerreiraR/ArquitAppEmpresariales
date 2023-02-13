/*
 
 
 */
namespace Pacagroup.Ecommerce.Application.Main
{
    using AutoMapper;
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Application.Interface;
    using Pacagroup.Ecommerce.Application.Validator;
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

        /// <summary>
        /// 
        /// </summary>
        private readonly UsersDtoValidator _usersDtoValidator;


        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator usersDtoValidator)
        {
            this._usersDomain = usersDomain;
            this._mapper = mapper;
            this._usersDtoValidator = usersDtoValidator;
        }

        public Response<UsersDto> Authenticate(string userName, string password)
        {
            var response = new Response<UsersDto>();

            var validation = _usersDtoValidator.Validate(new UsersDto { UserName = userName, Password = password });

            if(!validation.IsValid)
            {
                response.Message = "Error en la validacion";
                response.Errors = validation.Errors;
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
