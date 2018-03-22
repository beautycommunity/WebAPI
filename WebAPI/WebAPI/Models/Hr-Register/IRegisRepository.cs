using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.Hr_Register
{
    interface IRegisRepository
    {
        //IEnumerable<RetName> Regis_Step_One(insert_Step_One item);

        IEnumerable<RetName> Regis_Step_Two(insert_Step_Two id);
        IEnumerable<RetName> Regis_Step_One(insert_Step_One id);
    }
}
