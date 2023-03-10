
namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    using Pacagroup.Ecommerce.Domain.Entity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ICustomersRepository
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
