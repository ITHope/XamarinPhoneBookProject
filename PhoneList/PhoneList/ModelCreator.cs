using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class ModelCreator : IModelCreator
    {
        private User _user;

        public ModelCreator(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public ViewModel GetModel()
        {
            var model = new ViewModel(_user.Name, _user.LastName);
            return model;
        }
    }
}
