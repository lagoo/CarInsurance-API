using Domain.Interfaces;
using Shared.Support.Constants;

namespace Application.Common.DecoratorsAndComponent
{
    public class PureAwardDecorator : InsuranceTaxDecorator
    {
        private decimal _value;

        public PureAwardDecorator(IInsuranceTaxComponent component) : base(component)
        {
            _value = base.Calculate() * (1 + SystemConst.MARGEM_SEGURANCA);
        }

        public override string Analyze()
        {
            return $"{base.Analyze()}, Prêmio Puro: {_value}";
        }

        public override decimal Calculate()
        {
            return _value;
        }
    }
}
