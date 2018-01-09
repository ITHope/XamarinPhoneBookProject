namespace PhoneList
{
    public interface IRouter
    {
        void GoToDetailsPage(string fName, string lName, int phone, string icon);
    }
}
