﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace Shcool.Infrustructure.Configrations
{
    public class StudentSubjectConfigurations : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder
               .HasKey(x => new { x.SubID, x.StudID });


            builder.HasOne(ds => ds.Student)
                     .WithMany(d => d.StudentSubject)
                     .HasForeignKey(ds => ds.StudID);

            builder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.StudentsSubjects)
                 .HasForeignKey(ds => ds.SubID);

        }
    }
}
