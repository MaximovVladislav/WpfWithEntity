using Services.Messaging;

namespace UI.ViewModels.BusyIndicator
{
    /// <summary>
    /// Сообщение для индикатора занятости
    /// </summary>
    public class BusyIndicatorMessage : IMessage
    {
        public BusyIndicatorMessage(bool busy, string text = null)
        {
            Busy = busy;
            Text = text;
        }

        public bool Busy { get; private set; }

        public string Text { get; private set; }
    }
}