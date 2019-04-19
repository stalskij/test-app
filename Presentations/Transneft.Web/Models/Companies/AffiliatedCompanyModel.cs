using System.Collections.Generic;
using Transneft.Web.Models.ConsumptionObjects;
using Transneft.Web.Framework.Models;

namespace Transneft.Web.Models.Companies
{
    /// <summary>
    /// Мдель дочерней организации
    /// </summary>
    public class AffiliatedCompanyModel : ModelBase
    {
        public AffiliatedCompanyModel()
        {
            ConsumptionObjects = new List<ConsumptionObjectModel>();
        }

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
        public CompanyModel Company { get; set; }

        /// <summary>
        /// Возвращает или задает список объектов потребления
        /// </summary>
        public IList<ConsumptionObjectModel> ConsumptionObjects { get; set; }
    }
}
