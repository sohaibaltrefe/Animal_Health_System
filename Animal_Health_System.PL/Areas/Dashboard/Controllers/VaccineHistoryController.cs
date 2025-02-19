using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineHistoryVIMO;
using Animal_Health_System.PL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class VaccineHistoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<VaccineHistoryController> logger;

        public VaccineHistoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<VaccineHistoryController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var vaccineHistories = await unitOfWork.vaccineHistoryRepository.GetAllAsync();
                var vaccineHistoryVMs = mapper.Map<IEnumerable<VaccineHistoryVM>>(vaccineHistories);
                return View(vaccineHistoryVMs);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error loading vaccine history data.");
                return View("Error", new ErrorViewModel { Message = "Error loading vaccine history data." });
            }
        }

        // GET: Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new VaccineHistoryFormVM();
            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VaccineHistoryFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);  // تأكد من إعادة ملء الـ dropdowns في حالة فشل التحقق من صحة البيانات
                return View(vm);
            }

            try
            {
                var vaccineHistory = mapper.Map<VaccineHistory>(vm);
                vaccineHistory.AdministrationDate = vm.AdministrationDate.GetValueOrDefault(vaccineHistory.AdministrationDate);

                await unitOfWork.vaccineHistoryRepository.AddAsync(vaccineHistory);
                await unitOfWork.vaccineHistoryRepository.SaveChangesAsync();

                TempData["SuccessMessage"] = "Vaccine history added successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating vaccine history.");
                TempData["ErrorMessage"] = "An error occurred while creating vaccine history.";
                await PopulateDropdowns(vm);  // إعادة ملء الـ dropdowns في حالة الخطأ
                return View(vm);
            }
        }


        // GET: Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vaccineHistory = await unitOfWork.vaccineHistoryRepository.GetAsync(id);
            if (vaccineHistory == null)
            {
                TempData["ErrorMessage"] = "Vaccine history not found.";
                return RedirectToAction(nameof(Index));
            }

            var vm = mapper.Map<VaccineHistoryFormVM>(vaccineHistory);
            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VaccineHistoryFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);
                return View(vm);
            }

            try
            {
                var vaccineHistory = await unitOfWork.vaccineHistoryRepository.GetAsync(vm.Id);
                if (vaccineHistory == null)
                {
                    TempData["ErrorMessage"] = "Vaccine history not found.";
                    return RedirectToAction(nameof(Index));
                }

                mapper.Map(vm, vaccineHistory);
                vaccineHistory.AdministrationDate = vm.AdministrationDate.GetValueOrDefault(vaccineHistory.AdministrationDate);

                await unitOfWork.vaccineHistoryRepository.UpdateAsync(vaccineHistory);
                TempData["SuccessMessage"] = "Vaccine history updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating vaccine history.");
                TempData["ErrorMessage"] = "An error occurred while updating vaccine history.";
                await PopulateDropdowns(vm);
                return View(vm);
            }
        }

        // GET: Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var vaccineHistory = await unitOfWork.vaccineHistoryRepository.GetAsync(id);
                if (vaccineHistory == null)
                {
                    TempData["ErrorMessage"] = "Vaccine history not found.";
                    return RedirectToAction(nameof(Index));
                }

                var vaccineHistoryDetailsVM = mapper.Map<VaccineHistoryDetailsVM>(vaccineHistory);
                return View(vaccineHistoryDetailsVM);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving vaccine history details.");
                TempData["ErrorMessage"] = "An error occurred while fetching vaccine history details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: DeleteConfirmed
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var vaccineHistory = await unitOfWork.vaccineHistoryRepository.GetAsync(id);
                if (vaccineHistory == null)
                {
                    TempData["ErrorMessage"] = "Vaccine history not found.";
                    return RedirectToAction(nameof(Index));
                }

                await unitOfWork.vaccineHistoryRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Vaccine history deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the vaccine history.");
                TempData["ErrorMessage"] = "An error occurred while deleting the vaccine history.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Helper method to populate dropdown lists
        private async Task PopulateDropdowns(VaccineHistoryFormVM vm)
        {
            try
            {
                // التأكد من استرجاع البيانات من المستودع وإضافتها إلى القوائم
                vm.Veterinarians = (await unitOfWork.veterinarianRepository.GetAllAsync())
                    .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.FullName }).ToList();

                vm.Farms = (await unitOfWork.farmRepository.GetAllAsync())
                    .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name }).ToList();

                vm.Vaccines = (await unitOfWork.vaccineRepository.GetAllAsync())
                    .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();

                if (vm.FarmId > 0)
                {
                    // إذا كانت المزرعة محددة، استرجاع الحيوانات الخاصة بها
                    vm.Animals = (await unitOfWork.vaccineHistoryRepository.GetAnimalsByFarmIdAsync(vm.FarmId))
                        .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
                }
                else
                {
                    vm.Animals = new List<SelectListItem>(); // قائمة فارغة إذا لم يتم تحديد مزرعة
                }

                if (vm.AnimalId > 0)
                {
                    // إذا كان الحيوان محددًا، استرجاع السجلات الطبية الخاصة به
                    vm.MedicalRecords = (await unitOfWork.vaccineHistoryRepository.GetMedicalRecordsByAnimalIdAsync(vm.AnimalId))
                        .Select(mr => new SelectListItem { Value = mr.Id.ToString(), Text = mr.Name }).ToList();
                }
                else
                {
                    vm.MedicalRecords = new List<SelectListItem>(); // قائمة فارغة إذا لم يتم تحديد حيوان
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while populating dropdowns.");
                throw;
            }
        }
    
        // GET: GetAnimalsByFarm (AJAX)
        [HttpGet]
        public async Task<IActionResult> GetAnimalsByFarm(int farmId)
        {
            try
            {
                if (farmId > 0)
                {
                    var animals = await unitOfWork.vaccineHistoryRepository.GetAnimalsByFarmIdAsync(farmId);
                    var animalList = animals.Select(a => new { value = a.Id, text = a.Name }).ToList();
                    return Json(animalList);
                }
                return Json(new List<object>());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while getting animals by farm.");
                return Json(new List<object>());
            }
        }

        // GET: GetMedicalRecordsByAnimal (AJAX)
        [HttpGet]
        public async Task<IActionResult> GetMedicalRecordsByAnimal(int animalId)
        {
            try
            {
                if (animalId > 0)
                {
                    var medicalRecords = await unitOfWork.vaccineHistoryRepository.GetMedicalRecordsByAnimalIdAsync(animalId);
                    var medicalRecordList = medicalRecords.Select(mr => new { value = mr.Id, text = mr.Name }).ToList();
                    return Json(medicalRecordList);
                }
                return Json(new { success = false, message = "Invalid animalId" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while getting medical records by animal.");
                return Json(new { success = false, message = "An error occurred" });
            }
        }
    }
}
