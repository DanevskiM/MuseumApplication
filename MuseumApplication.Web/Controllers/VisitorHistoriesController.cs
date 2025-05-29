using Microsoft.AspNetCore.Mvc;
using MuseumApplication.Service.Interface;

namespace MuseumApplication.Web.Controllers
{
    public class VisitorHistoriesController : Controller
    {
        private readonly IVisitorHistoryService _visitorHistoryService;

        public VisitorHistoriesController(IVisitorHistoryService visitorHistoryService)
        {
            _visitorHistoryService = visitorHistoryService;
        }

        // GET: VisitorHistories/Details/5
        public IActionResult Details(Guid id)
        {
            var visitorHistories = _visitorHistoryService.GetVisitorHistoryDetails(id);
            if (visitorHistories == null)
                return NotFound();
            return View(visitorHistories);
        }
    }
}
