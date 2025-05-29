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
    public class VisitorService : IVisitorService
    {
        private readonly IRepository<Visitor> _repository;

        public VisitorService(IRepository<Visitor> repository)
        {
            _repository = repository;
        }

        public Visitor DeleteById(Guid id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return _repository.Delete(entity);
        }

        public List<Visitor> GetAll()
        {
            return _repository.GetAll(selector: x => x).ToList();
        }

        public Visitor? GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                       predicate: x => x.Id == id);
        }

        public Visitor Insert(Visitor visitor)
        {
            return _repository.Insert(visitor);
        }

        public Visitor Update(Visitor visitor)
        {
            return _repository.Update(visitor);
        }
    }
}
