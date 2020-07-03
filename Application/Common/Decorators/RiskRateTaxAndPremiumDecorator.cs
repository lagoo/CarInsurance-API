using Domain.Interfaces;
using Shared.Support.ClassExtensions;

namespace Application.Common.DecoratorsAndComponent
{
    public class RiskRateTaxAndPremiumDecorator : InsuranceTaxDecorator
    {
        private decimal _riskRate;
        private decimal _premiumRate;

        public RiskRateTaxAndPremiumDecorator(IInsuranceTaxComponent component) : base(component)
        {
            _riskRate = base.Calculate() * 5 / (2 * base.Calculate());
            _premiumRate = (_riskRate / 100) * base.Calculate();
        }

        public override string Analyze()
        {
            return $"{base.Analyze()}, Taxa de Risco: {_riskRate.ToStringBrazilianPercentFormat()}, Prêmio de Risco: {_premiumRate}";
        }

        public override decimal Calculate()
        {
            return _premiumRate;
        }
    }
}
