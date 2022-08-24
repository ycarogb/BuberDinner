using BuberDinner.Domain.Entities;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(p => p.Email == email);
        }
    }
}
