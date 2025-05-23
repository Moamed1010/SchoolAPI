using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace Shcool.Infrustructure.Configrations
{
    public class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {


            builder.HasKey(x => x.DID);
            builder.Property(x => x.DNameAr).HasMaxLength(100);
            builder.Property(x => x.DNameEn).HasMaxLength(100);

            builder.HasMany(x => x.Students)
                   .WithOne(x => x.Department)
                   .HasForeignKey(x => x.DID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Instructor)
                      .WithOne(x => x.departmentManager)
                      .HasForeignKey<Department>(x => x.InsManager)
                      .OnDelete(DeleteBehavior.Restrict);



        }
    }

}
