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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<MedicationController> logger;

        public MedicationController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MedicationController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var medications = await unitOfWork.medicationRepository.GetAllAsync();
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
            await unitOfWork.medicationRepository.AddAsync(medication);
            await unitOfWork.medicationRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medication = await unitOfWork.medicationRepository.GetAsync(id);
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

            var medication = await unitOfWork.medicationRepository.GetAsync(vm.Id);
            if (medication == null)
            {
                return NotFound();
            }

            mapper.Map(vm, medication);
            await unitOfWork.medicationRepository.UpdateAsync(medication);
            await unitOfWork.medicationRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medication = await unitOfWork.medicationRepository.GetAsync(id);
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
            await unitOfWork.medicationRepository.DeleteAsync(id);
            await unitOfWork.medicationRepository.SaveChangesAsync();
            return Ok(new { Message = "Medication deleted" });
        }
    }
}
