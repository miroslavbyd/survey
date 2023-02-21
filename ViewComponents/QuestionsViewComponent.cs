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
        public IViewComponentResult Invoke(int ContainerId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                var rezult = _questionService.GetAllId(ContainerId);
                var model = rezult;
                return View(MyView,model);
            }
            if (Function == "Add")
            {
                QuestionModel questionModel = new QuestionModel();
                questionModel.ContainerId = ContainerId;
                var model = questionModel;
                return View("AddQuestion", model);
            }
            return View(null);
        }
    }
}
