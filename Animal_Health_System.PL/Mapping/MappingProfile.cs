using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmStaffVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.OwnerVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VeterinarianVIMO;
using AutoMapper;


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

        }
    }
}
