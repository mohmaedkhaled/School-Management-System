using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public Student()
        {
            StudentSubject = new HashSet<StudentSubject>();
        }
        [Key]
        public int StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DID { get; set; }

        // relation with department table many to one
        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department Department { get; set; }


        // relation eith studentsubject table one to many (realtion many to many with subject table)
        [InverseProperty("Student")]
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }

    }
}
