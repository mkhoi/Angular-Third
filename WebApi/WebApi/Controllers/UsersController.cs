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
    }
}
