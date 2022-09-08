using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain.Entities
{
    public class SoftLock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("lockId")]
        public int LockId { get; set; }
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
        public Employees Employees { get; set; }
        [Column("manager")]
        public string Manager { get; set; }
        [Column("reqdate")]
        public DateTime? RequestDate { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("lastupdated")]
        public DateTime? LastUpdated { get; set; }
        [Column("requestmessage")]
        public string RequestMessage { get; set; }
        [Column("wfmremark")]
        public string Wfmremark { get; set; }
        [Column("managerstatus")]
        public string ManagerStatus { get; set; }
        [Column("mgrstatuscomment")]
        public string MgrStatuscomment { get; set; }
        [Column("mgrlastupdate")]
        public string MgrLastupdate { get; set; }
        
    }
}
