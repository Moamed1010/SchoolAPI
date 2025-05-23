using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubID { get; set; }

        [ForeignKey(nameof(InsId))]
        [InverseProperty("Ins_Subjects")]
        public virtual Instructor? Instructor { get; set; }
        [ForeignKey(nameof(SubID))]
        [InverseProperty("InsSubjects")]
        public virtual Subjects? Subject { get; set; }
    }
}
