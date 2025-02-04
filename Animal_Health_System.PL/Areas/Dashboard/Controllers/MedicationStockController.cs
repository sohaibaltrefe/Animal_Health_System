using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationStockVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class MedicationStockController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<MedicationStockController> logger;

        public MedicationStockController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MedicationStockController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var medicationSt = await unitOfWork.medicationStockRepository.GetAllAsync();
            var medicationStVM = mapper.Map<IEnumerable<MedicationStockVM>>(medicationSt);
            return View(medicationStVM);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var medications = await unitOfWork.medicationRepository.GetAllAsync();
            var vm = new MedicationStockFormVM
            {
                Medication = new SelectList(medications, "Id", "Name")
            };
            return View(vm);
        }

        // إضافة مخزون دواء جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicationStockFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // تحقق من وجود مخزون دواء بنفس MedicationId
            var existingStock = await unitOfWork.medicationStockRepository.GetAllAsync();
            if (existingStock.Any(ms => ms.Medications.Any(m => m.Id == vm.MedicationId) && !ms.IsDeleted))
            {
                // إضافة رسالة الخطأ إذا تم العثور على MedicationId مكرر
                ModelState.AddModelError("", "The medication is already in stock.");
                var medications = await unitOfWork.medicationRepository.GetAllAsync();
                vm.Medication = new SelectList(medications, "Id", "Name");
                return View(vm);
            }

            var medicationStock = mapper.Map<MedicationStock>(vm);
            await unitOfWork.medicationStockRepository.AddAsync(medicationStock);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var medicationStock = await unitOfWork.medicationStockRepository.GetAsync(id);
            if (medicationStock == null)
            {
                return NotFound();
            }

            var medications = await unitOfWork.medicationRepository.GetAllAsync();
            var vm = mapper.Map<MedicationStockFormVM>(medicationStock);
           

            return View(vm);
        }

        [HttpPost]
[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicationStockFormVM vm)
        {
            var medicsto = await unitOfWork.medicationStockRepository.GetAsync(vm.Id);
            if (medicsto == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var medications = await unitOfWork.medicationRepository.GetAllAsync();
                vm.Medication = new SelectList(medications, "Id", "Name", vm.MedicationId);
                return View(vm);
            }
            mapper.Map(vm, medicsto);



            await unitOfWork.medicationStockRepository.UpdateAsync(medicsto);
            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medicationStock = await unitOfWork.medicationStockRepository.GetAsync(id);
            if (medicationStock == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<MedicationStockDetailsVM>(medicationStock);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationStock = await unitOfWork.medicationStockRepository.GetAsync(id);
            if (medicationStock == null)
            {
                return Json(new { success = false, message = "Medication stock not found." });
            }
            await unitOfWork.medicationStockRepository.DeleteAsync(id);
            return Json(new { success = true });
        }
    }
}
