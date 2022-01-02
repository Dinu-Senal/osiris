using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data.Services
{
    public class ProjectService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public ProjectService(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }
        #endregion

        #region Get List of Projects
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _applicationDbContext.Projects.ToListAsync();
        }
        #endregion

        #region Add Projects
        public async Task<bool> AddProjectAsync(Project project)
        {
            await _applicationDbContext.Projects.AddAsync(project);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Project by Id
        public async Task<Project> GetProjectAsync(String Id)
        {
            Project project = await _applicationDbContext.Projects.FirstOrDefaultAsync(data => data.ProjectId.ToString() == Id);
            return project;
        }
        #endregion

        #region Update Project
        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _applicationDbContext.Projects.Update(project);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Project
        public async Task<bool> DeleteProjectAsync(Project project)
        {
            _applicationDbContext.Remove(project);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Filter Projects
        public async Task<List<Project>> FilterProject(String projectFilter)
        {
            var castedProjectList = _applicationDbContext.Projects.AsEnumerable();
            var FitleredProjectList = castedProjectList.Where(data => data.Status.ToLower().Equals(projectFilter.ToLower())).ToList();
            return FitleredProjectList;
        }
        #endregion

        #region Filter Project by End Date & Start Date
        public async Task<List<Project>> FilterProjectByDates(DateTime startDate, DateTime endDate)
        {
            var castedProjectList = _applicationDbContext.Projects.AsEnumerable();
            var FitleredProjectListByDates = castedProjectList.Where(data => data.StartDate >= startDate && data.EndDate <= endDate).ToList();
            return FitleredProjectListByDates;
        }
        #endregion
    }
}
