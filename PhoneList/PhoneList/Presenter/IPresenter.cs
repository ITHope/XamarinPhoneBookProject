using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public interface IPresenter
    {
        Task Init(int id);
        List<int> GetAllIdList();
        Task GetNextUser();
        void GoToDetailsPage(int userId);
    }
}
