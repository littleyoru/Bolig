using Residences.Controllers;
using Residences.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residences
{
    class Program
    {
        static void Main(string[] args)
        {

            var residenceController = new ResidenceController();

            // find all 4 room residences that allow pets
            var filter = new ResidenceFilter
            {
                rooms = 4,
                allowPets = true
            };
            var residences = residenceController.FilterResidences(filter);





            var loginController = new LoginController();

            // check user login info
            var loginInfo = new LoginInfo
            {
                UserId = 1,
                Email = "elena@gmail.com",
                Password = "Password1"
            };
            var userLogin = loginController.LoginUser(loginInfo);



            Console.ReadLine();



            // call a stored procedure
            //using (var db = new BoligContext())
            //{
            //    db.Database.ExecuteSqlCommand("EXEC Add_Residence 1, 1, 'Spatious apartment close to facilities', 11700, 120, 5, 0, 'Brogade 21, 1.th', 1, '2020/04/01', NULL, '2020/03/01', 36000, 700");

            //    db.SaveChanges();

            //}

            //// List residences titles
            //var residences = new List<Residence>();
            //using (var db = new BoligContext())
            //{
            //    residences = db.Residences.ToList();
            //}

            //foreach (var residence in residences)
            //{
            //    Console.WriteLine(residence.Title);
            //}



            // user repository and unit of work
            //var user = new User
            //{
            //    UserName = "TestUser2",
            //    LastName = "TestLastName2",
            //    Email = "test2@test.dk"
            //};

            //var bc = new BoligContext();
            //var userRepo = new Repository<User>(bc);
            //using (UnitOfWork uow = new UnitOfWork(bc))
            //{
            //    userRepo.Add(user);
            //    uow.Commit();
            //    var users = userRepo.Get();
            //    foreach (var u in users)
            //    {
            //        Console.WriteLine(u.UserName);
            //    }
            //    Console.ReadLine();
            //}

        }
    }
}
