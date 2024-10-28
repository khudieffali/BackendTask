using BackendTask.Entities;
using BackendTask.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BackendTask.Services.Concretes
{
    public class UserRepository(DbContext context) : Repository<User>(context), IUserRepository
    {
    }
}
