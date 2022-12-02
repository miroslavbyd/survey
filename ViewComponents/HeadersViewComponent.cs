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
        public IViewComponentResult Invoke(int Id)
        {
            var rezult = _headerService.GetAllId(Id);
            return View(rezult);
        }
    }
}
