using System.Configuration;

namespace Repository
{
    /// <summary>
    /// Класс для получения строк подключения
    /// </summary>
    public static class ConnectionManager
    {
        /// <summary>
        /// Возвращает строку подключения из конфига
        /// </summary>
        public static string GetConnectionString()
        {
            string connectionString = null;
            var setting = ConfigurationManager.ConnectionStrings["Source"];
            if (setting != null)
                connectionString = setting.ConnectionString;

            return connectionString;
        }
    }
}