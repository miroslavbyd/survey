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
        public IViewComponentResult Invoke(int Id)
        {
            var rezult = _containerService.GetAllId(Id);
            return View(rezult);
        }
    }
}