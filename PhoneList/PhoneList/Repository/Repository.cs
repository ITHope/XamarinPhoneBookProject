using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public class Repository : IRepository
    {
        IDataSource _dataSource;
        
        public Repository(IDataSource dataSource)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        public async Task<User> Get(int id)
        {
            var user = await _dataSource.GetUserById(id);
            return user;
        }

        public List<int> GetAllIdList()
        {
            var idList = _dataSource.GetAllIdList();
            return idList;
        }

        public List<User> GetAllUsers()
        {
            var usersList = _dataSource.GetAllUsers();
            return usersList;
        }

        public async Task<User> GetNextUser()
        {
            var user = await _dataSource.GetNextUser();
            return user;
        }
    }
}
