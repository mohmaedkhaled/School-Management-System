using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public partial class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        public int DID { get; set; }
        [StringLength(100)]
        public string DNameAr { get; set; }
        [StringLength(100)]
        public string DNameEn { get; set; }

        public int InsManager { get; set; }


        // relation with student table one to many
        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }


        //relation with dept_subject table one to many (realtion many to many with subject table)
        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }


        //the two relation with department table (one to many "teach"  &&  one to one ""manage")
        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey("InsManager")]
        [InverseProperty("departmentManager")]
        public virtual Instructor Instructor { get; set; }
    }
}
