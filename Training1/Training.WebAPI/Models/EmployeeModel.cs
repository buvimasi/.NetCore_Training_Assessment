namespace Training.WebAPI.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Wfm_Manager { get; set; }
        public string Email { get; set; }
        public string LockStatus { get; set; }
        public decimal Experience { get; set; }
        public int ProfileId { get; set; }
    }
}
