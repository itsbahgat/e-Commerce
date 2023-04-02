using E_Commerce.Areas.Identity.Data;

namespace E_Commerce.Areas.Customers.RepoServices
{
    public interface ICustomerRepository
    {
        public List<E_CommerceUser> GetAll();
        public E_CommerceUser GetDetailsByID(string id);
        public void Insert(E_CommerceUser customer);
        public void UpdateCustomer(string id, E_CommerceUser customer);

    }
}
