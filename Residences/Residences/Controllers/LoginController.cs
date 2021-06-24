using Residences.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Controllers
{
    public class LoginController
    {
        public void ChangePassword(string newPassword, int userId)
        {
            BoligContext bc = new BoligContext();
            var loginRepo = new Repository<Login>(bc);
            using (var unit = new UnitOfWork(bc))
            {
                var userLogin = loginRepo.Get(x => x.User.Id == userId).FirstOrDefault();
                if (userLogin != null) userLogin.Password = newPassword;
                loginRepo.Update(userLogin);
                unit.Commit();
            }
        }

        public bool LoginUser(LoginInfo loginInfo)
        {
            var logInSuccess = false;
            BoligContext bc = new BoligContext();
            var loginRepo = new Repository<Login>(bc);

            var userLogin = loginRepo.GetById(loginInfo.UserId);
            if (loginInfo.Password == userLogin.Password && loginInfo.Email == userLogin.User.Email)
                logInSuccess = true;

            return logInSuccess;
        }
        
    }

    public class LoginInfo
    {
        public int UserId;
        public string Email;
        public string Password;
    }
}
