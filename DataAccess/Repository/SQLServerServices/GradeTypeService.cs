using AutoMapper;
using BussinessObject.DTO.GradeType;
using BussinessObject.Models;
using DataAccess.DataAccess;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.SQLServerServices
{
    public class GradeTypeService : IGradeTypeRepository
    {
        private readonly prn231Context _context;
        private readonly IMapper _mapper;

        public GradeTypeService(prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateGradeType(CreateGradeTypeDTO gtDTO)
        {
            GradeType gt = _mapper.Map<GradeType>(gtDTO);
            gt.PassCondition = null;
            _context.GradeTypes.Add(gt);
            return _context.SaveChanges() == 1;
        }

        public List<GetGradeTypeDTO> GetAllGradeType()
        {
            List<GradeType> result = _context.GradeTypes.ToList();
            List<GetGradeTypeDTO> resultDTO = _mapper.Map<List<GetGradeTypeDTO>>(result);
            return resultDTO;
        }
    }
}
