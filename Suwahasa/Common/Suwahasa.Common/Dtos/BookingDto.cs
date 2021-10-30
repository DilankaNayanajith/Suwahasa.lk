using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Common.Dtos
{
  public class BookingDto
  {
    public long Id { get; set; }
    public long HospitalId { get; set; }
    public long? PackageId { get; set; }
    public DateTime? DateCreated { get; set; }
    public string DateCreatedText 
    { 
      get 
      { 
        return DateCreated.HasValue ? DateCreated.Value.ToString("yyyy-MM-dd") : null;
      } 
    }
    public bool TransportRequested { get; set; }
    public DateTime? TransportDate { get; set; }
    public string TransportDateText 
    { 
      get 
      { 
        return TransportDate.HasValue ? TransportDate.Value.ToString("yyyy-MM-dd") : null; 
      } 
    }
    public long? VehicleId { get; set; }
    public DateTime? DateAdmitted { get; set; }
    public string DateAdmittedText 
    { 
      get 
      { 
        return DateAdmitted.HasValue ? DateAdmitted.Value.ToString("yyyy-MM-dd") : null; 
      } 
    }
    public DateTime? DateDischarged { get; set; }
    public string DateDischargedText 
    { 
      get 
      { 
        return DateDischarged.HasValue ? DateDischarged.Value.ToString("yyyy-MM-dd") : null; 
      } 
    }
    public string PaymentStatus { get; set; }
    public bool? TransportApproved { get; set; }
    public DateTime? ReservationDate { get; set; }
    public string ReservationDateText 
    { 
      get 
      { 
        return ReservationDate.HasValue ? ReservationDate.Value.ToString("yyyy-MM-dd") : null; 
      } 
    }
    public long UserId { get; set; }
    public bool IsActive { get; set; }

    public HospitalDto ReservedHospital { get; set; }
    public PackageDto ReservedPackage { get; set; }
    public VehicleDto ReservedVehicle { get; set; }
    public UserDto ReservedUser { get; set; }

    public IList<BedTicketDto> BedTickets { get; set; }
    public IList<CovidTestResultDto> CovidTestResults { get; set; }
  }
}
