using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.Hr_Register
{
    interface IRegisRepository
    {
        IEnumerable<RetName> Regis_Step_One(insert_Step_One id);
        IEnumerable<RetName> Regis_Step_Two(insert_Step_Two id);
        IEnumerable<RetName> Regis_Step_Three(insert_Step_Three id);
        IEnumerable<RetName> Regis_Step_Four(insert_Step_Four id);

        IEnumerable<insert_Step_One> Back_Two_To_One(RetName id);
        IEnumerable<insert_Step_Two> Back_Three_To_Two(RetName id);

        IEnumerable<ViewSummary> Summary(RetName id);
    }
}
