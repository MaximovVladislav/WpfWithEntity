using System.Threading.Tasks;
using Services.Messaging;

namespace UI.ViewModels.Base
{
    /// <summary>
    /// Базовый класс для VM с ленивой инициализацией, реализует интерфейс <see cref="IInitializable"/>
    /// </summary>
    public abstract class LazyInitializableViewModel : ViewModelBase, IInitializable
    {
        protected bool IsInitialized, IsInitializing;

        protected LazyInitializableViewModel()
        {
        }

        protected LazyInitializableViewModel(IMessenger messenger) : base(messenger)
        {
        }

        public async Task InitializeAsync()
        {
            if (IsInitialized || IsInitializing)
                return;

            IsInitializing = true;

            await RefreshAsync();

            IsInitialized = true;
            IsInitializing = false;

        }

        protected abstract Task RefreshAsync();
    }
}