using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.LogIn
{
    interface ILoginRepository
    {
        IEnumerable<RetName> APILogin(DataUser data);
    }
}
