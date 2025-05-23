using School.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public partial class Department : GeniralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }

        public string? DNameAr { get; set; }
        [StringLength(100)]
        public string? DNameEn { get; set; }
        public int? InsManager { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]

        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InsManager))]
        [InverseProperty("departmentManager")]
        public virtual Instructor? Instructor { get; set; }
    }

}
