using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cryptography;
using System.Security.Cryptography;
using System.Text;


namespace DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{word}")]
        public ActionResult<string> Get(string word)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            Cryptography.RAS_Helper rsa_helper = new Cryptography.RAS_Helper();
            string publickey = rsa.ToXmlString(false);
            string aux = word;
            
            return rsa_helper.EncriptarTexto(publickey, aux);

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
}
