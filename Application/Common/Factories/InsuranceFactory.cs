using Application.Common.DecoratorsAndComponent;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Factories
{
    public class InsuranceFactory : IInsuranceFactory
    {
        private readonly IEnumerable<IInsuranceTaxComponentFactory> componentFactories;

        public InsuranceFactory(IEnumerable<IInsuranceTaxComponentFactory> componentFactories)
        {
            this.componentFactories = componentFactories;
        }

        public Task<Insurance> Create(decimal value, Vehicle vehicle, Insured insured)
        {
            IInsuranceTaxComponent component = new InsuranceTaxComponent(value); 

            foreach (var factory in componentFactories)
            {
                component = factory.Decorate(component);
            }

            if (System.Diagnostics.Debugger.IsAttached)
                Console.WriteLine(component.Analyze());

            return Task.FromResult(new Insurance(component, vehicle, insured));
        }
    }
}
