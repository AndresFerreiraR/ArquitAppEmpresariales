
namespace Pacagroup.Ecommerce.Transversal.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
