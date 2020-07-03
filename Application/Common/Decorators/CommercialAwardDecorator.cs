using Domain.Interfaces;
using Shared.Support.Constants;

namespace Application.Common.DecoratorsAndComponent
{
    public class CommercialAwardDecorator : InsuranceTaxDecorator
    {
        private decimal _value;

        public CommercialAwardDecorator(IInsuranceTaxComponent component) : base(component)
        {
            _value = SystemConst.LUCRO * base.Calculate();
        }

        public override string Analyze()
        {
            return $"{base.Analyze()}, Prêmio Comercial: {_value}";
        }

        public override decimal Calculate()
        {
            return _value;
        }
    }
}
