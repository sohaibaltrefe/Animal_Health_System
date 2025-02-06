using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VeterinarianVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class VeterinarianController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<VeterinarianController> logger;

        public VeterinarianController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<VeterinarianController> logger)
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
                var veterinarians = await unitOfWork.veterinarianRepository.GetAllAsync();
                var veterinarianVm = mapper.Map<IEnumerable<VeterinarianVM>>(veterinarians);
                return View(veterinarianVm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching veterinarians.");
                TempData["ErrorMessage"] = "An error occurred while fetching veterinarians. Please try again later.";
                return View(new HashSet<VeterinarianVM>());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VeterinarianFormVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var veterinarian = mapper.Map<Veterinarian>(vm);
                    await unitOfWork.veterinarianRepository.AddAsync(veterinarian);
                    TempData["SuccessMessage"] = "Veterinarian created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating veterinarian.");
                TempData["ErrorMessage"] = "An error occurred while creating the veterinarian. Please try again later.";
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var veterinarian = await unitOfWork.veterinarianRepository.GetAsync(id);
                if (veterinarian == null)
                {
                    return NotFound();
                }
                var veterinarianVm = mapper.Map<VeterinarianFormVM>(veterinarian);
                return View(veterinarianVm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching veterinarian for editing.");
                TempData["ErrorMessage"] = "An error occurred while fetching veterinarian details. Please try again later.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VeterinarianFormVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var veterinarian = await unitOfWork.veterinarianRepository.GetAsync(vm.Id);
                    if (veterinarian == null)
                    {
                        return NotFound();
                    }
                    mapper.Map(vm, veterinarian);
                    await unitOfWork.veterinarianRepository.UpdateAsync(veterinarian);
                    TempData["SuccessMessage"] = "Veterinarian updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating veterinarian.");
                TempData["ErrorMessage"] = "An error occurred while updating the veterinarian. Please try again later.";
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var veterinarian = await unitOfWork.veterinarianRepository.GetAsync(id);
                if (veterinarian == null)
                {
                    return NotFound();
                }
                var veterinarianModel = mapper.Map<VeterinarianDetailsVM>(veterinarian);
                return View(veterinarianModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching veterinarian details.");
                TempData["ErrorMessage"] = "An error occurred while fetching veterinarian details. Please try again later.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var veterinarian = await unitOfWork.veterinarianRepository.GetAsync(id);
                if (veterinarian == null)
                {
                    return NotFound();
                }

                await unitOfWork.veterinarianRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = "Veterinarian deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting veterinarian.");
                TempData["ErrorMessage"] = "An error occurred while deleting the veterinarian. Please try again later.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
