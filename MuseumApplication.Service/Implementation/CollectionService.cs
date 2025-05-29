using MuseumApplication.Domain.DomainModels;
using MuseumApplication.Repository.Implementation;
using MuseumApplication.Repository.Interface;
using MuseumApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumApplication.Service.Implementation
{
    public class CollectionService : ICollectionService
    {
        private readonly IRepository<Collection> _repository;

        public CollectionService(IRepository<Collection> repository)
        {
            _repository = repository;
        }

        public Collection DeleteById(Guid id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return _repository.Delete(entity);
        }

        public List<Collection> GetAll()
        {
            return _repository.GetAll(selector: x => x).ToList();
        }

        public Collection? GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                       predicate: x => x.Id == id);
        }

        public Collection Insert(Collection collection)
        {
            return _repository.Insert(collection);
        }

        public Collection Update(Collection collection)
        {
            return _repository.Update(collection);
        }
    }
}
