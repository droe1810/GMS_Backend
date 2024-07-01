using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
