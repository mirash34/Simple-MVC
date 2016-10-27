using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using study.Models;
using System.Web;

namespace study.Controllers
{
    public class InforamtionController : ApiController
    {
        
        [HttpPost]
        [Route("api/information/edit")]
        public Information Edit(Information info)
        {
            System.Threading.Thread.Sleep(3000);
            long IdVar = info.Id;
            Information someObj = study.Models.Information.AllInformation.FirstOrDefault(x => x.Id == IdVar);
            if (IdVar == -1)
            {
                someObj = new Information { Id = -1 };
                someObj.Id = Information.AllInformation.Max(x => x.Id) + 1;
                Information.AllInformation.Add(someObj);

            }
            else if (someObj == null)
            {
                return someObj;
            }
            someObj.PublicationDate = info.PublicationDate;
            someObj.Title = info.Title;
            someObj.Description = info.Description;
            Information.SetFile(Information.AllInformation, HttpContext.Current.Server.MapPath("/data.json"));
            return someObj;
        }

    }
}
