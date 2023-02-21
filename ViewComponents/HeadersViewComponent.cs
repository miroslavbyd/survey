using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.ViewComponents
{
    public class HeadersViewComponent : ViewComponent
    {
        private readonly IHeaderService _headerService;
        public HeadersViewComponent(IHeaderService headerService)
        {
            _headerService = headerService;
        }
        public IViewComponentResult Invoke(int SurveyId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                var rezult = _headerService.GetAllId(SurveyId);
                var model = rezult;
                return View(MyView,model);
            }
            if (Function == "Add")
            {
                HeaderModel headerModel = new HeaderModel();
                headerModel.SurveyId = SurveyId;
                var model = headerModel;
                return View("AddHeader", model);
            }
            return View(null);
        }
    }
}
