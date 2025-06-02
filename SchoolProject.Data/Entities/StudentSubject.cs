using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }


        // relation with student table many to one 
        [ForeignKey("StudID")]
        [InverseProperty("StudentSubject")]
        public virtual Student Student { get; set; }


        // relation with subject table many to one
        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subject Subject { get; set; }

    }
}
