using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core.Domain.Companies
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// Возвращает или задает наименование организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает адрес организации
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Список дочерних организаций
        /// </summary>
        public virtual ICollection<AffiliatedCompany> AffiliatedCompanies { get; set; }
    }
}
