using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmStaffVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalExaminationVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalRecordVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.OwnerVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VeterinarianVIMO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Animal_Health_System.PL.Mapping
{
    public class MappingProfile:Profile
    {
        
        public MappingProfile()
        {
            //************  Animal  ***************
            CreateMap<Animal, AnimalVM>().ReverseMap();
            CreateMap<AnimalFormVM, Animal>().ReverseMap();
            CreateMap<Animal, AnimalDetailsVM>().ReverseMap();
            // ************ AnimalHealthHistory ***********
            CreateMap<AnimalHealthHistory, AnimalHealthHistoryVM>()
           .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.Animal.Name))
           .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.ToString()));

            CreateMap<AnimalHealthHistory, AnimalHealthHistoryDetailsVM>()
                .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.Animal.Name))
                .ForMember(dest => dest.MedicalRecordName, opt => opt.MapFrom(src => src.MedicalRecord .Name));

            CreateMap<AnimalHealthHistoryFormVM, AnimalHealthHistory>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType));

            CreateMap<AnimalHealthHistory, AnimalHealthHistoryFormVM>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType));

            //************  Farm  ***************
            CreateMap<Farm, FarmVM>()
      
      .ReverseMap();

            CreateMap<Farm, FarmDetailsVM>()
              
                .ReverseMap();

            CreateMap<FarmFormVM, Farm>().ReverseMap();
            //************  Appointment  ***************
            CreateMap<Appointment, AppointmentVM>().ReverseMap();
            CreateMap<AppointmentVM, Appointment>().ReverseMap();
            CreateMap<Appointment, AppointmentVM>().ReverseMap();

            //************  AppointmentHistory  ***************
            CreateMap<AppointmentHistory, AppointmentHistoryVM>().ReverseMap();
            CreateMap<AppointmentHistoryVM, AppointmentHistory>().ReverseMap();
            CreateMap<AppointmentHistory, AppointmentHistoryVM>().ReverseMap();

            //************  FarmStaff  ***************

            CreateMap<FarmStaff, FarmStaffVM>().ReverseMap();
            CreateMap<FarmStaff, FarmStaffFormVM>().ReverseMap();
            CreateMap<FarmStaff, FarmStaffDetailsVM>().ReverseMap();

            // ************** Veterinarian ***********
            CreateMap<Veterinarian, VeterinarianDetailsVM>().ReverseMap();
            CreateMap<Veterinarian, VeterinarianFormVM>().ReverseMap();
            CreateMap<Veterinarian, VeterinarianVM>().ReverseMap();

            //Owner

            CreateMap<Owner, OwnerVM>().ReverseMap();
            CreateMap<OwnerFormVM, Owner>().ReverseMap();
            CreateMap<Owner, OwnerDetailsVM>().ReverseMap();
            //************  MedicalRecord  ***************

            CreateMap<MedicalRecordFormVM, MedicalRecord>()
    .ForMember(dest => dest.AnimalId, opt => opt.MapFrom(src => src.AnimalId.Value))
    .ReverseMap();
            CreateMap<MedicalRecord, MedicalRecordVM>()
                .ForMember(dest => dest.Farm, opt => opt.MapFrom(src => src.Animal.Farm));
CreateMap<MedicalRecord, MedicalRecordDetailsVM>()
    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
    .ReverseMap();
            //************  Medication  ***************

            CreateMap<Medication, MedicationVM>().ReverseMap();
            CreateMap<Medication, MedicationFormVM>().ReverseMap();
            CreateMap<Medication, MedicationDetailsVM>().ReverseMap();

            //************  Vaccine  ***************

            CreateMap<Vaccine, VaccineVM>().ReverseMap();
            CreateMap<Vaccine, VaccineFormVM>().ReverseMap();
            CreateMap<Vaccine, VaccineDetailsVM>().ReverseMap();

            //************  VaccineHistory  ***************

            CreateMap<VaccineHistory, VaccineHistoryVM>().ReverseMap();
            CreateMap<VaccineHistory, VaccineHistoryFormVM>().ReverseMap();
            CreateMap<VaccineHistory, VaccineHistoryDetailsVM>().ReverseMap();

            //************  MedicalExamination  ***************

            CreateMap<MedicalExamination, MedicalExaminationVM>().ReverseMap();

            CreateMap<MedicalExamination, MedicalExaminationFormVM>()
                .ForMember(dest => dest.Animal, opt => opt.Ignore()) // تجنب محاولة تحويل Animal إلى SelectList
                .ForMember(dest => dest.MedicalRecord, opt => opt.Ignore()) // نفس المشكلة مع MedicalRecord
                .ForMember(dest => dest.MedicationsList, opt => opt.Ignore()) // تجاهل SelectList الأخرى
                .ForMember(dest => dest.Veterinarian, opt => opt.Ignore())
                .ForMember(dest => dest.Farm, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<MedicalExamination, MedicalExaminationDetailsVM>()
                
                .ReverseMap();
        }
    }
}
