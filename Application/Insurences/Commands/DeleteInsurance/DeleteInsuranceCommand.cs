using Application.Common.Exceptions;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Insurences.Commands.DeleteInsurance
{
    public class DeleteInsuranceCommand : IRequest
    {
        public int Id { get; }
        public DeleteInsuranceCommand(int id)
        {
            Id = id;
        }

        public class Handler : CommandBaseHandler, IRequestHandler<DeleteInsuranceCommand>
        {
            public Handler(IApplicationContext context) : base(context)
            {
            }

            public async Task<Unit> Handle(DeleteInsuranceCommand request, CancellationToken cancellationToken)
            {
                Insurance entity = await context.Insurances.Where(e => e.Id == request.Id).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Insurance), request.Id);
                }

                context.Insurances.Remove(entity);

                context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
