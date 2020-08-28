using OUAT_K_Version.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.CardProcessor;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace OUAT_K_Version.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
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

        public ActionResult CreateEnd()
        {

            ViewBag.Message = "Create Your Ending";



            return View();
        }

        public ActionResult CreateCard()
        {

            ViewBag.Message = "Create Your Card";



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCard(ElementModels model, HttpPostedFileBase image1 ,FormCollection fm)
        {
            

            if (ModelState.IsValid)
            {

                if(image1 != null)
                {

                    model.ImagePath = new byte[image1.ContentLength];
                    image1.InputStream.Read(model.ImagePath, 0, image1.ContentLength);
                }

                string ET = fm["ET".ToString()];
                string IF = fm["IF".ToString()];
                string II = fm["II".ToString()];

                model.ElementType = ET;
                model.IsForce = IF;
                model.IsInter = II;

               int cardCreate =  CreateElementCard(model.ElementType, 
                    model.ElementName,
                    model.InSan, 
                    model.DeSan, 
                    model.IsForce,
                    model.IsInter,
                    model.ElementDes,
                    model.ImagePath
                    );

                return RedirectToAction("CreateCard");
                
            }

            return View();
        }


        public ActionResult ViewCards()
        {
           

            var data = LoadElementCard();
            List<ElementModels> elementCards = new List<ElementModels>();

            foreach (var row in data)
            {   

                
                elementCards.Add(new ElementModels

                {
                    ElementName = row.ElementName,
                    ElementType = row.ElementType,
                    ElementDes = row.ElementDes,
                    InSan = row.InSan,
                    DeSan = row.DeSan,
                    IsForce = row.IsForce,
                    IsInter = row.IsInter,
                    ImagePath = row.ImagePath


                } );

            }

            return View(elementCards);

        }

        public ActionResult TestView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestView(ElementModels model, HttpPostedFileBase image1, FormCollection fm)
        {

          

                if (image1 != null)
                {

                    model.ImagePath = new byte[image1.ContentLength];
                    image1.InputStream.Read(model.ImagePath, 0, image1.ContentLength);
                }

                string elename = fm["CardNIMG".ToString()];


                model.ElementName = elename;


                int imageupload  = UpdateImage(
                     model.ImagePath,
                     model.ElementName

                     );

            return View();
        }

        public JsonResult GetCardList()
        {
            var data = LoadElementCard();
            List<ElementModels> elementCards = new List<ElementModels>();
            var imgsrc = "";

            foreach (var row in data)
            {
                if (row.ImagePath != null)
                {
                    var base64 = Convert.ToBase64String(row.ImagePath);
                    imgsrc = string.Format("data:image/gif;base64,{0}", base64);
                }
                else
                {
                    imgsrc = null;
                }

                    elementCards.Add(new ElementModels

                    {
                        ElementName = row.ElementName,
                        ElementType = row.ElementType,
                        ElementDes = row.ElementDes,
                        InSan = row.InSan,
                        DeSan = row.DeSan,
                        IsForce = row.IsForce,
                        IsInter = row.IsInter,
                        convPath = imgsrc


                    });

                

            }

            return Json(elementCards, JsonRequestBehavior.AllowGet);
        }

        //Get Card by Card Name
        public JsonResult GetCardByName(string name)
        { 
   
            var Cdata = LoadElementCard();
            var result = Cdata.Where(x => x.ElementName == name).SingleOrDefault();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value, JsonRequestBehavior.AllowGet);
        }


        //Save new card
        [HttpPost]
        public JsonResult SaveCard(ElementModels model, FormCollection fm)
        {

            var result = false;

            if (model.ElementName != null)
            {

                string ET = fm["ET".ToString()];
                string IF = fm["IF".ToString()];
                string II = fm["II".ToString()];

                model.ElementType = ET;
                model.IsForce = IF;
                model.IsInter = II;

                int cardCreate = CreateElementCard(model.ElementType,
                     model.ElementName,
                     model.InSan,
                     model.DeSan,
                     model.IsForce,
                     model.IsInter,
                     model.ElementDes,
                     model.ImagePath
                     );

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //Update
        [HttpPost]
        public JsonResult UpdateCard(ElementModels model, FormCollection fm)
        {

            var result = false;

            if (model.ElementName != null)
            {

                string ET = fm["UET".ToString()];
                string IF = fm["UIF".ToString()];
                string II = fm["UII".ToString()];

                model.ElementType = ET;
                model.IsForce = IF;
                model.IsInter = II;


                int cardCreate = UpdateElementCard(model.ElementType,
                     model.ElementName,
                     model.InSan,
                     model.DeSan,
                     model.IsForce,
                     model.IsInter,
                     model.ElementDes
                     );

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Delete
        [HttpPost]
        public JsonResult DeleteCardRecord(string Ename)
        {
            bool result = false;
            var delete = DeleteElementCardByName(Ename);

            if(delete != null)
            {
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}