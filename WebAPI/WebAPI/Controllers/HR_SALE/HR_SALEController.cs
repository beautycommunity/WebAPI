using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.HR_SALE;

namespace WebAPI.Controllers.HR_SALE
{
    public class HR_SALEController : ApiController
    {
        static readonly IHR_SALE repository = new HR_SALERepository();

        [HttpPost]
        [ActionName("IndexHrSale")]
        public IEnumerable<Detail> IndexHrSale([FromBody]user data)
        {
            return repository.IndexHrSale(data);
        }

        [HttpPost]
        [ActionName("AddPosition")]
        public IEnumerable<Detail> AddPosition([FromBody]Detail data)
        {
            return repository.AddPosition(data);
        }
             
        [HttpPost]
        [ActionName("Main")]
        public IEnumerable<ShowProduct> Main([FromBody]HR_DATA data)
        {
            return repository.Main(data);
        }

        [HttpPost]
        [ActionName("Change_now")]
        public IEnumerable<Detail> Change_now([FromBody]ShowProduct data)
        {
            return repository.Change_now(data);
        }

        [HttpPost]
        [ActionName("Del_now")]
        public IEnumerable<Detail> Del_now([FromBody]ShowProduct data)
        {
            return repository.Del_now(data);
        }

        [HttpPost]
        [ActionName("BuyProduct")]
        public IEnumerable<Product> BuyProduct([FromBody]Detail data)
        {
            return repository.BuyProduct(data);
        }

        [HttpPost]
        [ActionName("SetProduct")]
        public IEnumerable<Detail> SetProduct([FromBody]Product data)
        {
            return repository.SetProduct(data);
        }

        [HttpPost]
        [ActionName("Setting")]
        public IEnumerable<Management> Setting([FromBody]Input_Management data)
        {
            return repository.Setting(data);
        }

        [HttpPost]
        [ActionName("Setting_ALL")]
        public IEnumerable<Management_All> Setting_ALL()
        {
            return repository.Setting_ALL();
        }

        [HttpPost]
        [ActionName("SetEndDate")]
        public IEnumerable<SetPro> SetEndDate(Detail data)
        {
            return repository.SetEndDate(data);
        }

        [HttpPost]
        [ActionName("Ch_Pro")]
        public IEnumerable<Detail> Ch_Pro(Detail data)
        {
            return repository.Ch_Pro(data);
        }

        [HttpPost]
        [ActionName("ShowHistory")]
        public IEnumerable<Management> ShowHistory(Input_Management data)
        {
            return repository.ShowHistory(data);
        }

        [HttpPost]
        [ActionName("LVL")]
        public IEnumerable<lvl> LVL(Inputlvl data)
        {
            return repository.LVL(data);
        }

        [HttpPost]
        [ActionName("Ch_LVL_NOW")]
        public IEnumerable<Detail> Ch_LVL_NOW(lvl data)
        {
            return repository.Ch_LVL_NOW(data);
        }

        [HttpPost]
        [ActionName("SetPass")]
        public IEnumerable<Detail> SetPass(user data)
        {
            return repository.SetPass(data);
        }

        [HttpPost]
        [ActionName("Deteil")]
        public IEnumerable<Detail> Deteil(Management data)
        {
            return repository.Deteil(data);
        }
    }
}
