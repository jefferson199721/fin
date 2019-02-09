using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion_Final2.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        
    }
}