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
    public class ArtifactService : IArtifactService
    {
        private readonly IRepository<Artifact> _repository;

        public ArtifactService(IRepository<Artifact> repository)
        {
            _repository = repository;
        }

        public Artifact DeleteById(Guid id)
        {
            var entity = GetById(id);
            if(entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return _repository.Delete(entity);
        }

        public List<Artifact> GetAll()
        {
            return _repository.GetAll(selector: x => x).ToList();
        }

        public Artifact? GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                                   predicate: x => x.Id == id);
        }

        public Artifact Insert(Artifact artifact)
        {
            return _repository.Insert(artifact);
        }

        public Artifact Update(Artifact artifact)
        {
            return _repository.Update(artifact);
        }
    }
}
