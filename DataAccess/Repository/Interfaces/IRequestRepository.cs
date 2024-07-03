using BussinessObject.DTO.Request;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IRequestRepository
    {
        ResultForCreateRequestDTO CreateRequest(int studentId, int gradeId, string requestContent);

 
        List<GetRequestDTO> GetAllRequest();
        List<GetRequestDTO> GetRequest(int studentId);
        ResultForUpdateRequestDTO UpdateRequest(int requestId, int newGrade);
    }
}
