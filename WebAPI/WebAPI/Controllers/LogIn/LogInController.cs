using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models.LogIn;

namespace WebAPI.Controllers.LogIn
{
    public class LogInController : ApiController
    {
        static readonly ILoginRepository repository = new LoginRepository();

        [HttpPost]
        [ActionName("APILogin")]
        public IEnumerable<RetName> APILogin([FromBody]DataUser data)
        {
            return repository.APILogin(data);
        }
    }
}