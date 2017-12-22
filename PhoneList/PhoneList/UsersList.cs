using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneList
{
    public static class UsersList
    {
        public static List<User> usersList { get; set; }

        static UsersList()
        {
            usersList = new List<User>();
            Init();
        }

        static void Init()
        {
            for (int i = 0; i < 20; i++)
            {
                usersList.Add(new User(i, "name" + i, "LastName" + i, +i * 10, i.ToString()));
            }
        }

        public static User GetUser(int id)
        {
            var user = usersList.First(item => item.Id == id);
            return user;
        }

        //public static void UpdateUser(User user)
        //{
        //    var userToUpdate = usersList.First(item => item.Id == user.Id);
        //    userToUpdate = user;
        //}
    }
}
