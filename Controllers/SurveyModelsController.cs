using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ankiety.Models;

namespace ankiety.Controllers
{
    public class SurveyModelsController : Controller
    {
        //private readonly SurveyDbContext _context;

        //public SurveyModelsController(SurveyDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: SurveyModels
        //public async Task<IActionResult> Index()
        //{
        //      return _context.SurveyModel != null ? 
        //                  View(await _context.SurveyModel.ToListAsync()) :
        //                  Problem("Entity set 'SurveyDbContext.SurveyModel'  is null.");
        //}

        //// GET: SurveyModels/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.SurveyModel == null)
        //    {
        //        return NotFound();
        //    }

        //    var surveyModel = await _context.SurveyModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (surveyModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(surveyModel);
        //}

        //// GET: SurveyModels/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SurveyModels/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,DateCreation,DateFrom,DateTo")] SurveyModel surveyModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(surveyModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(surveyModel);
        //}

        //// GET: SurveyModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.SurveyModel == null)
        //    {
        //        return NotFound();
        //    }

        //    var surveyModel = await _context.SurveyModel.FindAsync(id);
        //    if (surveyModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(surveyModel);
        //}

        //// POST: SurveyModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateCreation,DateFrom,DateTo")] SurveyModel surveyModel)
        //{
        //    if (id != surveyModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(surveyModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SurveyModelExists(surveyModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(surveyModel);
        //}

        //// GET: SurveyModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.SurveyModel == null)
        //    {
        //        return NotFound();
        //    }

        //    var surveyModel = await _context.SurveyModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (surveyModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(surveyModel);
        //}

        //// POST: SurveyModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.SurveyModel == null)
        //    {
        //        return Problem("Entity set 'SurveyDbContext.SurveyModel'  is null.");
        //    }
        //    var surveyModel = await _context.SurveyModel.FindAsync(id);
        //    if (surveyModel != null)
        //    {
        //        _context.SurveyModel.Remove(surveyModel);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SurveyModelExists(int id)
        //{
        //  return (_context.SurveyModel?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
