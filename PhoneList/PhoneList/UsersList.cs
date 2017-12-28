using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList
{
    public class UsersList : IDataSource
    {
        public List<User> usersList { get; set; }

        public UsersList()
        {
            usersList = new List<User>();
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < 20; i++)
            {
                usersList.Add(new User(i, "name" + i, "LastName" + i, i * 10, i.ToString()));
            }
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(2000);
                return usersList.Find(item => item.Id == id);
            }
            );
        }

        //public static void UpdateUser(User user)
        //{
        //    var userToUpdate = usersList.First(item => item.Id == user.Id);
        //    userToUpdate = user;
        //}
    }
}
