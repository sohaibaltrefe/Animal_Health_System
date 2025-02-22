using Animal_Health_System.BLL.Interface;
using Animal_Health_System.BLL.Repository;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmHealthSummaryVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class FarmHealthSummaryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<FarmHealthSummaryController> logger;

        public FarmHealthSummaryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FarmHealthSummaryController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var farmHealthSummary = await   unitOfWork.farmHealthSummaryRepository.GetAllAsync();
            var farmHealthSummaryVm = mapper.Map<IEnumerable<FarmHealthSummaryVM>>(farmHealthSummary);
            return View(farmHealthSummaryVm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var farms = await unitOfWork.farmRepository.GetAllAsync();
            var vm = new FarmHealthSummaryFormVM
            {
                Farms = new SelectList(farms, "Id", "Name")
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmHealthSummaryFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);

            }
            var farmHealthSummary = mapper.Map<FarmHealthSummary>(vm);
            // Calculate and set the age
            await unitOfWork.farmHealthSummaryRepository.AddAsync(farmHealthSummary);
            await unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var farmHealthSummary = await unitOfWork.farmHealthSummaryRepository.GetAsync(id);
            if (farmHealthSummary == null)
            {
                return NotFound();
            }
            var farms = await unitOfWork.farmRepository.GetAllAsync();
            var vm = mapper.Map<FarmHealthSummaryFormVM>(farmHealthSummary);
            vm.Farms = new SelectList(farms, "Id", "Name", farmHealthSummary.FarmId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FarmHealthSummaryFormVM VM)
        {
            var farmHealthSummary = await unitOfWork.farmHealthSummaryRepository.GetAsync(VM.Id);
            if (farmHealthSummary == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var farms = await unitOfWork.farmRepository.GetAllAsync();
                VM.Farms = new SelectList(farms, "Id", "Name", VM.FarmId);
                return View(VM);
            }


            mapper.Map(VM, farmHealthSummary);

            farmHealthSummary.FarmId = (int)VM.FarmId;


            await unitOfWork.farmHealthSummaryRepository.UpdateAsync(farmHealthSummary);
            await unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));



        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var farmHealthSummary = await unitOfWork.farmHealthSummaryRepository.GetAsync(id);
            if (farmHealthSummary == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<FarmHealthSummaryDetailsVM>(farmHealthSummary);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmHealthSummary = await unitOfWork.farmHealthSummaryRepository.GetAsync(id);
            if (farmHealthSummary == null)
            {
                return Json(new { success = false, message = "farm Health Summary not found." });
            }
            await unitOfWork.farmHealthSummaryRepository.DeleteAsync(id);
            return Json(new { success = true });
        }
    }

}
