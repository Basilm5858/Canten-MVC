using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.EntityFrameworkCore;

namespace Canteen_Order_Management_System.Repo.impelementation
{
    public class StaffRepo : IStaff
    {
        private readonly My_AppContext _c;
        public StaffRepo(My_AppContext c)
        {
            _c = c;
        }
        public List<Staff> GetAllStaff()
        {
            return _c.staffs
                .Include(x => x.User)
                .ToList();
        }
        public Staff GetById(int id)
        {
            return _c.staffs
               .Include(x => x.User)
               .FirstOrDefault(x => x.StaffId == id);
        }
        public void AddStaff(Staff staff)
        {
            _c.staffs.Add(staff);
            _c.SaveChanges();
        }
        public void UpdateStaff(StaffVM vm)
        {
            var exi = _c.staffs.Find(vm.StaffId);
            if (exi != null)
            {
                exi.StaffId = vm.StaffId;
                exi.Status = vm.Status;
                exi.UserId = vm.UserId;
                exi.Name = vm.Name;
                exi.Phone = vm.Phone;
                exi.JobTitle = vm.JobTitle;
            }
            _c.SaveChanges();
        }

        public void DeleteStaff(int id)
        {
            var res = _c.staffs.Find(id);
            if (res != null)
            {
                _c.staffs.Remove(res);
                _c.SaveChanges();
            }
        }
    }
}
