using AutoMapper;
using BussinessObject.DTO.User;
using BussinessObject.Models;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.File
{
    public class UserFromFileManager : IUserRepository
    {
        public List<User> listUser { get; set; }

        private readonly IMapper _mapper;



        public UserFromFileManager(IMapper mapper)
        {
            _mapper = mapper;

            listUser = new List<User>()
            {
                new User(1, "student1formfile", "12345", 400000, 4),
                new User(2, "student2formfile", "12345", 500000, 4),
                new User(3, "student3formfile", "12345", 600000, 4),
                new User(4, "student4formfile", "12345", 700000, 4),
            };
        }

        public AccountBalanceDTO DeductFunds(int studentId)
        {
            throw new NotImplementedException();
        }

        public GetUserDTO GetStudent(string username)
        {
            throw new NotImplementedException();
        }

        public List<GetUserDTO> GetStudentByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<GetUserDTO> GetStudentInSession(int sessionId)
        {
            throw new NotImplementedException();
        }

        public GetUserDTO GetUser(string username, string password)
        {
            foreach (var user in listUser)
            {
                if (user.Username.ToLower().Equals(username.ToLower())
                    && user.Password.ToLower().Equals(password.ToLower())
                    )
                {
                    GetUserDTO userDTO = _mapper.Map<GetUserDTO>(user);
                    return userDTO;
                }
            }

            return null;
        }

        public AccountBalanceDTO Recharge(int studentId, int value)
        {
            throw new NotImplementedException();
        }

        public AccountBalanceDTO Refund(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
