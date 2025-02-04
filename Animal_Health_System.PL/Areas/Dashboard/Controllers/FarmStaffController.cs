using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmStaffVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FarmStaffController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<FarmStaffController> logger;

        public FarmStaffController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FarmStaffController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        // Get all FarmStaff
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var farmStaffList = await unitOfWork.farmStaffRepository.GetAllAsync();
                var farmStaffVm = mapper.Map<IEnumerable<FarmStaffVM>>(farmStaffList);
                return View(farmStaffVm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching farm staff.");
                TempData["ErrorMessage"] = "An error occurred while loading the farm staff data.";
                return RedirectToAction("Index");
            }
        }

        // Create GET action
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var vm = new FarmStaffFormVM();
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while preparing the create view.");
                TempData["ErrorMessage"] = "An error occurred while preparing the form.";
                return RedirectToAction("Index");
            }
        }

        // Create POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmStaffFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
                return View(vm);
            }

            try
            {
                var farmStaff = mapper.Map<FarmStaff>(vm);
               
                await unitOfWork.farmStaffRepository.AddAsync(farmStaff);

                TempData["SuccessMessage"] = "Farm staff added successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding the farm staff.");
                TempData["ErrorMessage"] = "An error occurred while adding the farm staff.";
                return View(vm);
            }
        }

        // Edit GET action
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var farmStaff = await unitOfWork.farmStaffRepository.GetAsync(id);
                if (farmStaff == null)
                {
                    TempData["ErrorMessage"] = "Farm staff not found.";
                    return RedirectToAction("Index");
                }

                var vm = mapper.Map<FarmStaffFormVM>(farmStaff);
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while preparing the edit view.");
                TempData["ErrorMessage"] = "An error occurred while preparing the form.";
                return RedirectToAction("Index");
            }
        }

        // Edit POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FarmStaffFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
                return View(vm);
            }

            try
            {
                var farmStaff = await unitOfWork.farmStaffRepository.GetAsync(vm.Id);
                if (farmStaff == null)
                {
                    TempData["ErrorMessage"] = "Farm staff not found.";
                    return RedirectToAction("Index");
                }

                mapper.Map(vm, farmStaff);
 
                await unitOfWork.farmStaffRepository.UpdateAsync(farmStaff);

                TempData["SuccessMessage"] = "Farm staff updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating the farm staff.");
                TempData["ErrorMessage"] = "An error occurred while updating the farm staff.";
                return View(vm);
            }
        }

        // Soft delete FarmStaff
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await unitOfWork.farmStaffRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Farm staff deleted successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting farm staff.");
                TempData["ErrorMessage"] = "An error occurred while deleting the farm staff.";
                return RedirectToAction("Index");
            }
        }
    }
}
