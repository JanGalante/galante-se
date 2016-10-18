using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace galante_se.Controllers
{
    //[Route("[controller]")] //or less generic [Route("About")]
    [Route("company/[controller]/[action]")] //or less generic [Route("About")]
    public class AboutController
    {
        //[Route("")] //no action needed to request this action (/about). This attribute is default and not needed
        public string Phone()
        {
            return "046-1234567";
        }

        //[Route("[action]")] //or less generic [Route("country")]
        public string Country()
        {
            return "Sweden";
        }
    }
}
