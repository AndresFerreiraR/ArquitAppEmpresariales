
namespace Pacagroup.Ecommerce.Domain.Interface
{
    using Pacagroup.Ecommerce.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ICustomersDomain
    {
        #region Sincronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        bool Insert(Customers customers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        bool Update(Customers customers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        bool Delete(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customers Get(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customers> GetAll();

        #endregion

        #region Asincronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(Customers customers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Customers customers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customers> GetAsync(string customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customers>> GetAllAsync();

        #endregion
    }
}
