using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneList
{
    public class ViewModel
    {
        public string fname;
        public string lname;

        public ViewModel(string fName, string lName)
        {
            fname = fName;
            lname = lName;
        }

        public override bool Equals(object obj)
        {
            return fname == ((ViewModel)obj).fname && lname == ((ViewModel)obj).lname;
        }
    }
}
