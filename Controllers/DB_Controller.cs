using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet_Project.models;
using System.Data.SqlClient;


namespace DotNet_Project.Controllers{

    [Route("api/[controller]")]
    public class Db_Controller : Controller{

        /*
        [HttpGet("{cardname}")]
        public IEnumerable<models.Carta> Searching(string cardname){
            lul
        }
         */

        //api/db_
        [HttpGet("{word}")]
        public ActionResult<string> Get(string word){
            return word;
        }
    }
}