namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using WebApi.Models;
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private static List<User> Users { get; set; }
        static UsersController()
        {
        
        }

        [Route("")]
        [HttpGet]
        public IList<User> GetUsers()
        {
            DBContext db = new DBContext();
            Users = db.Users.ToList();
            return Users;
        }

        [HttpPost]
        [Route("")]
        public User CreateUser(User user)
        {
            DBContext db = new DBContext();
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        [HttpPut]
        [Route("{userId}")]
        public void UpdateUser(int userId, User user)
        {
            DBContext db = new DBContext();
            User tempUser = db.Users.FirstOrDefault(temp => temp.Id == userId);
            tempUser.FirstName = user.FirstName;
            tempUser.LastName = user.LastName;
            tempUser.UserName = user.UserName;

            db.SaveChanges();
        }
    }
}
