using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class Interactor : IInteractor
    {
        IRepository _repository;

        public Interactor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ViewModel Get()
        {
            var user = _repository.Get();
            IModelCreator modelCreator = new ModelCreator(user);
            var model = modelCreator.GetModel();
            return model;
        }
    }
}
