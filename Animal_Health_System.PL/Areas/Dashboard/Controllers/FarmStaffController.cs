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
        private readonly IFarmStaffRepository _farmStaffRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FarmStaffController> _logger;

        public FarmStaffController(IFarmStaffRepository farmStaffRepository, IMapper mapper, ILogger<FarmStaffController> logger)
        {
            _farmStaffRepository = farmStaffRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // Get all FarmStaff
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var farmStaffList = await _farmStaffRepository.GetAllAsync();
                var farmStaffVm = _mapper.Map<IEnumerable<FarmStaffVM>>(farmStaffList);
                return View(farmStaffVm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching farm staff.");
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
                _logger.LogError(ex, "Error occurred while preparing the create view.");
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
                var farmStaff = _mapper.Map<FarmStaff>(vm);
               
                await _farmStaffRepository.AddAsync(farmStaff);

                TempData["SuccessMessage"] = "Farm staff added successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding the farm staff.");
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
                var farmStaff = await _farmStaffRepository.GetAsync(id);
                if (farmStaff == null)
                {
                    TempData["ErrorMessage"] = "Farm staff not found.";
                    return RedirectToAction("Index");
                }

                var vm = _mapper.Map<FarmStaffFormVM>(farmStaff);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while preparing the edit view.");
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
                var farmStaff = await _farmStaffRepository.GetAsync(vm.Id);
                if (farmStaff == null)
                {
                    TempData["ErrorMessage"] = "Farm staff not found.";
                    return RedirectToAction("Index");
                }

                _mapper.Map(vm, farmStaff);
 
                await _farmStaffRepository.UpdateAsync(farmStaff);

                TempData["SuccessMessage"] = "Farm staff updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the farm staff.");
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
                await _farmStaffRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Farm staff deleted successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting farm staff.");
                TempData["ErrorMessage"] = "An error occurred while deleting the farm staff.";
                return RedirectToAction("Index");
            }
        }
    }
}
