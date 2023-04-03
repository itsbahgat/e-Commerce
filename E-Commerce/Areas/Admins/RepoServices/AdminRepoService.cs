//using E_Commerce.Areas.Admins.Models;
//using E_Commerce.Models;

//namespace E_Commerce.Areas.Admins.RepoServices
//{
//    public class AdminRepoService: IAdminRepository
//    {
//        private readonly databaseContext context;

//        public AdminRepoService(databaseContext context)
//        {
//            this.context = context;
//        }

//        public void DeleteAdmin(int id)
//        {
//            var admin = context.Admins.Find(id);
//            if (admin == null)
//                return;
//            context.Admins.Remove(admin);
//            context.SaveChanges();
//        }

//        public List<Admin> GetAll()
//        {
//            return context.Admins.ToList();
//        }

//        public Admin GetDetailsByID(int id)
//        {
//            var admin = context.Admins.FirstOrDefault(a => a.Id == id);
//            if (admin == null)
//                return new Admin();
//            return admin;
//        }

//        public Admin GetDetailsByName(string name)
//        {
//            var admin = context.Admins.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
//            if (admin == null)
//                return new Admin();
//            return admin;
//        }

//        public void Insert(Admin admin)
//        {
//            context.Admins.Add(admin);
//            context.SaveChanges();
//        }

//        public void UpdateAdmin(int id, Admin admin)
//        {
//            var updatedAdmin = context.Admins.Find(id);
//            if (updatedAdmin == null)
//                return;
//            updatedAdmin.Phone = admin.Phone;
//            updatedAdmin.Email = admin.Email;
//            context.SaveChanges();
//        }
//    }
//}
