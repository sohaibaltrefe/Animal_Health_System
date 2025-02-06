using Animal_Health_System.BLL.Interface;
using Animal_Health_System.BLL.Repository;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalExaminationVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MedicalExaminationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<MedicalExaminationController> logger;

        public MedicalExaminationController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MedicalExaminationController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var medicalExaminations = await unitOfWork.medicalExaminationRepository.GetAllAsync();
            var medicalExaminationVm = mapper.Map<IEnumerable<MedicalExaminationVM>>(medicalExaminations);
            return View(medicalExaminationVm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var medicalExamination = await unitOfWork.medicalExaminationRepository.GetAsync(id);
            if (medicalExamination == null)
                return NotFound();

            var viewModel = mapper.Map<MedicalExaminationDetailsVM>(medicalExamination);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CheckMedicalRecord(int animalId)
        {
            var medicalRecord = await unitOfWork.medicalRecordRepository.GetByAnimalIdAsync(animalId);

            if (medicalRecord != null)
            {
                return Json(new
                {
                    hasMedicalRecord = true,
                    medicalRecordId = medicalRecord.Id,
                    medicalRecordName = medicalRecord.Name
                });
            }
            else
            {
                return Json(new { hasMedicalRecord = false });
            }
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();
            var animals = await unitOfWork.animalRepository.GetAllAsync();
            var veterinarians = await unitOfWork. veterinarianRepository.GetAllAsync();
            var medications = await unitOfWork.medicationRepository.GetAllAsync();

            var vm = new MedicalExaminationFormVM
            {
                MedicalRecord = new SelectList(medicalRecords, "Id", "Name"),
                Animal = new SelectList(animals, "Id", "Name"),
                Veterinarian = new SelectList(veterinarians, "Id", "FullName"),
                SelectedMedications = new HashSet<int>()
            };

            ViewBag.Medications = new SelectList(medications, "Id", "Name");

            ViewBag.HasMedicalRecord = false;  // default value

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalExaminationFormVM vm)
        {
            if (ModelState.IsValid)
            {
                var animal = await unitOfWork.animalRepository.GetAsync(vm.AnimalId.Value);
                if (animal == null || !await unitOfWork.medicalRecordRepository.AnyAsync(r => r.AnimalId == animal.Id))
                {
                    ModelState.AddModelError("MedicalRecordId", "There is no medical record for this animal.");
                    var medications = await unitOfWork.medicationRepository.GetAllAsync();
                    ViewBag.Medications = new SelectList(medications, "Id", "Name");

                    // Update the ViewBag to indicate the absence of a medical record
                    ViewBag.HasMedicalRecord = false;
                    return View(vm);
                }

                var medicalExamination = mapper.Map<MedicalExamination>(vm);

                foreach (var medicationId in vm.SelectedMedications)
                {
                    var medication = await unitOfWork.medicationRepository.GetAsync(medicationId);
                    if (medication != null)
                    {
                        medicalExamination.Medications.Add(medication);
                    }
                }

                await unitOfWork.medicalExaminationRepository.AddAsync(medicalExamination);
                return RedirectToAction(nameof(Index));
            }

            var medicationsHashSet = await unitOfWork.medicationRepository.GetAllAsync();
            ViewBag.Medications = new SelectList(medicationsHashSet, "Id", "Name");

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var medicalExamination = await unitOfWork.medicalExaminationRepository.GetAsync(id);
            if (medicalExamination == null) return NotFound();

            var vm = mapper.Map<MedicalExaminationFormVM>(medicalExamination);

            var medicalRecords = await unitOfWork.medicalRecordRepository.GetAllAsync();
            var animals = await unitOfWork.animalRepository.GetAllAsync();
            var veterinarians = await unitOfWork. veterinarianRepository.GetAllAsync();
            var medications = await unitOfWork.medicationRepository.GetAllAsync();

            vm.MedicalRecord = new SelectList(medicalRecords, "Id", "Name", medicalExamination.MedicalRecordId);
            vm.Animal = new SelectList(animals, "Id", "Name", medicalExamination.AnimalId);
            vm.Veterinarian = new SelectList(veterinarians, "Id", "FullName", medicalExamination.VeterinarianId);
            vm.SelectedMedications = medicalExamination.Medications.Select(m => m.Id).ToHashSet();

            ViewBag.Medications = new SelectList(medications, "Id", "Name");

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalExaminationFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                var medicationsHashSet = await unitOfWork.medicationRepository.GetAllAsync();
                ViewBag.Medications = new SelectList(medicationsHashSet, "Id", "Name");
                return View(vm);
            }

            var animal = await unitOfWork.animalRepository.GetAsync(vm.AnimalId.Value);
            if (animal == null || !await unitOfWork.medicalRecordRepository.AnyAsync(r => r.AnimalId == animal.Id))
            {
                ModelState.AddModelError("MedicalRecordId", "There is no medical record for this animal.");
                var medicationsHashSet = await unitOfWork.medicationRepository.GetAllAsync();
                ViewBag.Medications = new SelectList(medicationsHashSet, "Id", "Name");
                return View(vm);
            }

            var medicalExamination = await unitOfWork.medicalExaminationRepository.GetAsync(vm.Id);
            if (medicalExamination == null) return NotFound();

            mapper.Map(vm, medicalExamination);

            medicalExamination.Medications.Clear();
            foreach (var medicationId in vm.SelectedMedications)
            {
                var medication = await unitOfWork.medicationRepository.GetAsync(medicationId);
                if (medication != null)
                {
                    medicalExamination.Medications.Add(medication);
                }
            }

            await unitOfWork.medicalExaminationRepository.UpdateAsync(medicalExamination);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalExamination = await unitOfWork.medicalExaminationRepository.GetAsync(id);
            if (medicalExamination == null)
            {
                return RedirectToAction(nameof(Index));
            }
            await unitOfWork.medicalExaminationRepository.DeleteAsync(id);
            return Ok(new { Message = "Medical Examination deleted successfully" });
        }
    }
}
