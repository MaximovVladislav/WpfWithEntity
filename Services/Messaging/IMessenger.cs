using System;

namespace Services.Messaging
{
    /// <summary>
    /// Интерфейс для обмена сообщениями между VM
    /// </summary>
    public interface IMessenger
    {
        /// <summary>
        /// Регистрирует действие, которое должно выполниться при приходе сообщения заданного типа
        /// </summary>
        /// <typeparam name="TMessage">Тип сообщения</typeparam>
        /// <param name="action">Действие</param>
        void Register<TMessage>(Action<TMessage> action) where TMessage : IMessage;

        /// <summary>
        /// Отправляет сообщение заданного типа
        /// </summary>
        /// <typeparam name="TMessage">Тип сообщения</typeparam>
        /// <param name="message">Сообщение</param>
        void Send<TMessage>(TMessage message) where TMessage : IMessage;
    }
}