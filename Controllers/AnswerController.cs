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
                Id = int.Parse(Request.Form["Answer.Id"]),
                Signature = Request.Form["Answer.Signature"],
                ValueINT = int.Parse(Request.Form["Answer.ValueINT"]),
                ValueDATETIME = DateTime.Parse(Request.Form["Answer.ValueDATETIME"]),
                ValueTEXT = Request.Form["Answer.ValueTEXT"],
                ValueBIT = bool.Parse(Request.Form["Answer.ValueBIT"]),
                QuestionId = int.Parse(Request.Form["Answer.QuestionId"])
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
                rezult.Signature = Request.Form["Signature"].ToString();
                rezult.ValueINT = Convert.ToInt32(Request.Form["ValueINT"].ToString());
                rezult.ValueDATETIME = Convert.ToDateTime(Request.Form["ValueDATETIME"].ToString());
                rezult.ValueTEXT = Request.Form["ValueTEXT".ToString()];
                rezult.ValueBIT = Convert.ToBoolean(Request.Form["ValueBIT"].ToString());
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
                rezult.Id = int.Parse(Request.Form["Answer.Id"]);
                rezult.Signature = Request.Form["Answer.Signature"];
                rezult.ValueINT = int.Parse(Request.Form["Answer.ValueINT"]);
                rezult.ValueDATETIME = DateTime.Parse(Request.Form["Answer.ValueDATETIME"]);
                rezult.ValueTEXT = Request.Form["Answer.ValueTEXT"];
                rezult.ValueBIT = bool.Parse(Request.Form["Answer.ValueBIT"]);
                rezult.QuestionId = int.Parse(Request.Form["Answer.QuestionId"]);
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
