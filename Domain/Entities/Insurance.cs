using Domain.Interfaces;

namespace Domain.Entities
{
    public class Insurance
    {
        protected Insurance()
        {

        }

        public Insurance(IInsuranceTaxComponent component, Vehicle vehicle, Insured insured)
        {
            Value = component.Calculate();

            VehicleId = vehicle.Id;
            Vehicle = vehicle;

            InsuredId = insured.Id;
            Insured = insured;
        }

        public int Id { get; private set; }
        public decimal Value { get; private set; }

        public int VehicleId { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public int InsuredId { get; private set; }
        public Insured Insured { get; private set; }
    }
}
