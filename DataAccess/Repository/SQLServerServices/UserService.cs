using AutoMapper;
using BussinessObject.DTO.User;
using BussinessObject.Models;
using DataAccess.DataAccess;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.SQLServerServices
{
    public class UserService : IUserRepository
    {

        private readonly prn231Context _context;
        private readonly IMapper _mapper;

        public UserService(prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public List<User> GetAllUsers()
        //{
        //    List<User> result = _context.Users.ToList();
        //    return result;
        //}

        //public List<GetUserDTO> GetStudentByGradeId(int gradeId)
        //{
        //    List<int> listStudentId = _context.StudentGrades.Where(sg => sg.GradeId == gradeId).Select(sg => sg.StudentId).ToList();

        //    List<User> listStudent = _context.Users.Where(u => listStudentId.Contains(u.Id)).ToList();

        //    List<GetUserDTO> listStudentDTO = _mapper.Map<List<GetUserDTO>>(listStudent);

        //    return listStudentDTO;
        //}

        public List<GetUserDTO> GetStudentByCourseId(int courseId)
        {
            List<int> listSessionId = _context.Sessions.Where(ss => ss.CourseId == courseId).Select(ss => ss.Id).ToList();

            List<int> listStudentId = _context.SessionStudents.Where(ssst => listSessionId.Contains(ssst.SessionId)).Select(ssst => ssst.StudentId).ToList();

            List<User> listStudent = _context.Users.Where(u => listStudentId.Contains(u.Id)).ToList();

            List<GetUserDTO> listStudentDTO = _mapper.Map<List<GetUserDTO>>(listStudent);

            return listStudentDTO;
        }

        public List<GetUserDTO> GetStudentInSession(int sessionId)
        {
            List<int> listStudentId = _context.SessionStudents.Where(ss => ss.SessionId == sessionId).Select(ss => ss.StudentId).ToList();
            List<User> listStudent = _context.Users.Where(u => listStudentId.Contains(u.Id)).ToList();

            List<GetUserDTO> listStudentDTO = _mapper.Map<List<GetUserDTO>>(listStudent);

            return listStudentDTO;
        }

        public GetUserDTO GetStudent(string username)
        {
            User u = _context.Users.FirstOrDefault(u => u.Username == username && u.RoleId == 4);
            GetUserDTO uDTO = _mapper.Map<GetUserDTO>(u);
            if (u == null)
            {
                return null;
            }
            return uDTO;
        }

        public GetUserDTO GetUser(string username, string password)
        {
            User u = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            GetUserDTO uDTO = _mapper.Map<GetUserDTO>(u);
            if(u == null)
            {
                return null;
            }
            return uDTO;
        }

        public AccountBalanceDTO Recharge(int studentId, int value)
        {
            User u = _context.Users.FirstOrDefault(u => u.Id == studentId);
            if (u == null)
            {
                return null;
            }
            AccountBalanceDTO data = new AccountBalanceDTO();
            data.StudentId = u.Id;
            data.Username = u.Username;
            data.Action = "Recharge";
            data.OldAccountBalance = u.AccountBalance;

            u.AccountBalance += value;
            if (_context.SaveChanges() == 1)
            {
                data.isSuccess = true;
                data.NewAccountBalance = u.AccountBalance;
            }
            
            return data;
        }
        public AccountBalanceDTO Refund(int studentId)
        {
            User u = _context.Users.FirstOrDefault(u => u.Id == studentId);
            if (u == null)
            {
                return null;
            }
            AccountBalanceDTO data = new AccountBalanceDTO();
            data.StudentId = u.Id;
            data.Username = u.Username;
            data.Action = "Refund";
            data.OldAccountBalance = u.AccountBalance;

            u.AccountBalance += 200000;

            if (_context.SaveChanges() == 1)
            {
                data.isSuccess = true;
                data.NewAccountBalance = u.AccountBalance;
            }
            return data;
        }

        public AccountBalanceDTO DeductFunds(int studentId)
        {
            User u = _context.Users.FirstOrDefault(u => u.Id == studentId);
            if (u == null)
            {
                return null;
            }

            AccountBalanceDTO data = new AccountBalanceDTO();
            data.StudentId = u.Id;
            data.Username = u.Username;
            data.Action = "DeductFunds";
            data.OldAccountBalance = u.AccountBalance;

            if (u.AccountBalance < 200000)
            {
                data.isSuccess = false;
                data.NewAccountBalance = u.AccountBalance;
                return data;
            }
            u.AccountBalance -= 200000;

            if (_context.SaveChanges() == 1)
            {
                data.isSuccess = true;
                data.NewAccountBalance = u.AccountBalance;
            }
            return data;
        }
    }
}
