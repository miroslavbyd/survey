using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.ViewComponents
{
    public class QuestionsViewComponent : ViewComponent
    {
        private readonly IQuestionService _questionService;
        public QuestionsViewComponent(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public IViewComponentResult Invoke(int ContainerId, int QuestionId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                MyView = "Questions";
                var rezult = _questionService.GetAllId(ContainerId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Add")
            {
                MyView = "AddQuestion";
                QuestionModel questionModel = new QuestionModel();
                questionModel.ContainerId = ContainerId;
                var model = questionModel;
                return View(MyView, model);
            }
            if (Function == "Edit")
            {
                MyView = "EditQuestion";
                var rezult = _questionService.Edit(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Presentation")
            {
                MyView = "PresentationQuestions";
                var rezult = _questionService.GetAllId(ContainerId);
                var model = rezult;
                return View(MyView, model);
            }
            return View(MyView, _questionService.GetAllId(QuestionId));
        }
    }
}
