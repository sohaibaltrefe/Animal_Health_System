using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IAnimalRepository animalRepository;
        private readonly IVeterinarianRepository veterinarianRepository;
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<AppointmentController> logger;

        public AppointmentController(IAppointmentRepository appointmentRepository,
                                     IAnimalRepository animalRepository,
                                     IVeterinarianRepository veterinarianRepository,
                                     IOwnerRepository ownerRepository,
                                     IMapper mapper,
                                     ILogger<AppointmentController> logger)
        {
            this.appointmentRepository = appointmentRepository;
            this.animalRepository = animalRepository;
            this.veterinarianRepository = veterinarianRepository;
            this.ownerRepository = ownerRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // Index Action - List all appointments
        public async Task<IActionResult> Index()
        {
            try
            {
                var appointments = await appointmentRepository.GetAllAsync();
                var appointmentsViewModel = mapper.Map<IEnumerable<AppointmentVM>>(appointments);
                return View(appointmentsViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching appointments.");
                TempData["ErrorMessage"] = "An error occurred while fetching the appointments.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Create Appointment - GET
        public async Task<IActionResult> Create()
        {
            try
            {
                var animals = await animalRepository.GetAllAsync();
                var veterinarians = await veterinarianRepository.GetAllAsync();
                var owners = await ownerRepository.GetAllAsync();

                var statusList = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

                var vm = new AppointmentFormVM
                {
                    Animal = new SelectList(animals, "Id", "Name"),
                    Veterinarian = new SelectList(veterinarians, "Id", "FullName"),
                    Owner = new SelectList(owners, "Id", "FullName"),
                    StatusList = new SelectList(statusList)
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while preparing the create page.");
                TempData["ErrorMessage"] = "An error occurred while preparing the create page.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Create Appointment - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentFormVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var appointment = mapper.Map<Appointment>(vm);
                    await appointmentRepository.AddAsync(appointment);
                    TempData["SuccessMessage"] = "Appointment created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while creating appointment.");
                    TempData["ErrorMessage"] = "An error occurred while creating the appointment.";
                    await PopulateSelectLists(vm); // Repopulate select lists in case of error
                    return View(vm);
                }
            }

            // Re-populate the SelectLists if validation fails
            await PopulateSelectLists(vm);
            return View(vm);
        }

        // Edit Appointment - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var appointment = await appointmentRepository.GetAsync(id);
                if (appointment == null)
                    return NotFound();

                var vm = mapper.Map<AppointmentFormVM>(appointment);

                var animals = await animalRepository.GetAllAsync();
                var veterinarians = await veterinarianRepository.GetAllAsync();
                var owners = await ownerRepository.GetAllAsync();

                var statusList = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

                vm.Animal = new SelectList(animals, "Id", "Name", appointment.AnimalId);
                vm.Veterinarian = new SelectList(veterinarians, "Id", "FullName", appointment.VeterinarianId);
                vm.Owner = new SelectList(owners, "Id", "FullName", appointment.OwnerId);
                vm.StatusList = new SelectList(statusList, "Value", "Text", vm.Status);

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching the appointment for editing.");
                TempData["ErrorMessage"] = "An error occurred while fetching the appointment.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Edit Appointment - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentFormVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var appointment = await appointmentRepository.GetAsync(id);
                    if (appointment == null)
                        return NotFound();

                    mapper.Map(vm, appointment);
                    await appointmentRepository.UpdateAsync(appointment);
                    TempData["SuccessMessage"] = "Appointment updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while updating the appointment.");
                    TempData["ErrorMessage"] = "An error occurred while updating the appointment.";
                    await PopulateSelectLists(vm); // Repopulate select lists in case of error
                    return View(vm);
                }
            }

            // Re-populate the SelectLists if validation fails
            await PopulateSelectLists(vm);
            return View(vm);
        }
        // Details Page - View appointment details
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var appointment = await appointmentRepository.GetAsync(id);
                if (appointment == null)
                    return NotFound();

                var vm = mapper.Map<AppointmentDetailsVM>(appointment);
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching appointment details.");
                TempData["ErrorMessage"] = "An error occurred while fetching the appointment details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Delete Appointment - POST
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var appointment = await appointmentRepository.GetAsync(id);
                if (appointment == null)
                {
                    TempData["ErrorMessage"] = "Appointment not found.";
                    return RedirectToAction(nameof(Index));
                }

                await appointmentRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Appointment deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting appointment.");
                TempData["ErrorMessage"] = "An error occurred while deleting the appointment.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Helper method to populate SelectLists for Animal, Veterinarian, Owner, and Status
        private async Task PopulateSelectLists(AppointmentFormVM vm)
        {
            var animals = await animalRepository.GetAllAsync();
            var veterinarians = await veterinarianRepository.GetAllAsync();
            var owners = await ownerRepository.GetAllAsync();

            var statusList = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>().ToList();

            vm.Animal = new SelectList(animals, "Id", "Name");
            vm.Veterinarian = new SelectList(veterinarians, "Id", "FullName");
            vm.Owner = new SelectList(owners, "Id", "FullName");
            vm.StatusList = new SelectList(statusList);
        }
    }
}
