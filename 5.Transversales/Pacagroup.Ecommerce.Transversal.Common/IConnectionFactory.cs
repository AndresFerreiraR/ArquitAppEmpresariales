
namespace Pacagroup.Ecommerce.Transversal.Common
{
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        IDbConnection GetConnection { get; }
    }
}
