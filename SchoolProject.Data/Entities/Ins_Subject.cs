using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }

        // relation with instructor table many to one
        [ForeignKey(nameof(InsId))]
        [InverseProperty("Ins_Subject")]
        public Instructor? instructor { get; set; }


        // relation with subject table many to one
        [ForeignKey(nameof(SubId))]
        [InverseProperty("Ins_Subjects")]
        public Subject? subject { get; set; }
    }
}
