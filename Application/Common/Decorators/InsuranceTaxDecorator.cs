using Domain.Interfaces;

namespace Application.Common.DecoratorsAndComponent
{
    public abstract class InsuranceTaxDecorator : IInsuranceTaxComponent
    {
        private readonly IInsuranceTaxComponent _innerTax;

        public InsuranceTaxDecorator(IInsuranceTaxComponent component)
        {
            _innerTax = component;
        }

        public virtual string Analyze()
        {
            return _innerTax.Analyze();
        }

        public virtual decimal Calculate()
        {
            return _innerTax.Calculate();
        }
    }
}
