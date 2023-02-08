
namespace Pacagroup.Ecommerce.Application.Main
{
    using AutoMapper;
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Application.Interface;
    using Pacagroup.Ecommerce.Domain.Entity;
    using Pacagroup.Ecommerce.Domain.Interface;
    using Pacagroup.Ecommerce.Transversal.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class CustomersApplication : ICustomersApplication
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly ICustomersDomain _customersDomain;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_customersDomain"></param>
        /// <param name="_mapper"></param>
        public CustomersApplication(ICustomersDomain _customersDomain, IMapper _mapper)
        {
            this._customersDomain = _customersDomain;
            this._mapper = _mapper;
        }

        #region Sincronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public Response<bool> Insert(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public Response<bool> Update(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Response<CustomersDto> Get(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        #endregion

        #region Asincronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public async Task<Response<bool>> InsertAsync(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateAsync(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Response<CustomersDto>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);

                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        #endregion

    }
}
