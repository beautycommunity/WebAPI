﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPI.Models.Hr_Register;

namespace WebAPI.Controllers.Hr_Register
{
    public class RegisterController : ApiController
    {
        static readonly IRegisRepository repository = new RegisRepository();

        [HttpPost]
        [ActionName("Regis_Step_One")]
        public IEnumerable<RetName> Regis_Step_One([FromBody]insert_Step_One id)
        {
            return repository.Regis_Step_One(id);
        }

        [HttpPost]
        [ActionName("Regis_Step_Two")]
        public IEnumerable<RetName> Regis_Step_Two([FromBody]insert_Step_Two id)
        {
            return repository.Regis_Step_Two(id);
        }

        [HttpPost]
        [ActionName("Regis_Step_Three")]
        public IEnumerable<RetName> Regis_Step_Three([FromBody]insert_Step_Three id)
        {
            return repository.Regis_Step_Three(id);
        }

        [HttpPost]
        [ActionName("Regis_Step_Four")]
        public IEnumerable<RetName> Regis_Step_Four([FromBody]insert_Step_Four id)
        {
            return repository.Regis_Step_Four(id);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IEnumerable<ViewSummary> Summary([FromBody]RetName id)
        {
            return repository.Summary(id);
        }

        // ---------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [ActionName("Back_Two_To_One")]
        public IEnumerable<insert_Step_One> Back_Two_To_One([FromBody]RetName id)
        {
            return repository.Back_Two_To_One(id);
        }

        [HttpPost]
        [ActionName("Back_Three_To_Two")]
        public IEnumerable<insert_Step_Two> Back_Three_To_Two([FromBody]RetName id)
        {
            return repository.Back_Three_To_Two(id);
        }
    }
}