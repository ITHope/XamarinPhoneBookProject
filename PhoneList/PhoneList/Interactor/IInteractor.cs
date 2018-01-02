using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList
{
    public interface IInteractor
    {
        Task<ViewModel> Get(int id);
        List<int> GetAllIdList();
        Task<ViewModel> GetNextUser();
    }
}
