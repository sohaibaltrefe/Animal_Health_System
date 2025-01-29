using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Animal_Health_System.BLL.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository animalRepository;
        private readonly IMapper mapper;
        private readonly IFarmRepository farmRepository;
        private readonly ILogger<AnimalController> logger;

        public AnimalController(IAnimalRepository animalRepository, IMapper mapper, IFarmRepository farmRepository, ILogger<AnimalController> logger)
        {
            this.animalRepository = animalRepository;
            this.mapper = mapper;
            this.farmRepository = farmRepository;
            this.logger = logger;
        }

        // Get all animals
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var animals = await animalRepository.GetAllAsync();
                var animalVm = mapper.Map<IEnumerable<AnimalVM>>(animals);
                return View(animalVm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching animals.");
                TempData["ErrorMessage"] = "An error occurred while loading the animal data.";
                return RedirectToAction("Index");
            }
        }

       
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                // Fetching all farms
                var farms = await farmRepository.GetAllAsync();

                // Prepare the view model and populate the farms dropdown
                var vm = new AnimalFormVM
                {
                    Farms = new SelectList(farms, "Id", "Name")
                };

                // Return the view with the prepared view model
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while preparing the create view.");
                TempData["ErrorMessage"] = "An error occurred while preparing the form.";
                return RedirectToAction("Index");
            }
        }

        // Create Animal (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
                return View(vm);
            }

            try
            {
                // Mapping the view model to the animal entity
                var animal = mapper.Map<Animal>(vm);


                animal.CreatedAt = DateTime.Now;
                animal.UpdatedAt = DateTime.Now;

                // Add the animal to the database
                await animalRepository.AddAsync(animal);

                // Success message
                TempData["SuccessMessage"] = "Animal added successfully.";

                // Redirect to the Index action
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding the animal.");
                TempData["ErrorMessage"] = "An error occurred while adding the animal.";
                return View(vm);
            }
        }

        // Edit Animal (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                // Fetch the animal by ID
                var animal = await animalRepository.GetAsync(id);

                if (animal == null)
                {
                    TempData["ErrorMessage"] = "Animal not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Fetch all farms for the dropdown
                var farms = await farmRepository.GetAllAsync();

                // Mapping the animal entity to the view model
                var vm = mapper.Map<AnimalFormVM>(animal);

                // Prepare the farms dropdown and set the selected farm
                vm.Farms = new SelectList(farms, "Id", "Name", animal.FarmId);

                // Return the view with the populated view model
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while preparing the edit view.");
                TempData["ErrorMessage"] = "An error occurred while preparing the form.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Edit Animal (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnimalFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
                return View(vm);
            }

            try
            {
                // Fetch the animal by ID
                var animal = await animalRepository.GetAsync(vm.Id);

                if (animal == null)
                {
                    TempData["ErrorMessage"] = "Animal not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Mapping the updated view model to the animal entity
                mapper.Map(vm, animal);

                // Set UpdatedAt timestamp
                animal.UpdatedAt = DateTime.Now;

                // Update the animal in the database
                await animalRepository.UpdateAsync(animal);

                // Success message
                TempData["SuccessMessage"] = "Animal updated successfully.";

                // Redirect to the Index action
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating the animal.");
                TempData["ErrorMessage"] = "An error occurred while updating the animal.";
                return View(vm);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var animal = await animalRepository.GetAsync(id);
                if (animal == null)
                {
                    TempData["ErrorMessage"] = "Animal not found.";
                    return RedirectToAction(nameof(Index));
                }

                var animalVm = mapper.Map<AnimalDetailsVM>(animal);
                return View(animalVm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving animal details.");
                TempData["ErrorMessage"] = "An error occurred while fetching animal details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Soft delete animal
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var animal = await animalRepository.GetAsync(id);
                if (animal == null)
                {
                    return Json(new { success = false, message = "Animal not found." });
                }

                await animalRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Animal deleted successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting the animal.");
                return Json(new { success = false, message = "An error occurred while deleting the animal." });
            }
        }
    }
}
