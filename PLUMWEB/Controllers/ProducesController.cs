using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PLUMWEB.Data;
using PLUMWEB.Data.Models;
using PLUMWEB.Models.Repositories;
using PLUMWEB.Contracts;

namespace PLUMWEB.Controllers
{
    public class ProducesController : Controller
    {
        private readonly IProduceRepository produceRepository;
        private readonly IMapper mapper;

        public ProducesController(IProduceRepository produceRepository, IMapper mapper)
        {
            this.produceRepository = produceRepository;
            this.mapper = mapper;
        }

        // GET: Produces
        public async Task<IActionResult> Index()
        {
            var produces = mapper.Map<List<ProduceVM>>(await produceRepository.GetAllAsync());
            return View(produces);
        }

        // GET: Produces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var produce = await produceRepository.GetAsync(id);
            if (produce == null)
            {
                return NotFound();
            }
            var produceVM = mapper.Map<ProduceVM>(produce);
            return View(produceVM);
        }

        // GET: Produces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produces/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProduceVM produceVM)
        {
            if (ModelState.IsValid)
            {
                var produce = mapper.Map<Produce>(produceVM);
                await produceRepository.AddAsync(produce);
                return RedirectToAction(nameof(Index));
            }
            return View(produceVM);
        }

        // GET: Produces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        { 
            var produce = await produceRepository.GetAsync(id);
            if (produce == null)
            {
                return NotFound();
            }
            var produceVM = mapper.Map<ProduceVM>(produce);
            return View(produceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProduceVM produceVM)
        {
            if (id != produceVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produce = mapper.Map<Produce>(produceVM);
                    await produceRepository.UpdateAsync(produce);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await produceRepository.Exists(produceVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produceVM);
        }

        // POST: Produces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await produceRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
