using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Data.Entities;

namespace Suwahasa.Services.Profiles
{
  class AutoMapperProfiles : Profile
  {
	public AutoMapperProfiles()
	{
	  //Entities
	  CreateMap<Hospital, HospitalDto>().ReverseMap();

	  CreateMap<Employee, EmployeeDto>()
		  .ForMember
		  (
			  dest => dest.Hospital,
			  act => act.MapFrom(src => src.HospitalFkNavigation)
		  ).ForMember(
			  dest => dest.Name, 
			  act => act.Ignore()
		  ).ReverseMap();

	  CreateMap<Vehicle, VehicleDto>()
		  .ForMember
		  (
			  dest => dest.Hospital,
			  act => act.MapFrom(src => src.HospitalFkNavigation)
		  ).ForMember
		  (
			  dest => dest.Driver,
			  act => act.MapFrom(src => src.DriverFkNavigation)
		  ).ReverseMap();

	  CreateMap<Package, PackageDto>().ReverseMap();
	  CreateMap<User, UserDto>()
		  .ForMember(
			  dest => dest.Employee,
			  act => act.MapFrom(src => src.EmployeeFkNavigation)
		  ).ForMember(
			  dest => dest.EmployeeId,
			  act => act.MapFrom(src => src.EmployeeFk)
		  ).ForMember(
			  dest => dest.Name,
			  act => act.Ignore()
		  ).ForMember(
			  dest => dest.HospitalId,
			  act => act.MapFrom(src => src.EmployeeFkNavigation != null ? src.EmployeeFkNavigation.HospitalFk : null)
		  ).ReverseMap();

	  CreateMap<Booking, BookingDto>()
		.ForMember(
		  dest => dest.UserId,
		  act => act.MapFrom(src => src.UserFk)
		).ForMember(
		  dest => dest.HospitalId,
		  act => act.MapFrom(src => src.HospitalFk)
		).ForMember(
		  dest => dest.VehicleId,
		  act => act.MapFrom(src => src.VehicleFk)
		).ForMember(
		  dest => dest.PackageId,
		  act => act.MapFrom(src => src.PackageFk)
		).ForMember(
		  dest => dest.ReservedHospital,
		  act => act.MapFrom(src => src.HospitalFkNavigation)
		).ForMember(
		  dest => dest.ReservedPackage, 
		  act => act.MapFrom(src => src.PackageFkNavigation)
		).ForMember(
		  dest => dest.ReservedVehicle, 
		  act => act.MapFrom(src => src.VehicleFkNavigation)
		).ForMember(
		  dest => dest.ReservedUser,
		  act => act.MapFrom(src => src.UserFkNavigation)
		).ForMember(
		  dest => dest.DateCreatedText,
		  act => act.Ignore()
		).ForMember(
		  dest => dest.TransportDateText,
		  act => act.Ignore()
		).ForMember(
		  dest => dest.DateAdmittedText,
		  act => act.Ignore()
		).ForMember(
		  dest => dest.DateDischargedText,
		  act => act.Ignore()
		).ForMember(
		  dest => dest.ReservationDateText,
		  act => act.Ignore()
		).ReverseMap();

	  CreateMap<CovidTestResult, CovidTestResultDto>()
		.ForMember(
		  dest => dest.BookingId,
		  act => act.MapFrom(src => src.BookingFk)
		 ).ForMember(
		  dest => dest.DateTestedText,
		  act => act.Ignore()
		 ).ReverseMap();

	  CreateMap<BedTicket, BedTicketDto>()
		.ForMember(
		  dest => dest.BookingId,
		  act => act.MapFrom(src => src.BookingFk)
		).ForMember(
		  dest => dest.EnteredById,
		  act => act.MapFrom(src => src.EnteredByFk)
		).ForMember(
		  dest => dest.EnteredBy,
		  act => act.MapFrom(src => src.EnteredByFkNavigation)
		).ForMember(
		  dest => dest.DateEnteredText,
		  act => act.Ignore()
		);

	  //Request models
	  CreateMap<Employee, UpsertEmployeeRequest>().ReverseMap();
	  CreateMap<Vehicle, UpsertVehicleRequest>().ReverseMap();
	  CreateMap<Hospital, UpsertHospitalRequest>().ReverseMap();
	  CreateMap<Package, UpsertPackageRequest>().ReverseMap();
	  CreateMap<User, RegisterRequest>()
		.ForMember(
		  dest => dest.EmployeeId,
		  act => act.MapFrom(src => src.EmployeeFk)
		).ReverseMap();
	  CreateMap<Booking, UpsertBookingRequest>()
		.ForMember(
		  dest => dest.HospitalId,
		  act => act.MapFrom(src => src.HospitalFk)
		).ForMember(
		  dest => dest.PackageId,
		  act => act.MapFrom(src => src.PackageFk)
		).ForMember(
		  dest => dest.UserId,
		  act => act.MapFrom(src => src.UserFk)
		).ForMember(
		  dest => dest.ReservationDate,
		  act => act.Ignore()
		).ReverseMap();
	  CreateMap<BedTicket, UpsertBedTicketRequest>()
		.ForMember(
		  dest => dest.BookingId,
		  act => act.MapFrom(src => src.BookingFk)
		).ForMember(
		  dest => dest.EnteredById,
		  act => act.MapFrom(src => src.EnteredByFk)
		).ReverseMap();
	  CreateMap<CovidTestResult, UpsertCovidTestResultRequest>()
		.ForMember(
		  dest => dest.BookingId,
		  act => act.MapFrom(src => src.BookingFk)
		 ).ReverseMap();
	  CreateMap<User, AuthUser>()
		.ForMember(
		  dest => dest.Name,
		  act => act.MapFrom(src => src.FirstName + " " + src.LastName)
		).ForMember(
		  dest => dest.Role,
		  act => act.MapFrom(src => src.Type)
		).ForMember(
		  dest => dest.HospitalId,
		  act => act.MapFrom(src => src.EmployeeFkNavigation != null ? src.EmployeeFkNavigation.HospitalFk : null)
		).ReverseMap();
	}
  }
}
