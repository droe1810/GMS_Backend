using BussinessObject.DTO.GradeType;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGradeTypeRepository
    {
        List<GetGradeTypeDTO> GetAllGradeType();
        bool CreateGradeType(CreateGradeTypeDTO gtDTO);
    }
}
