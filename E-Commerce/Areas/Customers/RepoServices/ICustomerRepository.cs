using E_Commerce.Areas.Customers.Models;

namespace E_Commerce.Areas.Customers.RepoServices
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public Customer GetDetailsByID(int id);
        public void Insert(Customer customer);
        public void UpdateCustomer(int id, Customer customer);

    }
}
