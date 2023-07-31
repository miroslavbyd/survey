using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        public ActionResult Index()
        {
            var data = _answerService.GetAll();
            return View(data);
        }
        // GET: /Movies/GetAllId
        public ActionResult GetAllId(int? id)
        {
            var data = _answerService.GetAllId(id);
            return PartialView(data);
        }
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = _answerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(AnswerModel answerModel)
        {
            var rezult = new AnswerModel()
            {
                Id = Convert.ToInt32(Request.Form["Answer.Id"]),
                Signature = (Request.Form["Answer.Signature"] != "") ? Request.Form["Answer.Signature"].ToString() : null,
                ValueINT = (Request.Form["Answer.ValueINT"] != "") ? Convert.ToInt32(Request.Form["Answer.ValueINT"]) : null,
                ValueDATETIME = (Request.Form["Answer.ValueDATETIME"] !="") ? Convert.ToDateTime(Request.Form["Answer.ValueDATETIME"]) : null,
                ValueTEXT = (Request.Form["Answer.ValueTEXT"] !="") ? Request.Form["Answer.ValueTEXT"].ToString() : null,
                ValueBIT = (Request.Form["Answer.ValueBIT"] !="") ? Convert.ToBoolean(Request.Form["Answer.ValueBIT"]) : null,
                QuestionId = Convert.ToInt32(Request.Form["Answer.QuestionId"])
            };
            _answerService.Edit(rezult);
            int? Id = _answerService.ContainerIdToSurveyId(_answerService.QuestionIdToContainerId(_answerService.AnswerIdToQuestionId(rezult.Id)));
            if (Id != null)
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
        public ActionResult Add(AnswerModel answerModel)
        {
            var rezult = new AnswerModel();
            if (rezult != null)
            {
                //rezult.Id = int.Parse(Request.Form["Id"]);
                rezult.Signature = (Request.Form["Signature"] != "") ? Request.Form["Signature"].ToString() : null;
                rezult.ValueINT = (Request.Form["ValueINT"] != "") ? Convert.ToInt32(Request.Form["ValueINT"]) : null;
                rezult.ValueDATETIME = (Request.Form["ValueDATETIME"] != "") ? Convert.ToDateTime(Request.Form["ValueDATETIME"]) : null;
                rezult.ValueTEXT = (Request.Form["ValueTEXT"] != "") ? Request.Form["ValueTEXT"].ToString() : null;
                rezult.ValueBIT = (Request.Form["ValueBIT"] != "") ? Convert.ToBoolean(Request.Form["ValueBIT"]) : null;
                rezult.QuestionId = Convert.ToInt16(Request.Form["QuestionId".ToString()]);
            };
            int? Id = _answerService.ContainerIdToSurveyId(_answerService.QuestionIdToContainerId(rezult.QuestionId));
            _answerService.Add(rezult);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = _answerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(AnswerModel answerModel)
        {
            var rezult = new AnswerModel();
            if (rezult != null)
            {
                rezult.Id = Convert.ToInt32(Request.Form["Answer.Id"]);
                rezult.Signature = (Request.Form["Answer.Signature"] != "") ? Request.Form["Answer.Signature"].ToString() : null;
                rezult.ValueINT = (Request.Form["Answer.ValueINT"] != "") ? Convert.ToInt32(Request.Form["Answer.ValueINT"]) : null;
                rezult.ValueDATETIME = (Request.Form["Answer.ValueDATETIME"] != "") ? Convert.ToDateTime(Request.Form["Answer.ValueDATETIME"]) : null;
                rezult.ValueTEXT = (Request.Form["Answer.ValueTEXT"] != "") ? Request.Form["Answer.ValueTEXT"].ToString() : null;
                rezult.ValueBIT = (Request.Form["Answer.ValueBIT"] != "") ? Convert.ToBoolean(Request.Form["Answer.ValueBIT"]) : null;
                rezult.QuestionId = Convert.ToInt16(Request.Form["Answer.QuestionId".ToString()]);
            };
            int? Id = _answerService.ContainerIdToSurveyId(_answerService.QuestionIdToContainerId(_answerService.AnswerIdToQuestionId(rezult.Id)));
            _answerService.Delete(rezult.Id);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }
    }
}
