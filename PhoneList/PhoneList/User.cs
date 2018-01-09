namespace PhoneList
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Icon { get; set; }

        public User(int id, string name, string lastName, string phone, string icon)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Icon = icon;
        }

        public override bool Equals(object obj)
        {
            return Id == ((User)obj).Id
                && Name == ((User)obj).Name
                && LastName == ((User)obj).LastName
                && Phone == ((User)obj).Phone
                && Icon == ((User)obj).Icon;
        }
    }
}
