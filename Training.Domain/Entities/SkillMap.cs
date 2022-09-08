using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain.Entities
{
    public class SkillMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
        public Employees Employees { get; set; }
        [Column("skillId")]
        public int SkillId { get; set; }
        public Skills Skills { get; set; }
    }
}
