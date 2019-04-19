using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Web.Framework.Models;

namespace Transneft.Web.Models.Companies
{
    /// <summary>
    /// Модель организации
    /// </summary>
    public class CompanyModel : ModelBase
    {
        public CompanyModel()
        {
            AffiliatedCompanies = new List<AffiliatedCompanyModel>();
        }

        /// <summary>
        /// Возвращает или задает наименование организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает адрес организации
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Возвращает или задает список дочерних организаций
        /// </summary>
        public IList<AffiliatedCompanyModel> AffiliatedCompanies { get; set; }
    }
}
