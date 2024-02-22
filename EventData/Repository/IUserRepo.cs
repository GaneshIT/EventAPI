using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.Repository
{   
    public interface IUserRepo
    {
        bool CreateUser(UserModel user);
        UserModel Get(int id);
        IList<UserModel> GetAll();
        UserModel Login(UserModel login);
    }
}
