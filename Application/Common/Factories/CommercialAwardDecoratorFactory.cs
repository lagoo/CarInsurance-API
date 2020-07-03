using Application.Common.DecoratorsAndComponent;
using Application.Common.Interfaces;
using Domain.Interfaces;

namespace Application.Common.Factories
{
    public class CommercialAwardDecoratorFactory : IInsuranceTaxComponentFactory
    {
        public IInsuranceTaxComponent Decorate(IInsuranceTaxComponent component) => new CommercialAwardDecorator(component);
    }
}
