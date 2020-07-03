using System.Collections.Generic;

namespace Application.Insurences.Queries.GetInsuranceList
{
    public class InsuranceListVm
    {
        public IEnumerable<InsuranceLookupDto> Insurances { get; set; }

        public InsuranceListVm()
        {
            Insurances = new List<InsuranceLookupDto>();
        }
    }
}