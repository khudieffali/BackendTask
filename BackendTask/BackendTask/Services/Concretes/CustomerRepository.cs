using BackendTask.Entities;
using BackendTask.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendTask.Services.Concretes
{
    public class CustomerRepository(DbContext context) : Repository<Customer>(context), ICustomerRepository
    {
     
    }
}
