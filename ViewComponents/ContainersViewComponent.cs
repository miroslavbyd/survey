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
        public IViewComponentResult Invoke(int SurveyId, int ContainerId, string Function)
        {
            string MyView = "Default";

            if (Function == "GetAllId")
            {
                MyView = "Containers";
                var rezult = _containerService.GetAllId(SurveyId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Add")
            {
                MyView = "AddContainer";
                ContainerModel containerModel = new ContainerModel();
                containerModel.SurveyId = SurveyId;
                var model = containerModel;
                return View(MyView, model);
            }
            if (Function == "Edit")
            {
                MyView = "EditContainer";
                var rezult = _containerService.Edit(ContainerId);
                var model = rezult;
                return View(MyView, model);
            }
            if (Function == "Presentation")
            {
                MyView = "PresentationContainers";
                var rezult = _containerService.GetAllId(SurveyId);
                var model = rezult;
                return View(MyView, model);
            }
            return View(MyView, _containerService.GetAllId(SurveyId));
        }
    }
}