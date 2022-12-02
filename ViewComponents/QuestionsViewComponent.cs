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
        public IViewComponentResult Invoke(int Id)
        {
            var rezult = _questionService.GetAllId(Id);
            return View(rezult);
        }
    }
}
