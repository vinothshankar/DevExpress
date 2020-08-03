using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowChart.Models;
using Newtonsoft.Json;

namespace FlowChart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DevDemo DevDemo = new DevDemo();
            string jsonFilePath = @"F:\Projects\FlowChart\FlowChart\Shapes\Shapes.json";
            string diagramFlow = @"F:\Projects\FlowChart\FlowChart\Shapes\diagram_flow.json";

            List<dynamic> Shapes = new List<dynamic>();
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                Shapes = JsonConvert.DeserializeObject<List<dynamic>>(json);
                DevDemo.Shapes = JsonConvert.SerializeObject(Shapes);
            }
           
            List<dynamic> Flows = new List<dynamic>();
            using (StreamReader r = new StreamReader(diagramFlow))
            {
                string json = r.ReadToEnd();
                DevDemo.DiagramFlow = JsonConvert.SerializeObject(json);
            }
            
            return View(DevDemo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}