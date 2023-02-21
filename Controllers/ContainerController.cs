using ankiety.Models;
using ankiety.Services;
using Microsoft.AspNetCore.Mvc;

namespace ankiety.Controllers
{
    public class ContainerController : Controller
    {
        private readonly IContainerService _containerService;
        public ContainerController(IContainerService containerService)
        {
            _containerService = containerService;
        }
        public ActionResult Index()
        {
            var data = _containerService.GetAll();
            return View(data);
        }
        // GET: /Movies/GetAllId
        public ActionResult GetAllId(int? id)
        {
            var data = _containerService.GetAllId(id);
            return PartialView(data);
        }
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = _containerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(ContainerModel containerModel)
        {
            var rezult = new ContainerModel()
            {
                Id = int.Parse(Request.Form["Container.Id"]),
                Description = Request.Form["Container.Description"],
                SurveyId = int.Parse(Request.Form["Container.SurveyId"])
            };
            _containerService.Edit(rezult);
            int? Id = _containerService.ContainerIdToSurveyId(rezult.Id);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }
        // GET: /Movies/Add
        public ActionResult Add()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(ContainerModel containerModel)
        {
            var rezult = new ContainerModel();
            if (rezult != null)
            {
                //rezult.Id = int.Parse(Request.Form["Id"]);
                rezult.Description = Request.Form["Description"];
                rezult.SurveyId = int.Parse(Request.Form["SurveyId"]);
            };
            int? Id = rezult.SurveyId;
            _containerService.Add(rezult);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = _containerService.Edit(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(ContainerModel containerModel)
        {
            var rezult = new ContainerModel();
            if (rezult != null)
            {
                rezult.Id = int.Parse(Request.Form["Container.Id"]);
                rezult.Description = Request.Form["Container.Description"];
                rezult.SurveyId = int.Parse(Request.Form["Container.SurveyId"]);
            };
            int? Id = _containerService.ContainerIdToSurveyId(rezult.Id);
            _containerService.Delete(rezult.Id);
            if (Id != null)
            {
                return RedirectToAction("Edit", "Survey", new { Id });
            }
            return RedirectToAction("Index", "Survey");
        }
    }
}
