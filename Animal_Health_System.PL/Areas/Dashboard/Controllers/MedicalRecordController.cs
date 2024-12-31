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
        private readonly IMedicalRecordRepository medicalRecordRepository;
        private readonly IAnimalRepository animalRepository;
        private readonly IMapper mapper;

        public MedicalRecordController(IMedicalRecordRepository medicalRecordRepository ,IAnimalRepository animalRepository, IMapper mapper)
        {
            this.medicalRecordRepository = medicalRecordRepository;
            this.animalRepository = animalRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var medicalRecords = await medicalRecordRepository.GetAllAsync();

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
            var animals = await animalRepository.GetAllAsync();
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
                var existingRecord = await medicalRecordRepository.AnyAsync(r => r.AnimalId == vm.AnimalId);
                if (existingRecord)
                {
                    ViewData["ErrorMessage"] = "This animal already has a medical record.";
                    var animals = await animalRepository.GetAllAsync();
                    vm.Animal = new SelectList(animals, "Id", "Name");
                    return View(vm);
                }

                // Create the medical record
                var medicalRecord = mapper.Map<MedicalRecord>(vm);
                medicalRecord.AnimalId = vm.AnimalId.Value;

                await medicalRecordRepository.AddAsync(medicalRecord);

                // Assign MedicalRecordId to Animal
                var animal = await animalRepository.GetAsync(vm.AnimalId.Value);
                if (animal != null)
                {
                    animal.MedicalRecordId = medicalRecord.Id;
                    await animalRepository.UpdateAsync(animal);
                }

                await animalRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var animalsList = await animalRepository.GetAllAsync();
            vm.Animal = new SelectList(animalsList, "Id", "Name");
            return View(vm);
        }

        // GET: Dashboard/MedicalRecord/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var medicalRecord = await medicalRecordRepository.GetAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            var vm = mapper.Map<MedicalRecordFormVM>(medicalRecord);
            var animals = await animalRepository.GetAllAsync();
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
                var medicalRecord = await medicalRecordRepository.GetAsync(vm.Id);
                if (medicalRecord == null)
                {
                    return NotFound();
                }

                medicalRecord.Name = vm.Name;
                medicalRecord.IsDeleted = vm.IsDeleted;
                medicalRecord.AnimalId = vm.AnimalId.Value;

                await medicalRecordRepository.UpdateAsync(medicalRecord);

                var animal = await animalRepository.GetAsync(vm.AnimalId.Value);
                if (animal != null)
                {
                    animal.MedicalRecordId = medicalRecord.Id;
                    await animalRepository.UpdateAsync(animal);
                }

                await animalRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var animals = await animalRepository.GetAllAsync();
            vm.Animal = new SelectList(animals, "Id", "Name", vm.AnimalId);
            return View(vm);
        }


        // GET: Dashboard/MedicalRecord/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medicalRecord = await medicalRecordRepository.GetAsync(id);
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
            var medicalRecord = await medicalRecordRepository.GetAsync(id);
            if (medicalRecord == null)
            {
                return RedirectToAction(nameof(Index));
            }

            await medicalRecordRepository.DeleteAsync(id);
            return Ok(new { Message = "MedicalRecord deleted" });
        }
    }
}
