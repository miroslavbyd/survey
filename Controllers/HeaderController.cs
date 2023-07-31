using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.Controllers
{
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;
        public HeaderController(IHeaderService headerService)
        {
            _headerService = headerService;
        }
        public ActionResult Index()
        {
            var data = _headerService.GetAll();
            return View(data);
        }
        // GET: /Movies/GetAllId
        public ActionResult GetAllId(int? id)
        {
            var data = _headerService.GetAllId(id);
            return PartialView(data);
        }
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = _headerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            var rezult = new HeaderModel()
            {
                //Id = Convert.ToInt16(Request.Form["Header.Id"]),
                //Description = Request.Form["Header.Description"],
                //Style = Convert.ToInt16(Request.Form["Header.Style"]),
                //SurveyId = Convert.ToInt16(Request.Form["Header.SurveyId"])
                Id = Request.Form["Header.Id"] == "" ? 0 : Convert.ToInt16(Request.Form["Header.Id"]),
                Description = Request.Form["Description"] == "" ? "" : Request.Form["Header.Description"],
                Style = Request.Form["Header.Style"] == "" ? null : Convert.ToInt16(Request.Form["Header.Style"]),
                SurveyId = Request.Form["Header.SurveyId"] == "" ? 0 : Convert.ToInt16(Request.Form["Header.SurveyId"]),
            };
            _headerService.Edit(rezult);
            int? Id = _headerService.HeaderIdToSurveyId(rezult.Id);
            if(Id!=null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }
        // GET: /Movies/Add
        public ActionResult Add()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(HeaderModel headerModel)
        {
            var rezult = new HeaderModel();
            if (rezult != null)
            {
                //rezult.Id = Convert.ToInt16(Request.Form["Id"]);
                //rezult.Description = Request.Form["Description"];
                //rezult.Style = Convert.ToInt16(Request.Form["Style"]);
                //rezult.SurveyId = Convert.ToInt16(Request.Form["SurveyId"]);
                rezult.Description = Request.Form["Description"] == "" ? "" : Request.Form["Description"];
                rezult.Style = Request.Form["Style"] == "" ? null : Convert.ToInt16(Request.Form["Style"]);
                rezult.SurveyId = Request.Form["SurveyId"] == "" ? 0 : Convert.ToInt16(Request.Form["SurveyId"]);
            };
            int? Id = rezult.SurveyId;
            _headerService.Add(rezult);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = _headerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(HeaderModel headerModel)
        {
            var rezult = new HeaderModel();
            if (rezult != null)
            {
                //rezult.Id = Convert.ToInt16(Request.Form["Header.Id"]);
                //rezult.Description = Request.Form["Header.Description"];
                //rezult.Style = Convert.ToInt16(Request.Form["Header.Style"]);
                //rezult.SurveyId = Convert.ToInt16(Request.Form["Header.SurveyId"]);
                rezult.Id = Request.Form["Header.Id"] == "" ? 0 : Convert.ToInt16(Request.Form["Header.Id"]);
                rezult.Description = Request.Form["Header.Description"] == "" ? "" : Request.Form["Header.Description"];
                rezult.Style = Request.Form["Header.Style"] == "" ? null : Convert.ToInt16(Request.Form["Header.Style"]);
                rezult.SurveyId = Request.Form["Header.SurveyId"] == "" ? 0 : Convert.ToInt16(Request.Form["Header.SurveyId"]);

            };
            int? Id = _headerService.HeaderIdToSurveyId(rezult.Id);
            _headerService.Delete(rezult.Id);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }
    }
}
