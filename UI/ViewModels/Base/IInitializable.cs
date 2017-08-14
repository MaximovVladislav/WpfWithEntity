using System.Threading.Tasks;

namespace UI.ViewModels.Base
{
    /// <summary>
    /// Интерфейс для фоновой инициализации
    /// </summary>
    public interface IInitializable
    {
        /// <summary>
        /// Инициализирует асинхронно
        /// </summary>
        Task InitializeAsync();
    }
}