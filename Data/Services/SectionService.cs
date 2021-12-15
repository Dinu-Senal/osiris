using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data.Services
{
    public class SectionService
    {
        #region Property
        public readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public SectionService(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }
        #endregion

        #region Get List of Sections
        public async Task<List<Section>> GetAllSectionsAsync()
        {
            return await _applicationDbContext.Sections.ToListAsync();
        }
        #endregion

        #region Add Section
        public async Task<bool> AddSectionAsync(Section section)
        {
            await _applicationDbContext.Sections.AddAsync(section);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Update Section
        public async Task<bool> UpdateSectionAsync(Section section)
        {
            _applicationDbContext.Sections.Update(section);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Section
        public async Task<bool> DeleteSectionAsync(Section section)
        {
            _applicationDbContext.Remove(section);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Section by Id
        public async Task<bool> DeleteSectionByIdAsync(Guid sectionId)
        {
            var Section = _applicationDbContext.Sections.FirstOrDefault(data => data.SectionId == sectionId);
            if (Section != null)
            {
                _applicationDbContext.Remove(Section);
                await _applicationDbContext.SaveChangesAsync();
            }
            return true;
        }
        #endregion
    }
}
