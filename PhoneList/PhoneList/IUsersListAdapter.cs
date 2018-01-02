using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList
{
    public interface IUsersListAdapter
    {
        void UpdateUsersList(List<User> usersList);
    }
}
