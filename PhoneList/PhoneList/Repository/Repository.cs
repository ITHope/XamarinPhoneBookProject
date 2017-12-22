using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Repository : IRepository
    {
        public User Get(int id)
        {
            var user = UsersList.GetUser(id);
            return user;
        }
    }
}
