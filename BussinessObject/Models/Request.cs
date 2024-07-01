using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? GradeId { get; set; }
        public string? RequestContent { get; set; }
        public string? ResponeContent { get; set; }
        public int? NewGradeValue { get; set; }
        public int? RequestStatusId { get; set; }
        public virtual Grade? Grade { get; set; }
        public virtual RequestStatus? RequestStatus { get; set; }
        public virtual User? Student { get; set; }
    }
}
