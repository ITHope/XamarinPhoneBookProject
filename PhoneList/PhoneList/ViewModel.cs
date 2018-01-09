namespace PhoneList
{
    public class ViewModel
    {
        public string fname;
        public string lname;
        public string phone;
        public string iconPicture;

        public ViewModel(string fName, string lName, string phoneNumber, string icon)
        {
            fname = fName;
            lname = lName;
            phone = phoneNumber;
            iconPicture = icon;
        }

        public override bool Equals(object obj)
        {
            return fname == ((ViewModel)obj).fname && lname == ((ViewModel)obj).lname 
                                                   && phone == ((ViewModel)obj).phone 
                                                   && iconPicture == ((ViewModel)obj).iconPicture;
        }
    }
}
