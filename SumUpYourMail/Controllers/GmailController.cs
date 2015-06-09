using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SumUpYourMail.Controllers
{
    public class GmailController : Controller
    {
        // GET: Gmail
        public ActionResult Index()
        {
            return View();
        }
    }
}