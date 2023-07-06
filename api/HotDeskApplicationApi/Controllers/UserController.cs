using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using HotDeskApplicationApi.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();

        // GET: api/values
        [HttpGet]
        public User[] Get()
        {
            return users.ToArray();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            users.Add(user);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]User user)
        {
            Delete(id);
            Post(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            User deletedUser = Get(id);
            users.Remove(deletedUser);
        }
    }
}

