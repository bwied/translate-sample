using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using TranslationServices;

namespace TranslateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {

            return Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [EnableCors("_myAllowSpecificOrigins")]
        public string Post([FromBody] TranslationRequest request)
        {
            var svc = new TranslationServicesFacade();
            var translatedHtml = svc.TranslateHtml(request.InputText, new[] {request.LanguageTag}).Response.SingleOrDefault()?.Translations.SingleOrDefault()?.Text;

            return translatedHtml;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class TranslationRequest
    {
        public string InputText { get; set; }
        public string LanguageTag { get; set; }
        public string FromLanguage { get; set; }
    }
}
