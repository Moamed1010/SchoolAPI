﻿using AutoMapper;

namespace School.Core.Mapping.Students
{

    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIDMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
