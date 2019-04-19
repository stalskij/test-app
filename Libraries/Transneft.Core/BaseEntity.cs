using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core
{
    /// <summary>
    /// Базовый класс сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Возвращает или задает идентификатор сущности
        /// </summary>
        public int Id { get; set; }
    }
}
