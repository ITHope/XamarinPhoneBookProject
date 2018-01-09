using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public interface IRepository
    {
        Task<User> Get(int id);
        List<int> GetAllIdList();
        Task<User> GetNextUser();
        List<User> GetAllUsers();
    }
}
