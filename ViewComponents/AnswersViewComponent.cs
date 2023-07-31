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
        public IViewComponentResult Invoke(int QuestionId, int AnswerId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                MyView = "Answers";
                var rezult = _answerService.GetAllId(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Add")
            {
                MyView = "AddAnswer";
                AnswerModel answerModel = new AnswerModel();
                answerModel.QuestionId = QuestionId;
                var model = answerModel;
                return View(MyView, model);
            }
            if (Function == "Edit")
            {
                MyView = "EditAnswer";
                var rezult = _answerService.Edit(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "PresentationType1")
            {
                MyView = "PresentationAnswerType1";
                var rezult = _answerService.GetAllId(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "PresentationType2")
            {
                MyView = "PresentationAnswerType2";
                var rezult = _answerService.GetAllId(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "PresentationType3")
            {
                MyView = "PresentationAnswerType3";
                var rezult = _answerService.GetAllId(QuestionId);
                var model = rezult;
                return View(MyView, model);
            }
            return View(MyView, _answerService.GetAllId(AnswerId));
        }
    }
}
