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
        private readonly IVaccineRepository vaccineRepository;
        private readonly IMapper mapper;
        private readonly IVeterinarianRepository veterinarianRepository;
        private readonly IMedicalRecordRepository medicalRecordRepository;

        public VaccineController(IVaccineRepository vaccineRepository, IMapper mapper, IVeterinarianRepository veterinarianRepository, IMedicalRecordRepository medicalRecordRepository)
        {
            this.vaccineRepository = vaccineRepository;
            this.mapper = mapper;
            this.veterinarianRepository = veterinarianRepository;
            this.medicalRecordRepository = medicalRecordRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var vaccines = await vaccineRepository.GetAllAsync();
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
                var veterinarians = await veterinarianRepository.GetAllAsync();
                var medicalRecords = await medicalRecordRepository.GetAllAsync();

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

                    await vaccineRepository.AddAsync(vaccine);
                    await vaccineRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                var veterinarians = await veterinarianRepository.GetAllAsync();
                var medicalRecords = await medicalRecordRepository.GetAllAsync();

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
                var vaccine = await vaccineRepository.GetAsync(id);
                if (vaccine == null)
                {
                    return NotFound();
                }

                var vm = mapper.Map<VaccineFormVM>(vaccine);
                var medicalRecords = await medicalRecordRepository.GetAllAsync();
                var veterinarians = await veterinarianRepository.GetAllAsync();

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
                var vaccine = await vaccineRepository.GetAsync(vm.Id);
                if (vaccine == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    mapper.Map(vm, vaccine);
                    await vaccineRepository.UpdateAsync(vaccine);
                    await vaccineRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                var medicalRecords = await medicalRecordRepository.GetAllAsync();
                var veterinarians = await veterinarianRepository.GetAllAsync();

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
                var vaccine = await vaccineRepository.GetAsync(id);
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
                var vaccine = await vaccineRepository.GetAsync(id);
                if (vaccine == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                await vaccineRepository.DeleteAsync(id);
                await vaccineRepository.SaveChangesAsync();
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
