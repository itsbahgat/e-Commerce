using E_Commerce.Areas.Admins.Models;

namespace E_Commerce.Areas.Admins.RepoServices
{
    public interface IAdminRepository
    {
        public List<Admin> GetAll();
        public Admin GetDetailsByID(int id);
        public Admin GetDetailsByName(string name);
        public void Insert(Admin admin);
        public void UpdateAdmin(int id, Admin admin);
        public void DeleteAdmin(int id);
    }
}
