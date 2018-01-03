using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneList
{
    public interface IPresenter
    {
        Task Init(int id);
        List<int> GetAllIdList();
        Task GetNextUser();
    }
}
