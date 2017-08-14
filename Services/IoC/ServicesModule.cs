using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Model;
using Repository.Repositories;

namespace Services.IoC
{
    /// <summary>
    /// Класс для внедрения зависимостей в рамках проекта
    /// </summary>
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IRepository<User>>().SingleInstance();
        }
    }
}
