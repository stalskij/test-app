using System;
using System.Collections.Generic;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Core.Domain.Companies
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class AffiliatedCompany : BaseEntity
    {
        /// <summary>
        /// Возвращает или задает идентификатор головной предприятии
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает адрес организации
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Возвращает или задает головное предприятие
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Список объектов потребления
        /// </summary>
        public virtual ICollection<ConsumptionObject> ConsumptionObjects { get; set; }
    }
}
