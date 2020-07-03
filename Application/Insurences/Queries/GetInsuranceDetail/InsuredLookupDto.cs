using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Insurences.Queries.GetInsuranceDetail
{
    public class InsuredLookupDto : IMapFrom<Insured>
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
    }
}