using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ankiety.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        public ActionResult Index()
        {
            var data = _surveyService.GetAll();
            return View(data);
        }
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = _surveyService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(SurveyModel surveyModel)
        {
            _surveyService.Edit(surveyModel);
            return RedirectToAction("Index");
        }
        // GET: /Movies/Add
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SurveyModel surveyModel)
        {
            _surveyService.Add(surveyModel);
            return RedirectToAction("Index");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = _surveyService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(SurveyModel surveyModel)
        {
            _surveyService.Delete(surveyModel.Id);
            return RedirectToAction("Index");
        }
    }
}
