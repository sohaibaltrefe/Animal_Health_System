using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AnimalHealthHistoryController : Controller
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<AnimalHealthHistoryController> logger;

        public AnimalHealthHistoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AnimalHealthHistoryController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }




        public async Task<IActionResult> Index()
        {
            try
            {
                var animalHealthHistories = await unitOfWork.animalHealthHistoryRepository.GetAllAsync();
                if (animalHealthHistories == null || !animalHealthHistories.Any())
                {
                    ViewBag.Message = "There are no animal health history records currently available.";
                }

                var animalHealthHistoryVMs = mapper.Map<IEnumerable<AnimalHealthHistoryVM>>(animalHealthHistories);
                return View(animalHealthHistoryVMs);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching animal health histories.");
                TempData["ErrorMessage"] = "An error occurred while fetching animal health histories.";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var animals = await unitOfWork.animalRepository.GetAllAsync();
                var medicalrecords = await unitOfWork.medicalRecordRepository.GetAllAsync();

                if (animals == null || !animals.Any())
                {
                    TempData["ErrorMessage"] = "There are no animals in the system to add!";
                    return RedirectToAction("Index");
                }
                if (medicalrecords == null || !medicalrecords.Any())
                {
                    TempData["ErrorMessage"] = "There are no medical records in the system to add!";
                    return RedirectToAction("Index");
                }

                var eventTypes = Enum.GetValues(typeof(EventType)).Cast<EventType>()
                    .Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    }).ToList();

                var vm = new AnimalHealthHistoryFormVM
                {
                    Animals = new SelectList(animals, "Id", "Name"),
                    MedicalRecords = new SelectList(medicalrecords, "Id", "Name"),
                    EventTypes = eventTypes
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while preparing animal data for creation.");
                TempData["ErrorMessage"] = "An error occurred while preparing animal data.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalHealthHistoryFormVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var animal = await unitOfWork.animalRepository.GetAsync(vm.AnimalId.Value);
                    if (animal == null)
                    {
                        TempData["ErrorMessage"] = "The selected animal does not exist.";
                        return View(vm);
                    }

                    var medicalRecord = await unitOfWork.medicalRecordRepository.GetByAnimalIdAsync(vm.AnimalId.Value);
                    if (medicalRecord == null)
                    {
                        TempData["ErrorMessage"] = "No medical record found for the selected animal.";
                        return View(vm);
                    }

                    var animalHealthHistory = mapper.Map<AnimalHealthHistory>(vm);
                    await unitOfWork.animalHealthHistoryRepository.AddAsync(animalHealthHistory);

                    TempData["SuccessMessage"] = "Animal health history added successfully!";
                    return RedirectToAction(nameof(Index));
                }

                var animalsHashSet = await unitOfWork.animalRepository.GetAllAsync();
                var medicalRecordsHashSet = await unitOfWork.medicalRecordRepository.GetAllAsync();
                vm.Animals = new SelectList(animalsHashSet, "Id", "Name", vm.AnimalId);
                vm.MedicalRecords = new SelectList(medicalRecordsHashSet, "Id", "Name", vm.MedicalRecordiD);
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding the animal health history.");
                TempData["ErrorMessage"] = "An error occurred while adding the animal health history.";
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var animalHealthHistory = await unitOfWork.animalHealthHistoryRepository.GetAsync(id);
                if (animalHealthHistory == null)
                {
                    return NotFound("Record not found.");
                }

                var animals = await unitOfWork.animalRepository.GetAllAsync();
                var eventTypes = Enum.GetValues(typeof(EventType)).Cast<EventType>()
                    .Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    }).ToList();

                var vm = mapper.Map<AnimalHealthHistoryFormVM>(animalHealthHistory);
                vm.Animals = new SelectList(animals, "Id", "Name", animalHealthHistory.AnimalId);
                vm.EventTypes = eventTypes;  // Make sure to assign the event types

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while retrieving animal health history with ID: {id}");
                TempData["ErrorMessage"] = "An error occurred while retrieving animal health history.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnimalHealthHistoryFormVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var animalsHashSet = await unitOfWork.animalRepository.GetAllAsync();
                    var medicalRecordsHashSet = await unitOfWork.medicalRecordRepository.GetAllAsync();
                    vm.Animals = new SelectList(animalsHashSet, "Id", "Name", vm.AnimalId);
                    vm.MedicalRecords = new SelectList(medicalRecordsHashSet, "Id", "Name", vm.MedicalRecordiD);
                    return View(vm);
                }

                var animalHealthHistory = await unitOfWork.animalHealthHistoryRepository.GetAsync(vm.Id);
                if (animalHealthHistory == null)
                {
                    return NotFound("Record not found.");
                }

                var animal = await unitOfWork.animalRepository.GetAsync(vm.AnimalId.Value);
                if (animal == null)
                {
                    TempData["ErrorMessage"] = "The selected animal does not exist.";
                    return View(vm);
                }

                var medicalRecord = await unitOfWork.medicalRecordRepository.GetByAnimalIdAsync(vm.AnimalId.Value);
                if (medicalRecord == null)
                {
                    TempData["ErrorMessage"] = "No medical record found for the selected animal.";
                    return View(vm);
                }

                vm.MedicalRecordiD = medicalRecord.Id;

                animalHealthHistory = mapper.Map<AnimalHealthHistory>(vm);

                await unitOfWork.animalHealthHistoryRepository.UpdateAsync(animalHealthHistory);
                TempData["SuccessMessage"] = "Animal health history updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating the animal health history.");
                TempData["ErrorMessage"] = "An error occurred while updating the animal health history.";
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var animalHealthHistory = await unitOfWork.animalHealthHistoryRepository.GetAsync(id);
                if (animalHealthHistory == null)
                {
                    TempData["ErrorMessage"] = "Animal health history not found.";
                    return RedirectToAction("Index");
                }

                var viewModel = mapper.Map<AnimalHealthHistoryDetailsVM>(animalHealthHistory);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while fetching animal health history details for ID: {id}");
                TempData["ErrorMessage"] = "An error occurred while fetching the animal health history details.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await unitOfWork.animalHealthHistoryRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Animal health history deleted successfully!";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while deleting animal health history with ID: {id}");
                TempData["ErrorMessage"] = "An error occurred while deleting animal health history.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
