namespace Training.WebAPI.Models
{
    public class SoftLockModel
    {

        public int LockId { get; set; }
        public int EmployeeId { get; set; }
        public string Manager { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Status { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string RequestMessage { get; set; }
        public string Wfmremark { get; set; }
        public string ManagerStatus { get; set; }
        public string MgrStatuscomment { get; set; }
        public string MgrLastupdate { get; set; }

    }

}
