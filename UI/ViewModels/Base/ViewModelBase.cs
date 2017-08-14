using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Services.Messaging;
using UI.ViewModels.BusyIndicator;

namespace UI.ViewModels.Base
{
    /// <summary>
    /// Базовый класс для VM. Предоставляет методы для асинхронных действий,
    ///  с отправкой сообщения о занятости, и метод обновления свойств.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly IMessenger _messenger;

        protected ViewModelBase() : this(Messenger.Default)
        {
        }

        protected ViewModelBase(IMessenger messenger)
        {
            _messenger = messenger;
        }

        private void SetBusy(bool busy, string text = null)
        {
            _messenger.Send(new BusyIndicatorMessage(busy, text));
        }

        /// <summary>
        /// Выполняет действие асинхронно и возвращает результат
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемого значения</typeparam>
        /// <param name="action">Действие</param>
        /// <param name="text">Текст, с информацией о действии</param>
        /// <returns></returns>
        protected async Task<TResult> Go<TResult>(Func<Task<TResult>> action, string text = null)
        {
            try
            {
                SetBusy(true, text);
                return await action();
            }
            catch (Exception ex)
            {
                //TODO: Обработка исключений
                MessageBox.Show(ex.Message);
                return default(TResult);
            }
            finally
            {
                SetBusy(false);
            }
        }

        /// <summary>
        /// Выполняет действие асинхронно
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="text">Текст, с информацией о действии</param>
        /// <returns></returns>
        protected async Task Go(Func<Task> action, string text = null)
        {
            try
            {
                SetBusy(true, text);
                await action();
            }
            catch (Exception ex)
            {
                //TODO: Обработка исключений
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SetBusy(false);
            }
        }

        /// <summary>
        /// Устанавливает полю значение, если оно изменилось, и оповещает об изменении
        /// </summary>
        /// <typeparam name="T">Тип поля</typeparam>
        /// <param name="field">Поле</param>
        /// <param name="newValue">Новое значение</param>
        /// <param name="propertyName">Имя свойства</param>
        /// <returns></returns>
        protected bool Set<T>(ref T field, T newValue = default(T), [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            RasePropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RasePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}