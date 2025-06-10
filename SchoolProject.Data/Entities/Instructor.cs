using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subject = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }


        //the two relation with department table (one to many "teach"  &&  one to one ""manage")
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public Department? department { get; set; }

        [InverseProperty("Instructor")]
        public Department? departmentManager { get; set; }


        //relation with instructor table one to many (with yourself)
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Instructors")]
        public Instructor? Supervisor { get; set; }
        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }


        // relation with Ins_Subject table one to many
        [InverseProperty("instructor")]
        public virtual ICollection<Ins_Subject> Ins_Subject { get; set; }


    }
}
