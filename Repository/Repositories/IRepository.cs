using System;
using System.Collections.Generic;
using Model;
using Model.Base;

namespace Repository.Repositories
{
    /// <summary>
    /// Интерфейс хранилища данных сущностей типа <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Создает сущность в хранилище
        /// </summary>
        /// <returns></returns>
        TEntity Create();
        /// <summary>
        /// Получает все сущности из хранилища
        /// </summary>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Изменяет сущность
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// Удаляет сущность из хранилища
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(TEntity entity);
        
    }
}