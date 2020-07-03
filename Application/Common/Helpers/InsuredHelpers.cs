using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public class InsuredHelpers : IInsuredHelpers
    {
        private readonly IApplicationContext context;
        private readonly IInsuredService insuredService;

        public InsuredHelpers(IApplicationContext context, IInsuredService insuredService)
        {
            this.context = context;
            this.insuredService = insuredService;
        }

        public async Task<Insured> GetInsured(string cpf)
        {
            Insured insured = await context.Insureds.Where(e => e.CPF == cpf).FirstOrDefaultAsync();

            if (!(insured is object))
                insured = await insuredService.GetInsured(cpf);

            if (!(insured is object))
                throw new Exceptions.ValidationException(new List<FluentValidation.Results.ValidationFailure>() { new FluentValidation.Results.ValidationFailure("Cpf", "Cpf não encontrado") });

            return insured;
        }
    }
}
