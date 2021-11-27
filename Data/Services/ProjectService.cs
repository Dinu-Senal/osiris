using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data.Services
{
    public class ProjectService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContenxt;
        #endregion

        #region Constructor
        public ProjectService(ApplicationDbContext appDbContext)
        {
            _applicationDbContenxt = appDbContext;
        }
        #endregion

        #region Get List of Projects
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _applicationDbContenxt.Projects.ToListAsync();
        }
        #endregion

        #region Add Projects
        public async Task<bool> AddProjectAsync(Project project)
        {
            await _applicationDbContenxt.Projects.AddAsync(project);
            await _applicationDbContenxt.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Project by Id
        public async Task<Project> getProjectAsync(int Id)
        {
            Project project = await _applicationDbContenxt.Projects.FirstOrDefaultAsync(data => data.ProjectId.Equals(Id));
            return project;
        }
        #endregion

        #region Update Project
        public async Task<bool> updateProjectAsync(Project project)
        {
            _applicationDbContenxt.Projects.Update(project);
            await _applicationDbContenxt.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Project
        public async Task<bool> deleteProjectAsync(Project project)
        {
            _applicationDbContenxt.Remove(project);
            await _applicationDbContenxt.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
