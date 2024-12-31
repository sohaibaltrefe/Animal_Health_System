using Animal_Health_System.BLL.Interface;
using Animal_Health_System.BLL.Repository;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VeterinarianVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class MedicationController : Controller
    {
        private readonly IMedicationRepository medicationRepository;
        private readonly IMapper mapper;

        public MedicationController(IMedicationRepository medicationRepository,IMapper mapper)
        {
            this.medicationRepository = medicationRepository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var medications = await medicationRepository.GetAllAsync();
            var medicationVMs = mapper.Map<IEnumerable<MedicationVM>>(medications);
            return View(medicationVMs);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicationFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var medication = mapper.Map<Medication>(vm);
            await medicationRepository.AddAsync(medication);
            await medicationRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medication = await medicationRepository.GetAsync(id);
            if (medication == null)
            {
                return NotFound();
            }

            var medicationVM = mapper.Map<MedicationFormVM>(medication);
            return View(medicationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicationFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var medication = await medicationRepository.GetAsync(vm.Id);
            if (medication == null)
            {
                return NotFound();
            }

            mapper.Map(vm, medication);
            await medicationRepository.UpdateAsync(medication);
            await medicationRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medication = await medicationRepository.GetAsync(id);
            if (medication == null)
            {
                return NotFound();
            }

            var medicationVM = mapper.Map<MedicationDetailsVM>(medication);
            return View(medicationVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await medicationRepository.DeleteAsync(id);
            await medicationRepository.SaveChangesAsync();
            return Ok(new { Message = "Medication deleted" });
        }
    }
}
