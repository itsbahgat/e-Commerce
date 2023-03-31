using E_Commerce.Areas.Admins.Models;

namespace E_Commerce.Areas.Admins.RepoServices
{
    public interface IAdminRepository
    {
        public List<Admin> GetAll();
        public Admin GetDetails(int id);
        public void Insert(Admin admin);
        public void UpdateCrs(int id, Admin admin);
        public void DeleteCrs(int id);
    }
}
