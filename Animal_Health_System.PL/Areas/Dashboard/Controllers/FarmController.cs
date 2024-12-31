using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FarmController : Controller
    {
        private readonly IFarmRepository farmRepository;
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper mapper;

        public FarmController(IFarmRepository farmRepository, IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.farmRepository = farmRepository;
            this.ownerRepository = ownerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var farms = await farmRepository.GetAllAsync();
            var farmVm = mapper.Map<IEnumerable<FarmVM>>(farms);
            return View(farmVm);
        }

        public async Task<IActionResult> Create()
        {
            var owners = await ownerRepository.GetAllAsync();
           

            var vm = new FarmFormVM
            {
                Owners = new SelectList(owners, "Id", "FullName")
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                            return View(vm);

            }

            var farm = mapper.Map<Farm>(vm);
            await farmRepository.AddAsync(farm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var farm = await farmRepository.GetAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            var owners = await ownerRepository.GetAllAsync();
            var vm = mapper.Map<FarmFormVM>(farm);
            vm.Owners = new SelectList(owners, "Id", "FullName", farm.OwnerId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FarmFormVM vm)
        { var farm = await farmRepository.GetAsync(vm.Id);
                if (farm == null)
                {
                    return NotFound();
                }
            if (!ModelState.IsValid)
            {
                var owners = await ownerRepository.GetAllAsync();
                vm.Owners = new SelectList(owners, "Id", "FullName", vm.OwnerId); 
                return View(vm);
            }
            mapper.Map(vm, farm);
            farm.OwnerId = (int)vm.OwnerId;
            await farmRepository.UpdateAsync(farm);
            return RedirectToAction(nameof(Index));
           

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var farm = await farmRepository.GetAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            var model = mapper.Map<FarmDetailsVM>(farm);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farm = await farmRepository.GetAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            await farmRepository.DeleteAsync(id);
            return Ok(new { Message = "Farm deleted successfully" });
        }
    }
}