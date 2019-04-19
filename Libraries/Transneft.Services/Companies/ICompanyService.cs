using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Domain.Companies;

namespace Transneft.Services.Companies
{
    /// <summary>
    /// Сервис компаний
    /// </summary>
    public interface ICompanyService
    {
        #region Companies

        /// <summary>
        /// Получить организацию по идентификатору
        /// </summary>
        /// <param name="companyId">Идентификатор организации</param>
        /// <returns>Организация</returns>
        Company GetCompanyById(int companyId);

        /// <summary>
        /// Получить список всех организацию
        /// </summary>
        /// <returns>Список организаций</returns>
        IList<Company> GetCompaniesAll();


        #endregion

        #region Affiliated Companies

        /// <summary>
        /// Получить дочернюю организацию по идентификатору
        /// </summary>
        /// <param name="affiliatedCompanyId">Идентификатор дочерней организации</param>
        /// <returns>Дочерняя организация</returns>
        AffiliatedCompany GetAffiliatedCompanyById(int affiliatedCompanyId);

        /// <summary>
        /// Получить список дочерних организации
        /// </summary>
        /// <param name="companyId">Идентификатор головной организации</param>
        /// <returns>Список дочерних организаций</returns>
        IList<AffiliatedCompany> GetAffiliatedCompanyByCompanyId(int companyId);

        #endregion
    }
}
