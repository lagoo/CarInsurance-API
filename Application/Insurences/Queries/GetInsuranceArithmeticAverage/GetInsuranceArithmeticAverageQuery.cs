using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Insurences.Queries.GetInsuranceArithmeticAverage
{
    public class GetInsuranceArithmeticAverageQuery : IRequest<InsuranceArithmeticAverageVm>
    {

        public class Handler : QueryBaseHandler, IRequestHandler<GetInsuranceArithmeticAverageQuery, InsuranceArithmeticAverageVm>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<InsuranceArithmeticAverageVm> Handle(GetInsuranceArithmeticAverageQuery request, CancellationToken cancellationToken)
            {
                List<decimal> insurancesValues = await context.Insurances.Select(e => e.Value).ToListAsync();

                return new InsuranceArithmeticAverageVm(insurancesValues.Count, insurancesValues.Sum());
            }
        }
    }
}
