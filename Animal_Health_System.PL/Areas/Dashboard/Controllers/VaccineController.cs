using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class VaccineController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<VaccineController> logger;

        public VaccineController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<VaccineController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var vaccines = await unitOfWork.vaccineRepository.GetAllAsync();
                var vaccineVm = mapper.Map<IEnumerable<VaccineVM>>(vaccines);
                return View(vaccineVm);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error page or message
                TempData["Error"] = "An error occurred while fetching vaccines: " + ex.Message;
                return RedirectToAction("Error", "Home"); // Redirect to an error page
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var veterinarians = await unitOfWork.veterinarianRepository.GetAllAsync();
                var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();

                var vm = new VaccineFormVM
                {
                    MedicalRecords = new SelectList(medicalRecords, "Id", "Name"),
                    Veterinarians = new SelectList(veterinarians, "Id", "FullName")
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                TempData["Error"] = "An error occurred while preparing the vaccine creation form: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VaccineFormVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var vaccine = mapper.Map<Vaccine>(vm);

                    await unitOfWork.vaccineRepository.AddAsync(vaccine);
                    await unitOfWork.vaccineRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                var veterinarians = await unitOfWork.veterinarianRepository.GetAllAsync();
                var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();

                vm.MedicalRecords = new SelectList(medicalRecords, "Id", "Name");
                vm.Veterinarians = new SelectList(veterinarians, "Id", "FullName");
                return View(vm);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                TempData["Error"] = "An error occurred while creating the vaccine: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var vaccine = await unitOfWork.vaccineRepository.GetAsync(id);
                if (vaccine == null)
                {
                    return NotFound();
                }

                var vm = mapper.Map<VaccineFormVM>(vaccine);
                var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();
                var veterinarians = await unitOfWork.veterinarianRepository.GetAllAsync();

                vm.MedicalRecords = new SelectList(medicalRecords, "Id", "Name");
                vm.Veterinarians = new SelectList(veterinarians, "Id", "FullName");

                return View(vm);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                TempData["Error"] = "An error occurred while editing the vaccine: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VaccineFormVM vm)
        {
            try
            {
                var vaccine = await unitOfWork.vaccineRepository.GetAsync(vm.Id);
                if (vaccine == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    mapper.Map(vm, vaccine);
                    await unitOfWork.vaccineRepository.UpdateAsync(vaccine);
                    await unitOfWork.vaccineRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();
                var veterinarians = await unitOfWork.veterinarianRepository.GetAllAsync();

                vm.MedicalRecords = new SelectList(medicalRecords, "Id", "Name");
                vm.Veterinarians = new SelectList(veterinarians, "Id", "FullName");
                return View(vm);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                TempData["Error"] = "An error occurred while updating the vaccine: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var vaccine = await unitOfWork.vaccineRepository.GetAsync(id);
                if (vaccine == null)
                {
                    return NotFound();
                }

                var viewModel = mapper.Map<VaccineDetailsVM>(vaccine);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                TempData["Error"] = "An error occurred while fetching vaccine details: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var vaccine = await unitOfWork.vaccineRepository.GetAsync(id);
                if (vaccine == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                await unitOfWork.vaccineRepository.DeleteAsync(id);
                await unitOfWork.vaccineRepository.SaveChangesAsync();
                return Ok(new { Message = "Vaccine deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                TempData["Error"] = "An error occurred while deleting the vaccine: " + ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
