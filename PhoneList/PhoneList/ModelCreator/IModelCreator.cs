using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public interface IModelCreator
    {
        ViewModel GetModel(int id);
    }
}
