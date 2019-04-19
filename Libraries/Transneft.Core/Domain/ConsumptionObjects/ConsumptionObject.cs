using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Domain.Companies;

namespace Transneft.Core.Domain.ConsumptionObjects
{
    /// <summary>
    /// Объект потребления
    /// </summary>
    public class ConsumptionObject: BaseEntity
    {
        /// <summary>
        /// Возвращает или задает наименование объекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает адрес объекта
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор дочерней организации
        /// </summary>
        public int AffiliatedCompanyId { get; set; }

        /// <summary>
        /// Возвращает или задает дочернюю организацию
        /// </summary>
        public virtual AffiliatedCompany AffiliatedCompany { get; set; }
    }
}
