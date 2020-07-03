using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Insurences.Queries.GetInsuranceList
{
    public class GetInsuranceListQuery : IRequest<InsuranceListVm>
    {

        public class Handler : QueryBaseHandler, IRequestHandler<GetInsuranceListQuery, InsuranceListVm>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<InsuranceListVm> Handle(GetInsuranceListQuery request, CancellationToken cancellationToken)
            {
                List<InsuranceLookupDto> insurancesLookupDto = await context.Insurances.Include(e => e.Insured)
                                                                                       .Include(e => e.Vehicle)
                                                                                       .ProjectTo<InsuranceLookupDto>(mapper.ConfigurationProvider)
                                                                                       .ToListAsync();

                InsuranceListVm result = new InsuranceListVm()
                {
                    Insurances = insurancesLookupDto
                };

                return result;
            }
        }
    }
}
