using Services.Messaging;
using UI.ViewModels.Base;
using UI.ViewModels.StatusBar;

namespace UI.ViewModels.BusyIndicator
{
    /// <summary>
    /// Модель представления индикатора занятости
    /// </summary>
    public class BusyIndicatorViewModel : ViewModelBase
    {
        private string _text;

        public BusyIndicatorViewModel(IMessenger messenger) : base(messenger)
        {
            messenger.Register<BusyIndicatorMessage>(OnMessageReceived);
        }

        private void OnMessageReceived(BusyIndicatorMessage message)
        {
            _text = message.Text;
            Busy = message.Busy;
        }

        #region Busy

        private bool _busy;
        private object _busyLock = new object();
        private volatile int _count;

        public bool Busy
        {
            get { return _busy; }
            protected set
            {
                lock (_busyLock)
                {
                    if (value)
                    {
                        _count++;
                    }
                    else
                    {
                        _count--;
                    }

                    if (Set(ref _busy, _count > 0))
                    {
                        OnBusyChanged();
                    }
                }
            }
        }

        private void OnBusyChanged()
        {
            _messenger.Send(new StatusBarMessage(Busy ? (_text ?? "Загрузка...") : "Готово."));
        }

        #endregion
    }
}