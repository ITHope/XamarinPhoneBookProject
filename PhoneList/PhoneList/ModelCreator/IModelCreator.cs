using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public interface IModelCreator
    {
        Task<ViewModel> GetModel(int id);
        List<int> GetAllIdList();
        Task<ViewModel> GetNextUserModel();
    }
}
