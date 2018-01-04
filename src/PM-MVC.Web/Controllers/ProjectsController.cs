using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMMVC.Web.Models;
using PMMVC.DAL;
using Microsoft.AspNetCore.Authorization;

namespace PMMVC.Web.Controllers
{
    public class ProjectsController : Controller
    {
        #region private variables

        private DAL.Repositories.Interfaces.IProjectRepository m_repoProject;

        #endregion

        #region constructor

        public ProjectsController(DAL.Repositories.Interfaces.IProjectRepository repoProject)
        {
            m_repoProject = repoProject;

            m_repoProject.Instantiate();
        }

        #endregion

        // GET: Project
        public ActionResult Index()
        {
            ProjectsViewModel vmProjects = new ProjectsViewModel();

            vmProjects = BuildProjectsViewModel();

            return View(vmProjects);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Projects/GetAllProjects")]
        public JsonResult GetAllProjects()
        {
            ProjectsViewModel vmProjects = new ProjectsViewModel();

            try
            {
                vmProjects.Projects = new List<ProjectViewModel>();

                vmProjects = BuildProjectsViewModel();

                return Json(vmProjects);
            }
            catch(Exception)
            {
                return Json("");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Projects/Add")]
        public JsonResult Add([FromBody] ProjectViewModel project)
        {
            ProjectsViewModel vmProjects = new ProjectsViewModel();
            DateTime transactionDate = DateTime.UtcNow;

            try
            {
                DAL.Entities.Project projectToSave = new DAL.Entities.Project()
                {
                    Description = project.Description,
                    Active = project.Active,
                    CreatedDate = project.CreatedDate
                };

                if (m_repoProject.Save(projectToSave))
                {
                    vmProjects.Projects = new List<ProjectViewModel>();

                    vmProjects = BuildProjectsViewModel();

                    return Json(vmProjects);
                }
                else
                {
                    return Json("");
                }
            }
            catch(Exception)
            {
                return Json("");
            }
        }

        public ProjectsViewModel BuildProjectsViewModel()
        {
            ProjectsViewModel vmProjects = new ProjectsViewModel();
            List<DAL.Entities.Project> listProjects = new List<DAL.Entities.Project>();

            try
            {
                vmProjects.Projects = new List<ProjectViewModel>();

                listProjects = m_repoProject.GetAll(true);

                foreach(DAL.Entities.Project project in listProjects)
                {
                    vmProjects.Projects.Add(new ProjectViewModel()
                    {
                        ID = project.ID,
                        Description = project.Description,
                        Active = project.Active,
                        CreatedDate = project.CreatedDate
                    });
                }

                return vmProjects;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}