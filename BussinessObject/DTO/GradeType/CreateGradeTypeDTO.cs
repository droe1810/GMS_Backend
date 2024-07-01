using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.GradeType
{
    public class CreateGradeTypeDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int? PassConditionId { get; set; }
        public int? ComparasionTypeId { get; set; }
        public int? GradeValue { get; set; }
        public int GradedByRole { get; set; }


    }
}
