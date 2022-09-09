using Training.Domain.Data;
using Training.Domain.Entities;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Services
{
    public class SkillLockService : ISoftLockService
    {
        private readonly EmployeeDbContext _dbContext;

        public SkillLockService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddSoftLock(SoftLockModel softLockModel)
        {
            if(softLockModel != null)
            {
                _dbContext.Add(new SoftLock
                {
                    Status = softLockModel.Status,
                    LastUpdated = softLockModel.LastUpdated,
                    MgrLastupdate = softLockModel.MgrLastupdate,
                    EmployeeId = softLockModel.EmployeeId,
                    Manager = softLockModel.Manager,
                    ManagerStatus = softLockModel.ManagerStatus,
                    RequestDate = softLockModel.RequestDate,
                    RequestMessage = softLockModel.RequestMessage,
                });
                _dbContext.SaveChanges();
                return "SoftLock Added successfully";

            }
            else
            {
                return "No Data found";
            }
        }

        public string DeleteSoftLock(int id)
        {
            var softLock = _dbContext.SoftLocks.FirstOrDefault(s => s.LockId == id);
            if(softLock != null)
            {
                _dbContext.Remove(softLock);
                _dbContext.SaveChanges();
                return "Deleted successfully";
            }
            else
            {
                return "SoftLock not found";
            }

        }

        public SoftLock GetSoftLock(int id)
        {
            var softLock = _dbContext.SoftLocks.FirstOrDefault(s => s.LockId == id);
            if(softLock != null)
            {
                return softLock;
            }
            else
            {
                return new SoftLock();
            }
        }

        public List<SoftLock> GetSoftLockByEmployeeId(int employeeId)
        {
            var softlock = _dbContext.SoftLocks.Where(s => s.EmployeeId == employeeId).ToList();
            if(softlock.Count > 0)
            {
                return softlock;
            }
            else
            {
                return new List<SoftLock>();
            }
  
        }

        public List<SoftLock> GetSoftLocks()
        {
            return _dbContext.SoftLocks.ToList();
        }

        public string UpdateSoftLock(int id, SoftLockModel softLockModel)
        {
            var softLock = _dbContext.SoftLocks.FirstOrDefault(s => s.LockId == id);
            if( softLock != null )
            {
                softLock.MgrLastupdate = softLockModel.MgrLastupdate;
                softLock.EmployeeId = softLockModel.EmployeeId;
                softLock.Status = softLockModel.Status;
                softLock.ManagerStatus = softLockModel.ManagerStatus;
                softLock.Manager = softLockModel.Manager;
                softLock.MgrStatuscomment = softLockModel.MgrStatuscomment;
                softLock.LastUpdated = softLockModel.LastUpdated;
                softLock.RequestDate = softLockModel.RequestDate;
                softLock.RequestMessage = softLockModel.RequestMessage;
                _dbContext.Update(softLock);
                _dbContext.SaveChanges();

                return "Softlock updated successfully";
            }
            else
            {
                return "Softlock not found";
            }

        }
    }
}
