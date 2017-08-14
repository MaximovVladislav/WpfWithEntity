using Autofac;
using Services.IoC;
using Services.Messaging;
using Services.UserData;
using UI.ViewModels;
using UI.ViewModels.BusyIndicator;
using UI.ViewModels.StatusBar;

namespace UI.IoC
{
    /// <summary>
    /// Класс для внедрения зависимостей в рамках решения
    /// </summary>
    public class Initializer
    {
        /// <summary>
        /// Контейнер зависимостей
        /// </summary>
        public static IContainer Container { get; set; }

        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<ServicesModule>();

            builder.RegisterType<Messenger>().As<IMessenger>().SingleInstance();

            builder.RegisterType<UserDataService>().As<IUserDataService>();

            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<BusyIndicatorViewModel>().SingleInstance();
            builder.RegisterType<StatusBarViewModel>().SingleInstance();

            Container = builder.Build();
        }
    }
}