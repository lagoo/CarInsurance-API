using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Insurences.Queries.GetInsuranceDetail
{
    public class InsuranceDetailVm : IMapFrom<Insurance>
    {
        public int Id { get;  set; }
        public decimal Value { get;  set; }

        public VehicleLookupDto Vehicle { get;  set; }
        public InsuredLookupDto Insured { get;  set; }
    }
}