using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Interactor : IInteractor
    {
        IModelCreator _modelCreator;
        
        public Interactor(IModelCreator modelCreator)
        {
            _modelCreator = modelCreator ?? throw new ArgumentNullException(nameof(modelCreator));
        }

        public ViewModel Get()
        {
            var model = _modelCreator.GetModel();
            if (model == null)
                model = new ViewModel("", "");
            return model;
        }
    }
}
