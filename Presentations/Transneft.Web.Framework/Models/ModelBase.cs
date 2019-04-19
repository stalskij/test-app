using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Web.Framework.Models
{
    /// <summary>
    /// Представляет базовую модель
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// Возвращает или задает идентификатор модели
        /// </summary>
        public virtual int Id { get; set; }
    }
}
