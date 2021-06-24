using Residences.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Controllers
{
    public class UserController
    {

        public void AddUser(User user)
        {
            BoligContext bc = new BoligContext();
            var userRepo = new Repository<User>(bc);
            using (var uow = new UnitOfWork(bc))
            {
                userRepo.Add(user);
                uow.Commit();
            }
        }

        public void AddUser(UserDetails userDetails)
        {
            BoligContext bc = new BoligContext();
            var userRepo = new Repository<User>(bc);
            var user = new User
            {
                UserName = userDetails.FirstName,
                LastName = userDetails.LastName,
                Email = userDetails.Email
            };
            using (var uow = new UnitOfWork(bc))
            {
                userRepo.Add(user);
                uow.Commit();
            }
        }

        public void AddUser(string name, string lastName, string email)
        {
            BoligContext bc = new BoligContext();
            var userRepo = new Repository<User>(bc);
            var newUser = new User
            {
                UserName = name,
                LastName = lastName,
                Email = email
            };
            using(var uow = new UnitOfWork(bc))
            {
                userRepo.Add(newUser);
                uow.Commit();
            }
        }

        public UserDetails GetUser(int id)
        {
            BoligContext bc = new BoligContext();
            var userRepo = new Repository<User>(bc);
            var user = userRepo.GetById(id);
            var userDetail = new UserDetails
            {
                UserId = user.Id,
                FirstName = user.UserName,
                LastName = user.LastName,
                Email = user.Email
            };
            return userDetail;
        }

        public UserDetails GetUser(string email)
        {
            BoligContext bc = new BoligContext();
            var userRepo = new Repository<User>(bc);
            var user = userRepo.Get(x => x.Email == email).FirstOrDefault();
            var userDetails = new UserDetails
            {
                UserId = user.Id,
                FirstName = user.UserName,
                LastName = user.LastName,
                Email = user.Email
            };
            return userDetails;
        }
    }

    public class UserDetails
    {
        public int UserId;
        public string FirstName;
        public string LastName;
        public string Email;
    }
}
