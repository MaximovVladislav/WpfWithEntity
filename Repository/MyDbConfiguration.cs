using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Конфигурация БД для EF
    /// </summary>
    internal class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
            this.SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new DefaultExecutionStrategy());
        }
    }
}
