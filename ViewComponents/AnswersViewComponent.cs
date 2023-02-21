using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.ViewComponents
{
    public class AnswersViewComponent : ViewComponent
    {
        private readonly IAnswerService _answerService;
        public AnswersViewComponent(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        public IViewComponentResult Invoke(int QuestionId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                var rezult = _answerService.GetAllId(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Add")
            {
                AnswerModel answerModel = new AnswerModel();
                answerModel.QuestionId = QuestionId;
                var model = answerModel;
                return View("AddAnswer", model);
            }
            return View(null);
        }
    }
}
