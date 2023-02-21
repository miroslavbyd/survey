using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public ActionResult Index()
        {
            var data = _questionService.GetAll();
            return View(data);
        }
        // GET: /Movies/GetAllId
        public ActionResult GetAllId(int? id)
        {
            var data = _questionService.GetAllId(id);
            return PartialView(data);
        }
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = _questionService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(QuestionModel questionModel)
        {
            var rezult = new QuestionModel()
            {
                Id = int.Parse(Request.Form["Question.Id"]),
                Description = Request.Form["Question.Description"],
                ContainerId = int.Parse(Request.Form["Question.ContainerId"]),
                TypeQuestionId = int.Parse(Request.Form["Question.TypeQuestionId"])
            };
            _questionService.Edit(rezult);
            int? Id = _questionService.ContainerIdToSurveyId(_questionService.QuestionIdToContainerId(rezult.Id));
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
        public ActionResult Add(QuestionModel questionModel)
        {
            var rezult = new QuestionModel();
            if (rezult != null)
            {
                //rezult.Id = int.Parse(Request.Form["Id"]);
                rezult.Description = Request.Form["Description"];
                rezult.ContainerId = int.Parse(Request.Form["ContainerId"]);
                rezult.TypeQuestionId = int.Parse(Request.Form["TypeQuestionId"]);
            };
            int? Id = _questionService.ContainerIdToSurveyId(rezult.ContainerId);
            _questionService.Add(rezult);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = _questionService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(QuestionModel questionModel)
        {
            var rezult = new QuestionModel();
            if (rezult != null)
            {
                rezult.Id = int.Parse(Request.Form["Question.Id"]);
                rezult.Description = Request.Form["Question.Description"];
                rezult.ContainerId = int.Parse(Request.Form["Question.ContainerId"]);
                rezult.TypeQuestionId = int.Parse(Request.Form["Question.TypeQuestionId"]);
            };
            int? Id = _questionService.ContainerIdToSurveyId(_questionService.QuestionIdToContainerId(rezult.Id));
            _questionService.Delete(rezult.Id);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }
    }
}