using MuseumApplication.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumApplication.Domain.DomainModels
{
    public class VisitorHistory : BaseEntity
    {
        public string UserId { get; set; }
        public DateTime DateCreation { get; set; }
        public MuseumApplicationUser User { get; set; }
        public virtual ICollection<VisitorInHistory> VisitorInHistories { get; set; }
    }
}
