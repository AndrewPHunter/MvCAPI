using System.Collections.Generic;
using System.Linq;

namespace DbService
{
    public interface IMyFakeDbService
    {
        IQueryable<ApprovedUser> ApprovedUsers { get; }

        int RemoveUser(ApprovedUser user);

        int RemoveUser(string email);

        bool UserExists(ApprovedUser user);

        void AddUser(ApprovedUser user);
    }
}