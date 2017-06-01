using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService
{
    public class MyFakeDbService : IMyFakeDbService
    {
        private static readonly List<ApprovedUser> approvedUsers = new List<ApprovedUser>
        {
            new ApprovedUser{Email = "test@example.com", FirstName = "Joe", LastName = "Smith"},
            new ApprovedUser{Email = "example@example.com", FirstName = "Jane", LastName = "Doe"}
        };

        public IQueryable<ApprovedUser> ApprovedUsers => approvedUsers.AsQueryable();

        public int RemoveUser(ApprovedUser user)
        {
            return RemoveUser(user.Email);
        }

        public int RemoveUser(string email)
        {
            return approvedUsers.RemoveAll(u => u.Email == email);
        }

        public bool UserExists(ApprovedUser user)
        {
            return ApprovedUsers.Any(u => u.Email == user.Email);
        }

        public void AddUser(ApprovedUser user)
        {
            approvedUsers.Add(user);
        }
    }
}
