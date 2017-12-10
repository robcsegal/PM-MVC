using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PMMVC.DAL.Repositories
{
    public class ProjectRepository : Interfaces.IProjectRepository
    {
        #region private variables

        private Data.ProjectManagement.ProjectManagementContext m_projectManagement;

        #endregion
        
        #region public functions/methods

        /// <summary>
        /// Instantiates repository object class.
        /// </summary>
        public void Instantiate()
        {
            m_projectManagement = new Data.ProjectManagement.ProjectManagementContext();
        }

        /// <summary>
        /// Get project entity from database data object.
        /// </summary>
        /// <param name="project">Project database data object</param>
        /// <returns>Project entity</returns>
        public Entities.Project GetEntityFromData(Data.ProjectManagement.Project project)
        {
            if (project != null)
            {
                return new Entities.Project()
                {
                    ID = project.ProjectId,
                    Description = project.Description,
                    Active = project.Active,
                    CreatedDate = project.CreatedDate
                };
            }
            else
            {
                return new Entities.Project();
            }
        }
        
        /// <summary>
        /// Get Project entity by its id.
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Project Entity</returns>
        public Entities.Project Get(int id)
        {
            Entities.Project retProject = new Entities.Project();

            try
            {
                retProject = (from proj in m_projectManagement.Project
                              where proj.ProjectId == id
                              select GetEntityFromData(proj)).FirstOrDefault();

                return retProject;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<Entities.Project> GetAll(bool activeOnly)
        {
            List<Entities.Project> retProjects = new List<Entities.Project>();

            try
            {
                retProjects = (from projs in m_projectManagement.Project
                               where !activeOnly || (activeOnly && projs.Active)
                               select GetEntityFromData(projs)).ToList();

                return retProjects;
            }
            catch(Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
