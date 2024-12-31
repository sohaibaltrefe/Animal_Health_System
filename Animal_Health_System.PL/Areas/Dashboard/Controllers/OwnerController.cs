using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.OwnerVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<OwnerController> logger;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper, ILogger<OwnerController> logger)
        {
            this.ownerRepository = ownerRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // List all owners
        public async Task<IActionResult> Index()
        {
            try
            {
                var owners = await ownerRepository.GetAllAsync();
                var ownerModels = mapper.Map<IEnumerable<OwnerVM>>(owners);
                return View(ownerModels);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching owners.");
                TempData["ErrorMessage"] = "An error occurred while fetching the owners.";
                return View(new List<OwnerVM>());
            }
        }

        // Show create page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save new owner
        [HttpPost]
        public async Task<IActionResult> Create(OwnerFormVM ownerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Please check the entered data.";
                    return View(ownerVM);
                }

                var owner = mapper.Map<Owner>(ownerVM);
                await ownerRepository.AddAsync(owner);

                TempData["SuccessMessage"] = "Owner added successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating the owner.");
                TempData["ErrorMessage"] = "An error occurred while creating the owner.";
                return View(ownerVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var owner = await ownerRepository.GetAsync(id);
                if (owner == null)
                {
                    TempData["ErrorMessage"] = "Owner not found.";
                    return RedirectToAction("Index");
                }

                var ownerVM = mapper.Map<OwnerFormVM>(owner);
                return View(ownerVM);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while fetching the owner with ID {id}.");
                TempData["ErrorMessage"] = "An error occurred while fetching the owner.";
                return RedirectToAction("Index");
            }
        }

        // Save updates
        [HttpPost]
        public async Task<IActionResult> Edit(OwnerFormVM ownerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Please check the entered data.";
                    return View(ownerVM);
                }

                var owner = await ownerRepository.GetAsync(ownerVM.Id);
                if (owner == null)
                {
                    TempData["ErrorMessage"] = "Owner not found.";
                    logger.LogWarning($"Owner with ID {ownerVM.Id} not found.");
                    return RedirectToAction("Index");
                }

                // Update fields
                owner.FullName = ownerVM.FullName;
                owner.PhoneNumber = ownerVM.PhoneNumber;
                owner.Email = ownerVM.Email;
                owner.IsDeleted = ownerVM.IsDeleted;

                await ownerRepository.UpdateAsync(owner);

                TempData["SuccessMessage"] = "Owner updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating the owner.");
                TempData["ErrorMessage"] = "An error occurred while updating the owner.";
                return View(ownerVM);
            }
        }

        // Show owner details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var owner = await ownerRepository.GetAsync(id);
                if (owner == null)
                {
                    TempData["ErrorMessage"] = "Owner not found.";
                    return RedirectToAction("Index");
                }

                var ownerModel = mapper.Map<OwnerDetailsVM>(owner);
                return View(ownerModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while fetching details for owner ID {id}.");
                TempData["ErrorMessage"] = "An error occurred while fetching the owner's details.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var owner = await ownerRepository.GetAsync(id);
                if (owner == null || owner.IsDeleted)
                {
                    TempData["ErrorMessage"] = "Owner not found or already deleted.";
                    logger.LogWarning($"Owner with ID {id} not found or already deleted.");
                    return RedirectToAction(nameof(Index));
                }

                await ownerRepository.DeleteAsync(id);

                TempData["SuccessMessage"] = "Owner deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting the owner.");
                TempData["ErrorMessage"] = "An error occurred while deleting the owner.";
                return RedirectToAction("Index");
            }
        }
    }
}
