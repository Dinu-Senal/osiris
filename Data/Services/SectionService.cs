using System;
using System.Threading.Tasks;

namespace Osiris.Data.Services
{
    public class SectionService
    {
        #region Property
        public readonly ApplicationDbContext _applicatonDbContext;
        #endregion

        #region Constructor
        public SectionService(ApplicationDbContext appDbContext)
        {
            _applicatonDbContext = appDbContext;
        }
        #endregion

        #region Update Section
        public async Task<bool> UpdateSectionAsync(Section section)
        {
            _applicatonDbContext.Sections.Update(section);
            await _applicatonDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        //set initial values for sectons in database
    }
}
