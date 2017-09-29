using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMMVC.Web.Models;
using PMMVC.DAL;

namespace PMMVC.Web.Controllers
{
    public class ProjectController : Controller
    {
        #region private variables

        private DAL.Repositories.Interfaces.IProjectRepository m_repoProject;

        #endregion

        #region constructor

        public ProjectController(DAL.Repositories.Interfaces.IProjectRepository repoProject)
        {
            m_repoProject = repoProject;

            m_repoProject.Instantiate();
        }

        #endregion

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            Models.ProjectViewModel vmProject = new ProjectViewModel();
            DAL.Entities.Project project = new DAL.Entities.Project();

            try
            {
                project = m_repoProject.Get(id);

                if (project != null)
                {
                    vmProject = new ProjectViewModel()
                    {
                        ID = project.ID,
                        Description = project.Description,
                        Active = project.Active,
                        CreatedDate = project.CreatedDate
                    };
                }

                return View(vmProject);
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}