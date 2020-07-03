using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Insurences.Queries.GetInsuranceDetail
{
    public class VehicleLookupDto : IMapFrom<Vehicle>
    {
        public int Id { get;  set; }
        public decimal Value { get;  set; }
        public string Model { get;  set; }
        public string Manufacture { get;  set; }
    }
}