using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public interface IDataSource
    {
        Task<User> GetUserById(int userId);
        List<int> GetAllIdList();
        Task<User> GetNextUser();
        List<User> GetAllUsers();
    }
}
