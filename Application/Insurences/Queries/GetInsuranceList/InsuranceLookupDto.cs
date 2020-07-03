using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Insurences.Queries.GetInsuranceList
{
    public class InsuranceLookupDto : IMapFrom<Insurance>
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
    }
}