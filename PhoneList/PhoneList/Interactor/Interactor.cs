using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            if (model == null)
                model = new ViewModel("", "");
            return model;
        }

        public List<int> GetAllIdList()
        {
            var idList = _modelCreator.GetAllIdList();
            return idList;
        }
    }
}
