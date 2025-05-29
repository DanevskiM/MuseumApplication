using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuseumApplication.Domain.DomainModels;
using MuseumApplication.Repository.Data;
using MuseumApplication.Service.Interface;

namespace MuseumApplication.Web.Controllers
{
    public class VisitsController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly IArtifactService _artifactService;

        public VisitsController(IVisitService visitorService, IArtifactService artifactService)
        {
            _visitService = visitorService;
            _artifactService = artifactService;
        }

        // GET: Visits
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_visitService.GetAllByCurrentUser(userId));
        }

        // GET: Visits/Create
        public IActionResult Create(Guid visitorId)
        {
            ViewData["VisitorId"] = visitorId;
            ViewData["ArtifactId"] = new SelectList(_artifactService.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // TODO: Bind the form from the view to this POST action in order to create the Visit
        // Implement the IVisitService and use it here to create the visit
        // After successful creation, the user should be redirected to Index page of Visitors

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,VisitorId,ArtifactId,DateVisited")] Visit visit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _visitService.AddVisitForVisitorAndArtifact(visit.VisitorId, visit.ArtifactId, userId);
            return RedirectToAction(nameof(Index));
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            // TODO: Implement method
            throw new NotImplementedException();
        }

        // POST: Visits/CreateTransferRequest
        [HttpGet, ActionName("CreateVisitorHistory")]
        [Authorize]
        public IActionResult CreateVisitorHistory()
        {
            // TODO: Implement method
            // Find current user, call service method, redirect to details in TransferRequests controller
            throw new NotImplementedException();
        }
    }
}
