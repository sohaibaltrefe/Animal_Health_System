using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
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
                .ForMember(dest => dest.MedicalRecordName, opt => opt.MapFrom(src => src.MedicalRecords.Name));

            CreateMap<AnimalHealthHistoryFormVM, AnimalHealthHistory>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType));

            CreateMap<AnimalHealthHistory, AnimalHealthHistoryFormVM>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType));

            //************  Appointment  ***************
            CreateMap<Appointment, AppointmentVM>().ReverseMap();
            CreateMap<AppointmentVM, Appointment>().ReverseMap();
            CreateMap<Appointment, AppointmentVM>().ReverseMap();

            //************  AppointmentHistory  ***************
            CreateMap<AppointmentHistory, AppointmentHistoryVM>().ReverseMap();
            CreateMap<AppointmentHistoryVM, AppointmentHistory>().ReverseMap();
            CreateMap<AppointmentHistory, AppointmentHistoryVM>().ReverseMap();



            // ************** Veterinarian ***********
            CreateMap<Veterinarian, VeterinarianDetailsVM>().ReverseMap();
            CreateMap<Veterinarian, VeterinarianFormVM>().ReverseMap();
            CreateMap<Veterinarian, VeterinarianVM>().ReverseMap();

            //Owner

            CreateMap<Owner, OwnerVM>()
              .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
              .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            CreateMap<OwnerFormVM, Owner>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Owner, OwnerFormVM>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));

            CreateMap<Owner, OwnerDetailsVM>().ReverseMap();
        }
    }
}
