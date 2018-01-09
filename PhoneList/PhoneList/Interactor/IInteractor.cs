using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public interface IInteractor
    {
        Task<ViewModel> Get(int id);
        List<int> GetAllIdList();
        Task<ViewModel> GetNextUser();
    }
}
