using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneList
{
    public interface IModelCreator
    {
        Task<ViewModel> GetModel(int id);
        List<int> GetAllIdList();
        Task<ViewModel> GetNextUserModel();
    }
}
