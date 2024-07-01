using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTO.Request
{
    public class ResultForCreateRequestDTO
    {
        public bool IsSuccess { get; set; }
        public string? msg { get; set; }    
    }
}
