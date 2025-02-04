using Animal_Health_System.BLL.Interface;
using Animal_Health_System.BLL.Repository;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalRecordVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MedicalRecordController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<MedicalRecordController> logger;

        public MedicalRecordController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MedicalRecordController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();

            foreach (var record in medicalRecords)
            {
                if (record.Animal?.Farm != null)
                {
                    Console.WriteLine($"Farm Name: {record.Animal.Farm.Name}");
                }
                else
                {
                    Console.WriteLine("No farm assigned to this animal.");
                }
            }

            var medicalRecordVMs = mapper.Map<IEnumerable<MedicalRecordVM>>(medicalRecords);
            return View(medicalRecordVMs);
        }

        // GET: Dashboard/MedicalRecord/Create
       public async Task<IActionResult> Create()
        {
            var animals = await unitOfWork.animalRepository.GetAllAsync();
            var vm = new MedicalRecordFormVM
            {
                Animal = new SelectList(animals, "Id", "Name")
            };
            return View(vm);
        }

        // POST: Dashboard/MedicalRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordFormVM vm)
        {
            if (ModelState.IsValid)
            {
                // Check if the animal already has a medical record
                var existingRecord = await unitOfWork.medicalRecordRepository.AnyAsync(r => r.AnimalId == vm.AnimalId);
                if (existingRecord)
                {
                    ViewData["ErrorMessage"] = "This animal already has a medical record.";
                    var animals = await unitOfWork.animalRepository.GetAllAsync();
                    vm.Animal = new SelectList(animals, "Id", "Name");
                    return View(vm);
                }

                // Create the medical record
                var medicalRecord = mapper.Map<MedicalRecord>(vm);
                medicalRecord.AnimalId = vm.AnimalId.Value;

                await unitOfWork.medicalRecordRepository.AddAsync(medicalRecord);

                // Assign MedicalRecordId to Animal
                var animal = await unitOfWork.animalRepository.GetAsync(vm.AnimalId.Value);
                if (animal != null)
                {
                    animal.MedicalRecordId = medicalRecord.Id;
                    await unitOfWork.animalRepository.UpdateAsync(animal);
                }

                await unitOfWork.animalRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var animalsList = await unitOfWork.animalRepository.GetAllAsync();
            vm.Animal = new SelectList(animalsList, "Id", "Name");
            return View(vm);
        }

        // GET: Dashboard/MedicalRecord/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            var vm = mapper.Map<MedicalRecordFormVM>(medicalRecord);
            var animals = await unitOfWork.animalRepository.GetAllAsync();
            vm.Animal = new SelectList(animals, "Id", "Name", medicalRecord.AnimalId);

            return View(vm);
        }

        // POST: Dashboard/MedicalRecord/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecordFormVM vm)
        {
            if (ModelState.IsValid)
            {
                var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(vm.Id);
                if (medicalRecord == null)
                {
                    return NotFound();
                }

                medicalRecord.Name = vm.Name;
                medicalRecord.IsDeleted = vm.IsDeleted;
                medicalRecord.AnimalId = vm.AnimalId.Value;

                await unitOfWork.medicalRecordRepository.UpdateAsync(medicalRecord);

                var animal = await unitOfWork.animalRepository.GetAsync(vm.AnimalId.Value);
                if (animal != null)
                {
                    animal.MedicalRecordId = medicalRecord.Id;
                    await unitOfWork.animalRepository.UpdateAsync(animal);
                }

                await unitOfWork.animalRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var animals = await unitOfWork.animalRepository.GetAllAsync();
            vm.Animal = new SelectList(animals, "Id", "Name", vm.AnimalId);
            return View(vm);
        }


        // GET: Dashboard/MedicalRecord/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            var medicalRecordModel = mapper.Map<MedicalRecordDetailsVM>(medicalRecord);
            return View(medicalRecordModel);
        }

        // POST: Dashboard/MedicalRecord/DeleteConfirmed/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalRecord = await unitOfWork.medicalRecordRepository.GetAsync(id);
            if (medicalRecord == null)
            {
                return RedirectToAction(nameof(Index));
            }

            await unitOfWork.medicalRecordRepository.DeleteAsync(id);
            return Ok(new { Message = "MedicalRecord deleted" });
        }
    }
}
