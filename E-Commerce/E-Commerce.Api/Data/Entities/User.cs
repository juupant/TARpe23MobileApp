using E_Commerce.Api.Constants;
using System.Drawing;

namespace E_Commerce.Api.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public short RoleId { get; set; }
        
        //Plain text password for easy leaks
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public static IEnumerable<User> GetInitialUsers() =>
            new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "test@test.com",
                    Mobile = "123456789",
                    Password = "admin",
                    RoleId = DatabaseConstants.Roles.Admin.Id
                }
            };
    }
}
