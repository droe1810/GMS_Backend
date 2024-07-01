using AutoMapper;
using BussinessObject.DTO.Request;
using BussinessObject.Models;
using DataAccess.DataAccess;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.SQLServerServices
{
    public class RequestService : IRequestRepository
    {

        private readonly prn231Context _context;
        private readonly IMapper _mapper;

        public RequestService(prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public ResultForCreateRequestDTO CreateRequest(int studentId, int gradeId, string requestContent)
        {
            ResultForCreateRequestDTO result = new ResultForCreateRequestDTO();
            User student = _context.Users.FirstOrDefault(u => u.Id == studentId);
            if(student == null)
            {
                result.IsSuccess = false;
                return result;
            }
            else if(student.AccountBalance < 200000)
            {
                result.IsSuccess = false;
                result.msg = "Account Balance is not enough";
                return result ;

            }
            else
            {
                Request r = new Request();
                r.StudentId = studentId;
                r.GradeId = gradeId;
                r.RequestContent = requestContent;
                r.RequestStatusId = 1;
                _context.Requests.Add(r);
                result.IsSuccess = _context.SaveChanges() == 1;
                return result;
            }
           
        }

        public List<GetRequestDTO> GetAllRequest()
        {
            List<Request> listR = _context.Requests
                .Include(r => r.Student)
                .Include(r => r.Grade)
                .ThenInclude(g => g.Course)
                .Include (r => r.RequestStatus)
                .OrderBy(r => r.RequestStatusId).ToList();
            List<GetRequestDTO> listRDTO = _mapper.Map<List<GetRequestDTO>>(listR);

            return listRDTO;
        }

        public List<GetRequestDTO> GetRequest(int studentId)
        {
            List<Request> listR = _context.Requests
                 .Include(r => r.Student)
                 .Include(r => r.Grade)
                 .ThenInclude(g => g.Course)
                 .Include(r => r.RequestStatus)
                 .OrderBy(r => r.RequestStatusId)
                 .Where(r => r.StudentId == studentId)
                 .ToList();
            List<GetRequestDTO> listRDTO = _mapper.Map<List<GetRequestDTO>>(listR);

            return listRDTO;
        }

        public bool UpdateRequest(UpdateRequestDTO rDTO)
        {
           Request r = _context.Requests.FirstOrDefault(r => r.Id == rDTO.requestId);
            r.ResponeContent = rDTO.responeContent;
            r.RequestStatusId = rDTO.newStatusId;
            r.NewGradeValue = rDTO.newGradeValue;

            if (rDTO.newStatusId == 3) {
                return _context.SaveChanges() == 1;
            } else if(rDTO.newStatusId == 2) {
                StudentGrade gradeToUpdate = _context.StudentGrades
                    .FirstOrDefault(sg => sg.GradeId == r.GradeId && sg.StudentId == r.StudentId);

                if (gradeToUpdate != null)
                {
                    gradeToUpdate.Value = rDTO.newGradeValue;
                    return _context.SaveChanges() == 2;
                }
            }
            return false;
        }
    }
}
