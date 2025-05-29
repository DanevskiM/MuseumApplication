using Microsoft.EntityFrameworkCore;
using MuseumApplication.Domain.DomainModels;
using MuseumApplication.Repository.Interface;
using MuseumApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumApplication.Service.Implementation
{
    public class VisitorHistoryService : IVisitorHistoryService
    {
        public IRepository<VisitorHistory> _visitorHistoryRepository;
        public IRepository<Visitor> _visitorRepository;
        public IRepository<Visit> _visitRepository;

        public VisitorHistoryService(IRepository<VisitorHistory> visitorHistoryRepository, IRepository<Visitor> visitorRepository, IRepository<Visit> visitRepository)
        {
            _visitorHistoryRepository = visitorHistoryRepository;
            _visitorRepository = visitorRepository;
            _visitRepository = visitRepository;
        }

        public VisitorHistory CreateVisitorHistory(string visitorId)
        {
            var visitor = _visitorRepository.Get(
                selector: x => x,
                predicate: x => x.Id == Guid.Parse(visitorId));
            var newVisit = new Visit
            {
                Id = Guid.NewGuid(),
                DateVisited = DateTime.UtcNow,
                UserId=visitorId
            };
            _visitRepository.Insert(newVisit);
            var visitorHistory = new VisitorHistory
            {
                Id = Guid.NewGuid(),
                DateCreation=DateTime.UtcNow,
                UserId=visitorId,
                VisitorInHistories=new List<VisitorInHistory>()
            };
            _visitorHistoryRepository.Insert(visitorHistory);
            return visitorHistory;
        }

        public VisitorHistory GetVisitorHistoryDetails(Guid id)
        {
            var visitorHistory = _visitorHistoryRepository.Get(
                selector: x => x,
                predicate: x => x.Id == id,
                include: x => x
                .Include(vh => vh.VisitorInHistories)
                .ThenInclude(vih => vih.Visit));
            if (visitorHistory == null)
            {
                throw new Exception("Visit history not found");
            }
            return visitorHistory;
        }
    }
}
