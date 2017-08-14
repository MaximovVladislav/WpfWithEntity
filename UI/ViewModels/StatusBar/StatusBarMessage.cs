using Services.Messaging;

namespace UI.ViewModels.StatusBar
{
    /// <summary>
    /// Сообщение для строки состояния
    /// </summary>
    public class StatusBarMessage : IMessage
    {
        public StatusBarMessage(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}