using EventData.Repository;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusiness.Services
{
    public class UserService
    {
        private readonly IUserRepo _user;
        public UserService(IUserRepo user) 
        {
            _user = user;
        }
        public bool AddUser(UserModel user)
        {
            return _user.CreateUser(user);
        }
        public UserModel Login(UserModel user)
        {
            return _user.Login(user);
        }
        public UserModel GetUser(int id)
        {
            return _user.Get(id);
        }
        public IList<UserModel> GetUsers()
        {
            return _user.GetAll();
        }
    }
}
