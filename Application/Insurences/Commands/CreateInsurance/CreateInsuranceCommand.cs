using Application.Common.Handlers;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Insurences.Commands.CreateInsurance
{
    public class CreateInsuranceCommand : IRequest<int>
    {
        public string Cpf { get; set; }
        public decimal VehiclePrice { get; set; }
        public string Model { get; set; }
        public string Manufacture { get; set; }


        public class Handler : CommandBaseHandler, IRequestHandler<CreateInsuranceCommand, int>
        {
            private readonly IInsuredHelpers insuredHelpers;
            private readonly IInsuranceFactory insuranceFactory;

            public Handler(IInsuredHelpers insuredHelpers, IInsuranceFactory insuranceFactory,
                IApplicationContext context) : base(context)
            {
                this.insuredHelpers = insuredHelpers;
                this.insuranceFactory = insuranceFactory;
            }

            public async Task<int> Handle(CreateInsuranceCommand request, CancellationToken cancellationToken)
            {
                Insured insured = await insuredHelpers.GetInsured(request.Cpf);
                Vehicle vehicle = new Vehicle(request.VehiclePrice, request.Model, request.Manufacture);

                Insurance insurance =  await insuranceFactory.Create(request.VehiclePrice, vehicle, insured);

                context.Insurances.Add(insurance);

                await context.SaveChangesAsync(cancellationToken);

                return insurance.Id;
            }
        }
    }

    public class CreateInsuranceCommandValidator : AbstractValidator<CreateInsuranceCommand>
    {
        public CreateInsuranceCommandValidator()
        {
            RuleFor(e => e.Cpf)
                .NotEmpty().WithMessage($"Cpf não pode ser vazio");

            RuleFor(e => e.VehiclePrice)
                .NotEmpty().WithMessage($"Valor do Veiculo não pode ser vazio");

            RuleFor(e => e.Model)
                .NotEmpty().WithMessage($"Modelo do Veiculo não pode ser vazio");

            RuleFor(e => e.Manufacture)
                .NotEmpty().WithMessage($"Fabricante do Veiculo não pode ser vazio");
        }
    }
}
