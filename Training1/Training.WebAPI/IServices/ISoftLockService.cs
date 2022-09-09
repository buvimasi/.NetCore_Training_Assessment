using Training.Domain.Entities;
using Training.WebAPI.Models;

namespace Training.WebAPI.IServices
{
    public interface ISoftLockService
    {
        List<SoftLock> GetSoftLocks();
        SoftLock GetSoftLock(int id);
        List<SoftLock> GetSoftLockByEmployeeId(int employeeId);
        string AddSoftLock(SoftLockModel softLockModel);
        string UpdateSoftLock(int id,SoftLockModel softLockModel);
        string DeleteSoftLock(int id);
    }
}
