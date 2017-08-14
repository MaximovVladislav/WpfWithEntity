using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Autofac;
using UI.IoC;
using UI.ViewModels;
using UI.ViewModels.BusyIndicator;
using UI.ViewModels.StatusBar;

namespace UI
{
    /// <summary>
    /// Этот класс содержит ссылки на основные модели представлений в единственном экземпляре,
    /// представляет точку входа для привязок
    /// </summary>
    public class ViewModelLocator
    {
        private static readonly IContainer _container;
        
        /// <summary>
        /// Статический конструктор вызывается первым,
        /// он нужен для осуществления логики, которая должна быть выполнена до создания первого экземпляра
        /// </summary>
        static ViewModelLocator()
        {
            Initializer.Initialize();
            _container = Initializer.Container;

            Application.Current.Exit += Current_Exit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        /// <summary>
        /// Для создания экземпляра только из App.xaml.
        /// Далее, обращение через свойство <see cref="Default"/>
        /// </summary>
        public ViewModelLocator()
        {
            Default = this;
        }

        /// <summary>
        /// Экземпляр <see cref="ViewModelLocator"/> по умолчанию.
        /// </summary>
        public static ViewModelLocator Default { get; private set; }

        /// <summary>
        /// Главная модель представления
        /// </summary>
        public MainViewModel Main => _container.Resolve<MainViewModel>();

        /// <summary>
        /// Модель представления индикатора занятости
        /// </summary>
        public BusyIndicatorViewModel BusyIndicator => _container.Resolve<BusyIndicatorViewModel>();

        /// <summary>
        /// Модель представления статус бара
        /// </summary>
        public StatusBarViewModel StatusBar => _container.Resolve<StatusBarViewModel>();

        private static void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //TODO: Сделать нормальную обработку исключений
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //TODO: Сделать нормальную обработку исключений
            MessageBox.Show(((Exception)e.ExceptionObject).Message);
        }

        private static void Current_Exit(object sender, ExitEventArgs e)
        {
            _container?.Dispose();
        }
    }
}