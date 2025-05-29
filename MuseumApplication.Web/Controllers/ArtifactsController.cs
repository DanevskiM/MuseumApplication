using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuseumApplication.Domain.DomainModels;
using MuseumApplication.Repository.Data;
using MuseumApplication.Service.Interface;

namespace MuseumApplication.Web.Controllers
{
    public class ArtifactsController : Controller
    {
        private readonly IArtifactService _artifactService;
        private readonly ICollectionService _collectionService;

        public ArtifactsController(IArtifactService artifactService, ICollectionService collectionService)
        {
            _artifactService = artifactService;
            _collectionService = collectionService;
        }

        // GET: Artifacts
        public IActionResult Index()
        {
            return View(_artifactService.GetAll());
        }

        // GET: Artifacts/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = _artifactService.GetById(id.Value);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // GET: Artifacts/Create
        public IActionResult Create()
        {
            ViewData["CollectionId"] = new SelectList(_collectionService.GetAll(), "Id", "Currator");
            return View();
        }

        // POST: Artifacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Origin,Year,Description,CollectionId")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                _artifactService.Insert(artifact);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollectionId"] = new SelectList(_collectionService.GetAll(), "Id", "Currator", artifact.CollectionId);
            return View(artifact);
        }

        // GET: Artifacts/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = _artifactService.GetById(id.Value);
            if (artifact == null)
            {
                return NotFound();
            }
            ViewData["CollectionId"] = new SelectList(_collectionService.GetAll(), "Id", "Currator", artifact.CollectionId);
            return View(artifact);
        }

        // POST: Artifacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Origin,Year,Description,CollectionId")] Artifact artifact)
        {
            if (id != artifact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _artifactService.Update(artifact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtifactExists(artifact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollectionId"] = new SelectList(_collectionService.GetAll(), "Id", "Currator", artifact.CollectionId);
            return View(artifact);
        }

        // GET: Artifacts/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artifact = _artifactService.GetById(id.Value);
            if (artifact == null)
            {
                return NotFound();
            }

            return View(artifact);
        }

        // POST: Artifacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _artifactService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ArtifactExists(Guid id)
        {
            return _artifactService.GetById(id) != null;
        }
    }
}
