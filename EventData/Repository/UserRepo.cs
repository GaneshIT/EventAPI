using EventData.DataContext;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly EventDbContext _dbContext;
        public UserRepo(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateUser(UserModel user)
        {
            _dbContext.userModels.Add(user);
            _dbContext.SaveChanges();
            return true;
        }

        public UserModel Get(int id)
        {
            UserModel user = _dbContext.userModels.Find(id);
            return user;
        }
        public UserModel Login(UserModel login)
        {
            UserModel user = (UserModel)_dbContext.userModels.Where(obj=>obj.Email==login.Email && obj.Password==login.Password).Select(obj=>new {obj.Name,obj.Email,obj.Id});
            return user;
        }

        public IList<UserModel> GetAll()
        {
            return _dbContext.userModels.ToList();
        }
    }
}
