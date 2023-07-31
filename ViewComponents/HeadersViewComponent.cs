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
        public IViewComponentResult Invoke(int SurveyId, int HeaderId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                MyView = "Headers";
                var rezult = _headerService.GetAllId(SurveyId);
                var model = rezult;
                return View(MyView,model);
            }
            if (Function == "Add")
            {
                MyView = "AddHeader";
                HeaderModel headerModel = new HeaderModel();
                headerModel.SurveyId = SurveyId;
                var model = headerModel;
                return View(MyView, model);
            }
            if (Function == "Edit")
            {
                MyView = "EditHeader";
                var rezult = _headerService.Edit(HeaderId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Presentation")
            {
                MyView = "PresentationHeaders";
                var rezult = _headerService.GetAllId(SurveyId);
                var model = rezult;
                return View(MyView, model);
            }
            return View(MyView, _headerService.GetAllId(SurveyId));
        }
    }
}
