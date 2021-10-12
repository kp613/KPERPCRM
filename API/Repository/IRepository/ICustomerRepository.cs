using API.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        //Task<Customer> GetCustomerByNameAsync(string casno);

        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);

        //bool ProductExists(string casno);

        Task<bool> SaveAllAsync();
    }
}
