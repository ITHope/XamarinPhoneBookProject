using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class ModelCreator : IModelCreator
    {
        IRepository _repository;

        public ModelCreator(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ViewModel GetModel(int id)
        {
            var user = _repository.Get(id);
            ViewModel model;
            if (user == null)
            {
                model = new ViewModel("", "");
            }
            else
            {
                model = new ViewModel(user.Name, user.LastName); // ToDo add user.Name...
            }
            return model;
        }
    }
}
