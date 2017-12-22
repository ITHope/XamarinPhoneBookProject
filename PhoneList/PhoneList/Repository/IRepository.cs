using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public interface IRepository
    {
        User Get(int id);
    }
}
