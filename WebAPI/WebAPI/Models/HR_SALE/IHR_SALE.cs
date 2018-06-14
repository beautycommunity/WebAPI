using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models.HR_SALE
{
    interface IHR_SALE
    {
        IEnumerable<Detail> IndexHrSale(user data);
        IEnumerable<Detail> AddPosition(Detail data);
        IEnumerable<ShowProduct> Main(HR_DATA data); 
        IEnumerable<Detail> Change_now(ShowProduct data); 
        IEnumerable<Detail> Del_now(ShowProduct data); 
        IEnumerable<Product> BuyProduct(Detail data);
        IEnumerable<Detail> SetProduct(Product data);
        IEnumerable<Management> Setting(Input_Management data);
        IEnumerable<Management_All> Setting_ALL();

        IEnumerable<SetPro> SetEndDate(Detail data);
        IEnumerable<Detail> Ch_Pro(Detail data); 
        IEnumerable<Management> ShowHistory(Input_Management data);

        IEnumerable<lvl> LVL(Inputlvl data);
        IEnumerable<Detail> Ch_LVL_NOW(lvl data);
        IEnumerable<Detail> SetPass(user data);

        IEnumerable<Detail> Deteil(Management data);
    }
}
