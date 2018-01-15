using System.Threading.Tasks;
using System.Collections.Generic;

namespace PhoneList
{
    public class UsersList : IDataSource
    {
        public List<User> usersList { get; set; }
        private static int _currentUserPos = 0;

        public UsersList()
        {
            usersList = new List<User>();
            Init();
        }

        public void Init()
        {
            //for (int i = 20; i < 40; i++)
            //{
            //    usersList.Add(new User(i, "name" + i, "LastName" + i, i * 10, i.ToString()));
            //}
            usersList.Add(new User(1, "Adam", "Wilson", "0506854177", "FaceIcon"));
            usersList.Add(new User(2, "John", "Smith", "0503698521", "FaceIcon"));
            usersList.Add(new User(3, "Sam", "White", "0997020334", "FaceIcon"));
            usersList.Add(new User(4, "Colin", "Jackson", "0923254199", "FaceIcon"));
            usersList.Add(new User(5, "Jack", "Martinez", "0668741224", "FaceIcon"));
            usersList.Add(new User(7, "Daniel", "Clark", "0739855741", "FaceIcon"));
            usersList.Add(new User(9, "Gerard", "Lewis", "0903652177", "FaceIcon"));
            usersList.Add(new User(11, "Alex", "Walker", "0506385754", "FaceIcon"));
            usersList.Add(new User(15, "Simon", "Young", "0984174852", "FaceIcon"));
            usersList.Add(new User(16, "Bill", "Wright", "0963525287", "FaceIcon"));
            usersList.Add(new User(17, "Bob", "Green", "0506974419", "FaceIcon"));
            usersList.Add(new User(20, "William", "Mitchell", "0667272471", "FaceIcon"));
            usersList.Add(new User(25, "David", "Collins", "0995825114", "FaceIcon"));
            usersList.Add(new User(26, "Linda", "Morgan", "0507414453", "FaceIcon"));
            usersList.Add(new User(89, "Alice", "Murphy", "0735287744", "FaceIcon"));
            usersList.Add(new User(90, "Mary", "Cooper", "0986532125", "FaceIcon"));
            usersList.Add(new User(92, "Silvia", "Peterson", "0508574116", "FaceIcon"));
            usersList.Add(new User(94, "Anna", "Watson", "0983696587", "FaceIcon"));
            usersList.Add(new User(96, "Christina", "Henderson", "0985614785", "FaceIcon"));
            usersList.Add(new User(124, "Taylor", "Patterson", "0504174588", "FaceIcon"));
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.Run(() =>
            {
                return usersList.Find(item => item.Id == id);
            }
                                 ).ConfigureAwait(false);
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

        public async Task<User> GetNextUser()
        {
            return await Task.Run(() =>
            {
                if (_currentUserPos == usersList.Count - 1)
                {
                    _currentUserPos = 0;
                }
                var user = usersList[_currentUserPos];
                ++_currentUserPos;
                return user;
            }
            );
        }

        public List<User> GetAllUsers()
        {
            return usersList;
        }
    }
}
