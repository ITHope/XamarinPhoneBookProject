using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Controller
    {
        private IUsersListAdapter _usersListAdapter;
        IRepository _repository;

        public Controller(IUsersListAdapter usersListAdapter, IRepository repository)
        {
            _repository = repository;
            _usersListAdapter = usersListAdapter;
        }
    }
}
