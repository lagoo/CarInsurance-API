using Application.Common.DecoratorsAndComponent;
using Application.Common.Interfaces;
using Domain.Interfaces;

namespace Application.Common.Factories
{
    public class RiskRateTaxAndPremiumDecoratorFactory : IInsuranceTaxComponentFactory
    {
        public IInsuranceTaxComponent Decorate(IInsuranceTaxComponent component) => new RiskRateTaxAndPremiumDecorator(component);
    }
}
