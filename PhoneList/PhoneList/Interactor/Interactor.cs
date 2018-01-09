using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public class Interactor : IInteractor
    {
        IModelCreator _modelCreator;
        
        public Interactor(IModelCreator modelCreator)
        {
            _modelCreator = modelCreator ?? throw new ArgumentNullException(nameof(modelCreator));
        }
        public async Task<ViewModel> Get(int id)
        {
            var model = await _modelCreator.GetModel(id);
            return model;
        }

        public List<int> GetAllIdList()
        {
            var idList = _modelCreator.GetAllIdList();
            return idList;
        }

        public async Task<ViewModel> GetNextUser()
        {
            var model = await _modelCreator.GetNextUserModel();
            return model;
        }
    }
}
