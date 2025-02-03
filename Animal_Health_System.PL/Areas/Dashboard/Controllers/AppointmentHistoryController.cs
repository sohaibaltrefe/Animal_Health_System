using Animal_Health_System.BLL.Interface;
using Animal_Health_System.BLL.Repository;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentHistoryVIMO;
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
    public class AppointmentHistoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<AppointmentHistoryController> logger;

        public AppointmentHistoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AppointmentHistoryController> logger)
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
                var appointments = await unitOfWork.appointmentRepository.GetAllAsync();
                bool hasAppointments = appointments != null && appointments.Any();

                if (!hasAppointments)
                {
                    TempData["NoAppointments"] = "There are no reservations currently. Please add a new reservation";
                }

                var appointmentHistories = await unitOfWork.appointmentHistoryRepository.GetAllAsync();
                var appointmentHistoriesVm = mapper.Map<IEnumerable<AppointmentHistoryVM>>(appointmentHistories);
                return View(appointmentHistoriesVm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving appointment history.");
                TempData["Error"] = "An error occurred while retrieving the appointment history.";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var appointments = await unitOfWork.appointmentRepository.GetAllAsync();
                if (appointments == null || !appointments.Any())
                {
                    ModelState.AddModelError("", "No appointments available. Please add an appointment first.");
                    return View();
                }

                var viewModel = new AppointmentHistoryFormVM
                {
                    Appointment = new SelectList(appointments, "Id", "Name")
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while loading the create view.");
                ModelState.AddModelError("", "An error occurred while loading the create view.");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentHistoryFormVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var appointments = await unitOfWork.appointmentRepository.GetAllAsync();
                    vm.Appointment = new SelectList(appointments, "Id", "Name", vm.AppointmentId);
                    return View(vm);
                }

                var appointment = await unitOfWork.appointmentRepository.GetAsync((int)vm.AppointmentId);
                if (appointment == null)
                {
                    ModelState.AddModelError("", "Appointment not found.");
                    return View(vm);
                }

                vm.Status = appointment.AppointmentDate < DateTime.Now ? "Completed" : "Pending";
                var appointmentHistory = mapper.Map<AppointmentHistory>(vm);
                await unitOfWork.appointmentHistoryRepository.AddAsync(appointmentHistory);

                TempData["Success"] = "Appointment history added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating appointment history.");
                ModelState.AddModelError("", "An error occurred while creating the appointment history.");
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var appointmentHistory = await unitOfWork.appointmentHistoryRepository.GetAsync(id);
                if (appointmentHistory == null)
                {
                    return NotFound();
                }

                var appointments = await unitOfWork.appointmentRepository.GetAllAsync();
                var vm = mapper.Map<AppointmentHistoryFormVM>(appointmentHistory);
                vm.Appointment = new SelectList(appointments, "Id", "Name", appointmentHistory.AppointmentId);

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while loading the edit view.");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentHistoryFormVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var appointments = await unitOfWork.appointmentRepository.GetAllAsync();
                    vm.Appointment = new SelectList(appointments, "Id", "Name", vm.AppointmentId);
                    return View(vm);
                }

                var appointmentHistory = await unitOfWork.appointmentHistoryRepository.GetAsync(vm.Id);
                if (appointmentHistory == null)
                {
                    return NotFound();
                }

                var appointment = await unitOfWork.appointmentRepository.GetAsync((int)vm.AppointmentId);
                if (appointment == null)
                {
                    ModelState.AddModelError("", "Appointment not found.");
                    return View(vm);
                }

                vm.Status = appointment.AppointmentDate < DateTime.Now ? "Completed" : "Pending";
                mapper.Map(vm, appointmentHistory);

                await unitOfWork.appointmentHistoryRepository.UpdateAsync(appointmentHistory);

                TempData["Success"] = "Appointment history updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while editing appointment history.");
                ModelState.AddModelError("", "An error occurred while editing the appointment history.");
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var appointmentHistory = await unitOfWork.appointmentHistoryRepository.GetAsync(id);
                if (appointmentHistory == null)
                {
                    return NotFound();
                }

                var viewModel = mapper.Map<AppointmentHistoryDetailsVM>(appointmentHistory);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving appointment history details.");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var appointmentHistory = await unitOfWork.appointmentHistoryRepository.GetAsync(id);
                if (appointmentHistory == null)
                {
                    return Json(new { success = false, message = "Appointment history not found." });
                }

                await unitOfWork.appointmentHistoryRepository.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting appointment history.");
                return Json(new { success = false, message = "An error occurred while deleting the appointment history." });
            }
        }
    }
}
