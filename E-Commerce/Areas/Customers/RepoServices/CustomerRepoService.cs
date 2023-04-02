using E_Commerce.Areas.Customers.Models;
using E_Commerce.Models;
using Stripe;

namespace E_Commerce.Areas.Customers.RepoServices
{
    public class CustomerRepoService : ICustomerRepository
    {
        private readonly databaseContext context;

        public CustomerRepoService(databaseContext context)
        {
            this.context = context;
        }
        public void Insert(Models.Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void UpdateCustomer(int id, Models.Customer customer)
        {
            var updatedCustomer = context.Customers.Find(id);
            if (updatedCustomer == null)
                return;
            updatedCustomer.Address = customer.Address;
            updatedCustomer.FirstName = customer.FirstName;
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.PhoneNumber = customer.PhoneNumber;
            context.SaveChanges();
        }

        List<Models.Customer> ICustomerRepository.GetAll()
        {
            return context.Customers.ToList();
        }

        Models.Customer ICustomerRepository.GetDetailsByID(int id)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return new Models.Customer();
            return customer;
        }
    }
}
