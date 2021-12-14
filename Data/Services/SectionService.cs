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
        public readonly ApplicationDbContext _applicationDbContenxt;
        #endregion

        #region Constructor
        public SectionService(ApplicationDbContext appDbContext)
        {
            _applicationDbContenxt = appDbContext;
        }
        #endregion

        #region Get List of Sections
        public async Task<List<Section>> GetAllSectionsAsync()
        {
            return await _applicationDbContenxt.Sections.ToListAsync();
        }
        #endregion

        #region Add Section
        public async Task<bool> AddSectionAsync(Section section)
        {
            await _applicationDbContenxt.Sections.AddAsync(section);
            await _applicationDbContenxt.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Update Section
        public async Task<bool> UpdateSectionAsync(Section section)
        {
            _applicationDbContenxt.Sections.Update(section);
            await _applicationDbContenxt.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Section
        public async Task<bool> DeleteSectionAsync(Section section)
        {
            _applicationDbContenxt.Remove(section);
            await _applicationDbContenxt.SaveChangesAsync();
            return true;
        }
        #endregion

        public async Task<bool> DeleteSectionByIdAsync(Guid sectionId)
        {
            var Section = _applicationDbContenxt.Sections.FirstOrDefault(data => data.SectionId == sectionId);
            if (Section != null)
            {
                _applicationDbContenxt.Remove(Section);
                await _applicationDbContenxt.SaveChangesAsync();
            }
            return true;
        }
    }
}
