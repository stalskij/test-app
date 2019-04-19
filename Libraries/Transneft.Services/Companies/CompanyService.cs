using System.Collections.Generic;
using Transneft.Core.Data;
using Transneft.Core.Domain.Companies;
using System.Linq;

namespace Transneft.Services.Companies
{
    /// <summary>
    /// Сервис организаций
    /// </summary>
    public class CompanyService : ICompanyService
    {
        #region Fields

        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<AffiliatedCompany> _affiliatedCompanyRepository;

        #endregion

        #region Ctor

        public CompanyService(IRepository<Company> companyRepository,
            IRepository<AffiliatedCompany> affiliatedCompanyRepository)
        {
            _companyRepository = companyRepository;
            _affiliatedCompanyRepository = affiliatedCompanyRepository;
        }

        #endregion

        #region Methods

        #region Companies

        /// <summary>
        /// Получить организацию по идентификатору
        /// </summary>
        /// <param name="companyId">Идентификатор организации</param>
        /// <returns>Организация</returns>
        public Company GetCompanyById(int companyId)
        {
            if (companyId == 0)
                return null;

            return _companyRepository.GetById(companyId);
        }

        /// <summary>
        /// Получить список всех организацию
        /// </summary>
        /// <returns>Список организаций</returns>
        public IList<Company> GetCompaniesAll()
        {
            return _companyRepository.Table.ToList();
        }

        #endregion

        #region Affiliated Companies

        /// <summary>
        /// Получить организацию по идентификатору
        /// </summary>
        /// <param name="affiliatedCompanyId">Идентификатор организации</param>
        /// <returns>Организация</returns>
        public virtual AffiliatedCompany GetAffiliatedCompanyById(int affiliatedCompanyId)
        {
            if (affiliatedCompanyId == 0)
                return null;

            return _affiliatedCompanyRepository.GetById(affiliatedCompanyId);
        }

        /// <summary>
        /// Получить список дочерних организации
        /// </summary>
        /// <param name="companyId">Идентификатор головной организации</param>
        /// <returns>Список дочерних организаций</returns>
        public virtual IList<AffiliatedCompany> GetAffiliatedCompanyByCompanyId(int companyId)
        {
            if (companyId == 0)
                return new List<AffiliatedCompany>();

            return _affiliatedCompanyRepository.Table
                .Where(t => t.CompanyId == companyId)
                .ToList();
        }

        #endregion

        #endregion
    }
}
