using Services.Messaging;
using UI.ViewModels.Base;

namespace UI.ViewModels.StatusBar
{
    /// <summary>
    /// Модель представления строки состояния
    /// </summary>
    public class StatusBarViewModel : ViewModelBase
    {
        private string _statusString;

        public StatusBarViewModel(IMessenger messenger) : base(messenger)
        {
            messenger.Register<StatusBarMessage>(OnMessageReceived);
        }

        public string StatusString
        {
            get { return _statusString; }
            set { Set(ref _statusString, value); }
        }

        private void OnMessageReceived(StatusBarMessage message)
        {
            StatusString = message.Text;
        }
    }
}