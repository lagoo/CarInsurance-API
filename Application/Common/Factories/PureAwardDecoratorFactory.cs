using Application.Common.DecoratorsAndComponent;
using Application.Common.Interfaces;
using Domain.Interfaces;

namespace Application.Common.Factories
{
    public class PureAwardDecoratorFactory : IInsuranceTaxComponentFactory
    {
        public IInsuranceTaxComponent Decorate(IInsuranceTaxComponent component) => new PureAwardDecorator(component);
    }
}
