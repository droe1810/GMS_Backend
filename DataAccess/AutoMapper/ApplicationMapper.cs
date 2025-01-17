﻿using AutoMapper;
using BussinessObject.DTO.ComparisonType;
using BussinessObject.DTO.Course;
using BussinessObject.DTO.Grade;
using BussinessObject.DTO.GradeType;
using BussinessObject.DTO.Request;
using BussinessObject.DTO.Role;
using BussinessObject.DTO.Session;
using BussinessObject.DTO.StudentGrade;
using BussinessObject.DTO.User;
using BussinessObject.Models;
using DataAccess.Repository.Interfaces;
using DataAccess.Repository.SQLServerServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {

            CreateMap<GradeType, CreateGradeTypeDTO>()
               .ForMember(dest => dest.ComparasionTypeId, otp => otp.MapFrom(src => src.PassCondition.ComparisonTypeId))
               .ForMember(dest => dest.GradeValue, otp => otp.MapFrom(src => src.PassCondition.GradeValue))
               .ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<ComparisonType, ComparisonTypeDTO>().ReverseMap();

            CreateMap<GradeType, GetGradeTypeDTO>()
                .ForMember(desc => desc.GradedByRoleId, otp => otp.MapFrom(src => src.GradedByRole))
                .ForMember(desc => desc.GradedByRoleName, otp => otp.MapFrom(src => src.GradedByRoleNavigation.RoleName))
                .ForMember(desc => desc.ComparisonType, otp => otp.MapFrom(src => src.PassCondition.ComparisonType.Name))
                .ForMember(desc => desc.ComparisonValue, otp => otp.MapFrom(src => src.PassCondition.GradeValue))
                
                .ReverseMap();

            CreateMap<Course, CourseDTO>().ReverseMap();

          //  CreateMap<Grade, CreateGradeDTO>().ReverseMap();

            CreateMap<Session, GetSessionDTO>()
                .ForMember(desc => desc.CourseName, otp => otp.MapFrom(src => src.Course.Code))
                .ForMember(desc => desc.ClassName, otp => otp.MapFrom(src => src.Class.Name))
                .ForMember(desc => desc.TeacherName, otp => otp.MapFrom(src => src.Teahcer.Username))
                .ReverseMap();

            CreateMap<User, GetUserDTO>().ReverseMap();

            CreateMap<Grade, GetGradeDTO>()
                .ForMember(desc => desc.GradeTypeName, otp => otp.MapFrom(src => src.GradeType.Name))
                .ForMember(desc => desc.CourseName, otp => otp.MapFrom(src => src.Course.Code))
                .ReverseMap();

            //CreateMap<StudentGrade, GradeDTO>()
            //    .ForMember(desc => desc.GradeId, otp => otp.MapFrom(src => src.Grade.Id))
            //    .ForMember(desc => desc.GradeName, otp => otp.MapFrom(src => src.Grade.Name))
            //    .ForMember(desc => desc.Weight, otp => otp.MapFrom(src => src.Grade.Weight))
            //    .ReverseMap();

            CreateMap<Grade, GradeDTO>()
                .ForMember(dest => dest.GradeId, otp => otp.MapFrom(src => src.Id))
                .ForMember(dest => dest.GradeName, otp => otp.MapFrom(src => src.Name))
                .ForMember(dest => dest.Weight, otp => otp.MapFrom(src => src.Weight))
                .ReverseMap();

            CreateMap<GradeType, GradeTypeDTO>()
                .ForMember(desc => desc.GradeTypeId, otp => otp.MapFrom(src => src.Id))
                .ForMember(desc => desc.GradeTypeName, otp => otp.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<StudentViewGradeDTO, StudentViewGradeDTO>()
                .ReverseMap();

            CreateMap<Request, GetRequestDTO>()
                .ForMember(desc => desc.RequestId, otp => otp.MapFrom(src => src.Id))
                .ForMember(desc => desc.StudentName, otp => otp.MapFrom(src => src.Student.Username))
                .ForMember(desc => desc.GradeName, otp => otp.MapFrom(src => src.Grade.Name))
                .ForMember(desc => desc.CourseId, otp => otp.MapFrom(src => src.Grade.CourseId))
                .ForMember(desc => desc.CourseCode, otp => otp.MapFrom(src => src.Grade.Course.Code))
                .ForMember(desc => desc.StatusName, otp => otp.MapFrom(src => src.RequestStatus.Name))
                .ReverseMap();
        }
    }
}
