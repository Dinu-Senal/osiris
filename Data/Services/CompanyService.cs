using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data.Services
{
    public class CompanyService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public CompanyService(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }
        #endregion

        #region Get List of Company
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _applicationDbContext.Companies.ToListAsync();
        }
        #endregion

        #region Add Company
        public async Task<bool> AddCompanyAsync(Company company)
        {
            await _applicationDbContext.Companies.AddAsync(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Company by Id
        public async Task<Company> GetCompanyAsync(String Id)
        {
            Company company = await _applicationDbContext.Companies.FirstOrDefaultAsync(data => data.CompanyId.ToString() == Id);
            return company;
        }
        #endregion

        #region Update Company
        public async Task<bool> UpdateCompanyAsync(Company company)
        {
            _applicationDbContext.Companies.Update(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Company
        public async Task<bool> DeleteCompanyAsync(Company company)
        {
            _applicationDbContext.Remove(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region SearchCompany
        public async Task<List<Company>> SearchCompany(String companyFilter)
        {
            var castedCompanyList = _applicationDbContext.Companies.AsEnumerable();
            var FitleredCompanyList = castedCompanyList.Where(data => data.Name.ToLower().Contains(companyFilter.ToLower())).ToList();
            return FitleredCompanyList;
        }
        #endregion
    }
}
