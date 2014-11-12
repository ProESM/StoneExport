using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Base;

namespace Infrastructure
{
    /// <summary>
    ///  Базовый интерфейс для объекта общего дерева
    /// </summary>
    public interface IBaseTreeDao : IEntity
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// Id родительского объекта
        /// </summary>
        Guid? ParentId { get; set; }        
        /// <summary>
        /// Наименование объекта
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Короткое имя объекта
        /// </summary>
        string ShortName { get; set; }
        /// <summary>
        /// Состояние объекта
        /// </summary>
        Guid StateId { get; set; }
        /// <summary>
        /// ТИп объекта
        /// </summary>
        Guid TypeId { get; set; }
        /// <summary>
        /// Дата и время создание объекта
        /// </summary>
        DateTime CreateDateTime { get; set; }
    }
}
