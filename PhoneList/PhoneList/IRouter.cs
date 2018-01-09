namespace PhoneList
{
    public interface IRouter
    {
        void GoToDetailsPage(string fName, string lName, string phone, string icon);
    }
}
