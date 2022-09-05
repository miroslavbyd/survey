using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.Controllers
{
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;
        public HeaderController(IHeaderService headerService)
        {
            _headerService = headerService;
        }
        public ActionResult Index()
        {
            var data = _headerService.GetAll();
            return View(data);
        }
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = _headerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(HeaderModel headerModel)
        {
            _headerService.Edit(headerModel);
            return RedirectToAction("Index");
        }
        // GET: /Movies/Add
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(HeaderModel headerModel)
        {
            _headerService.Add(headerModel);
            return RedirectToAction("Index");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = _headerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(HeaderModel headerModel)
        {
            _headerService.Delete(headerModel.Id);
            return RedirectToAction("Index");
        }
    }
}
