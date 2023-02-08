
namespace Pacagroup.Ecommerce.Application.Interface
{
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Transversal.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ICustomersApplication
    {
        #region Sincronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Response<bool> Insert(CustomersDto customersDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Response<bool> Update(CustomersDto customersDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Response<bool> Delete(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Response<CustomersDto> Get(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Response<IEnumerable<CustomersDto>> GetAll();

        #endregion

        #region Asincronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task<Response<bool>> InsertAsync(CustomersDto customersDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateAsync(CustomersDto customersDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteAsync(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Response<CustomersDto>> GetAsync(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();

        #endregion
    }
}
