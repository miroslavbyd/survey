using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.ViewComponents
{
    public class ContainersViewComponent : ViewComponent
    {
        private readonly IContainerService _containerService;
        public ContainersViewComponent(IContainerService containerService)
        {
            _containerService = containerService;
        }
        public IViewComponentResult Invoke(int SurveyId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                var rezult = _containerService.GetAllId(SurveyId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Add")
            {
                ContainerModel containerModel = new ContainerModel();
                containerModel.SurveyId = SurveyId;
                var model = containerModel;
                return View("AddContainer", model);
            }
            return View(null);
        }
    }
}