using Application.Common.Exceptions;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Insurences.Queries.GetInsuranceDetail
{
    public class GetInsuranceDetailQuery : IRequest<InsuranceDetailVm>
    {
        public int Id { get; }

        public GetInsuranceDetailQuery(int id)
        {
            Id = id;
        }

        public class Handler : QueryBaseHandler, IRequestHandler<GetInsuranceDetailQuery, InsuranceDetailVm>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<InsuranceDetailVm> Handle(GetInsuranceDetailQuery request, CancellationToken cancellationToken)
            {
                InsuranceDetailVm entity = await context.Insurances.Where(e => e.Id == request.Id)
                                                                   .Include(e => e.Insured)
                                                                   .Include(e => e.Vehicle)
                                                                   .ProjectTo<InsuranceDetailVm>(mapper.ConfigurationProvider)
                                                                   .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Insurance), request.Id);
                }

                return entity;
            }
        }
    }
}
