using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList
{
    public interface IDataSource
    {
        Task<User> GetUserById(int userId);
        List<int> GetAllIdList();
    }
}
