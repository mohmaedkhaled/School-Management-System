using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
        public DateTime? Period { get; set; }


        // relation with StudentSubject table one to many
        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }



        // relation with DepartmetSubject table one to many
        [InverseProperty("Subject")]
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }


        // relation with Ins_Subject table one to many
        [InverseProperty("subject")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
