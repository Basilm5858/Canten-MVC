using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.View_Model;

namespace Canteen_Order_Management_System.Repo.interfaces
{
    public interface IStaff
    {
        List<Staff> GetAllStaff();
        Staff GetById(int id);
        void AddStaff(Staff staff);
        void UpdateStaff(StaffVM staff);
        void DeleteStaff(int id);
    }
}
