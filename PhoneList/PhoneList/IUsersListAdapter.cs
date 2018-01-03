using System.Collections.Generic;

namespace PhoneList
{
    public interface IUsersListAdapter
    {
        void UpdateUsersList(List<User> usersList);
    }
}
