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
    public class VisitService : IVisitService
    {
        private readonly IRepository<Visit> _repository;

        public VisitService(IRepository<Visit> repository)
        {
            _repository = repository;
        }

        public Visit AddVisitForVisitorAndArtifact(Guid visitorId, Guid artifactId, string userId)
        {
            var visit = new Visit()
            {
                VisitorId = visitorId,
                ArtifactId = artifactId,
                DateVisited = DateTime.Now,
                UserId = userId
            };

            return _repository.Insert(visit);
        }

        public Visit DeleteById(Guid id)
        {
            // TODO: Implement method
            throw new NotImplementedException();
        }

        public List<Visit> GetAll()
        {
            return _repository.GetAll(selector: x => x).ToList();
        }

        public List<Visit> GetAllByCurrentUser(string userId)
        {
            return _repository.GetAll(selector: x => x,
                                      predicate: x => x.UserId == userId,
                                      include: x => x.Include(y => y.Visitor).Include(y => y.Artifact).Include(x => x.User)).ToList();
        }

        public Visit? GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                                   predicate: x => x.Id == id);
        }
    }
}
