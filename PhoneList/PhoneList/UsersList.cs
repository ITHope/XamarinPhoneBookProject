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
            for (int i = 20; i < 40; i++)
            {
                usersList.Add(new User(i, "name" + i, "LastName" + i, i * 10, i.ToString()));
            }
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(5000);
                return usersList.Find(item => item.Id == id);
            }
            );
        }

        public List<int> GetAllIdList()
        {
            var idList = new List<int>();
            foreach (var user in usersList)
            {
                idList.Add(user.Id);
            }
            return idList;
        }

        //public static void UpdateUser(User user)
        //{
        //    var userToUpdate = usersList.First(item => item.Id == user.Id);
        //    userToUpdate = user;
        //}
    }
}
