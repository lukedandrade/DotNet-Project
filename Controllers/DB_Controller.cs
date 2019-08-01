using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet_Project.models;
using System.Data.SqlClient;
using DbHandler;


namespace DotNet_Project.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class DbController : Controller{

        /*
        [HttpGet("{cardname}")]
        public IEnumerable<models.Carta> Searching(string cardname){
            lul
        }
         */

        //api/db_
        /*
        [HttpGet("{word1},{word2}")]
        public ActionResult<string> Get(string word1, string word2){
            return word1+ " ;;; "+word2;
        }
        */

        [HttpGet("[action]/{name},{url}")]
        public ActionResult<string> InsertCard(string name, string url){
            Carta my_card = new Carta();
            my_card.name = name;
            my_card.url = url;
            Handler handler = new Handler("DotNet-Project_Databank.db","", "", "");
            string my_response = handler.LiteInsertCard(my_card);
            return my_response;
        }
    }
}