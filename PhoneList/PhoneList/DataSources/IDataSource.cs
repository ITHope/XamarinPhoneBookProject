using System.Collections.Generic;
using System.Threading.Tasks;

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
