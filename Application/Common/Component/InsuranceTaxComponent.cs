using Domain.Interfaces;

namespace Application.Common.DecoratorsAndComponent
{
    public class InsuranceTaxComponent : IInsuranceTaxComponent
    {
        protected decimal Value { get; private set; }

        public InsuranceTaxComponent(decimal value)
        {
            Value = value;
        }

        public decimal Calculate()
        {
            return Value;
        }

        public string Analyze()
        {
            return $"Valor do Veiculo: {Value}";
        }
    }
}
