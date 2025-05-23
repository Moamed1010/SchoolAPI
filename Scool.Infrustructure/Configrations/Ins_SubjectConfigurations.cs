﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace Shcool.Infrustructure.Configrations
{
    public class Ins_SubjectConfigurations : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder
                .HasKey(x => new { x.SubID, x.InsId });


            builder.HasOne(ds => ds.Instructor)
                     .WithMany(d => d.Ins_Subjects)
                     .HasForeignKey(ds => ds.InsId);

            builder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.InsSubjects)
                 .HasForeignKey(ds => ds.SubID);

        }
    }
}
