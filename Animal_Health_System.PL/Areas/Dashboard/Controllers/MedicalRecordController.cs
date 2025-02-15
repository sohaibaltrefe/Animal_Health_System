using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalRecordVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MedicalRecordController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<MedicalRecordController> logger;

        public MedicalRecordController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MedicalRecordController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: Dashboard/MedicalRecord/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();
                foreach (var record in medicalRecords)
                {
                    logger.LogInformation(record.Animal?.Farm != null
                        ? $"Farm Name: {record.Animal.Farm.Name}"
                        : "No farm assigned to this animal.");
                }

                var medicalRecordVMs = mapper.Map<IEnumerable<MedicalRecordVM>>(medicalRecords);
                return View(medicalRecordVMs);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching medical records.");
                TempData["ErrorMessage"] = "An error occurred while retrieving records.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var farms = await unitOfWork.farmRepository.GetAllAsync();
                var model = new MedicalRecordFormVM
                {
                    Farm = new SelectList(farms, "Id", "Name"),
                    Animal = new SelectList(Enumerable.Empty<Animal>(), "Id", "Name")
                };

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while loading the create medical record form.");
                TempData["ErrorMessage"] = "An error occurred while loading the form.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Dashboard/MedicalRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Farm = new SelectList(await unitOfWork.farmRepository.GetAllAsync(), "Id", "Name");
                vm.Animal = new SelectList(await unitOfWork.animalRepository.GetAnimalsByFarmIdAsync(vm.FarmId), "Id", "Name");
                return View(vm);
            }

            try
            {
                var medicalRecord = mapper.Map<MedicalRecord>(vm);
                await unitOfWork.medicalRecordRepository.AddAsync(medicalRecord);

                TempData["SuccessMessage"] = "Medical record created successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating medical record.");
                TempData["ErrorMessage"] = "An error occurred while creating the record.";
                return View(vm);
            }
        }

        // GET: Dashboard/MedicalRecord/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(id);
                if (medicalRecord == null)
                {
                    TempData["ErrorMessage"] = "Medical record not found.";
                    return RedirectToAction(nameof(Index));
                }

                var vm = mapper.Map<MedicalRecordFormVM>(medicalRecord);
                vm.Farm = new SelectList(await unitOfWork.farmRepository.GetAllAsync(), "Id", "Name", vm.FarmId);
                vm.Animal = new SelectList(await unitOfWork.animalRepository.GetAnimalsByFarmIdAsync(vm.FarmId), "Id", "Name", vm.AnimalId);

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while loading the edit medical record form.");
                TempData["ErrorMessage"] = "An error occurred while loading the form.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Dashboard/MedicalRecord/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecordFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Farm = new SelectList(await unitOfWork.farmRepository.GetAllAsync(), "Id", "Name", vm.FarmId);
                vm.Animal = new SelectList(await unitOfWork.animalRepository.GetAnimalsByFarmIdAsync(vm.FarmId), "Id", "Name", vm.AnimalId);
                return View(vm);
            }

            try
            {
                var medicalRecord = mapper.Map<MedicalRecord>(vm);
                await unitOfWork.medicalRecordRepository.UpdateAsync(medicalRecord);

                TempData["SuccessMessage"] = "Medical record updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating medical record.");
                TempData["ErrorMessage"] = "An error occurred while updating the record.";
                return View(vm);
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetAnimalsByFarm(int farmId)
        {
            try
            {
                var animals = await unitOfWork.animalRepository.GetAnimalsByFarmIdAsync(farmId);
                return Json(animals.Select(a => new { a.Id, a.Name }));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching animals for the selected farm.");
                return Json(new { error = "Failed to load animals." });
            }
        }
        // GET: Dashboard/MedicalRecord/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(id);
                if (medicalRecord == null)
                {
                    TempData["ErrorMessage"] = "Medical record not found.";
                    return RedirectToAction(nameof(Index));
                }

                var medicalRecordModel = mapper.Map<MedicalRecordDetailsVM>(medicalRecord);
                return View(medicalRecordModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while retrieving details for medical record ID {id}");
                TempData["ErrorMessage"] = "An error occurred while retrieving record details.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(id);
                if (medicalRecord == null)
                {
                    TempData["ErrorMessage"] = "Medical record not found.";
                    return RedirectToAction(nameof(Index));
                }

                await unitOfWork.medicalRecordRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Medical record deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting the medical record.");
                TempData["ErrorMessage"] = "An error occurred while deleting the record.";
                return RedirectToAction(nameof(Index));
            }
        }

       

    }
}
