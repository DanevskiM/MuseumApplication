using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumApplication.Domain.DomainModels
{
    public class VisitorInHistory : BaseEntity
    {
        public virtual VisitorHistory VisitorHistory { get; set; }
        public Guid visitorHistoryId { get; set; }
        public virtual Visit Visit { get; set; }
        public Guid visitId { get; set; }
        public int Quantity { get; set; }
    }
}
