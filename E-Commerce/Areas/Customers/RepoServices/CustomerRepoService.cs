using E_Commerce.Areas.Identity.Data;
using E_Commerce.Models;
using Stripe;

namespace E_Commerce.Areas.Customers.RepoServices
{
    public class CustomerRepoService : ICustomerRepository
    {
        private readonly IdentityContext context;
        private readonly List<E_CommerceUser> users;

        public CustomerRepoService(IdentityContext context)
        {
            this.context = context;
            //users = (from role in context.Roles
            //         join userRole in context.UserRoles on role.Id equals userRole.RoleId
            //         join user in context.Users on userRole.UserId equals user.Id
            //         where role.Name.ToLower() == "user"
            //         select user).ToList() ;
            users = (from user in context.Users
                     join userRole in context.UserRoles on user.Id equals userRole.UserId
                     join role in context.Roles on userRole.RoleId equals role.Id
                     where role.Name.ToLower() == "user"
                     select user).ToList() ;
        }
        public void Insert(E_CommerceUser customer)
        {
            context.Users.Add(customer);
            context.SaveChanges();
        }

        public void UpdateCustomer(string id, E_CommerceUser customer)
        {
            var updatedCustomer = context.Users.Find(id);
            if (updatedCustomer == null)
                return;
            updatedCustomer.Address = customer.Address;
            updatedCustomer.FirstName = customer.FirstName;
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.PhoneNumber = customer.PhoneNumber;
            context.SaveChanges();
        }

        List<E_CommerceUser> ICustomerRepository.GetAll()
        {
            return users;
        }

        E_CommerceUser ICustomerRepository.GetDetailsByID(string id)
        {
            var customer = users.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return new E_CommerceUser();
            return customer;
        }
    }
}
