﻿using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
            SessionStudents = new HashSet<SessionStudent>();
            Sessions = new HashSet<Session>();
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? AccountBalance { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<SessionStudent> SessionStudents { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        public bool isAdmin(int? roleId)
        {
            if (roleId == null || roleId != 1)
            {
                return false;
            }
            else { return true; }
        }

        public bool isKhaoThi(int? roleId)
        {
            if (roleId == null || roleId != 2)
            {
                return false;
            }
            else { return true; }
        }

        public bool isTeacher(int? roleId)
        {
            if (roleId == null || roleId != 3)
            {
                return false;
            }
            else { return true; }
        }

        public bool isStudent(int? roleId)
        {
            if (roleId == null || roleId != 4)
            {
                return false;
            }
            else { return true; }
        }
    }
}
