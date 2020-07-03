namespace Application.Insurences.Queries.GetInsuranceArithmeticAverage
{
    public class InsuranceArithmeticAverageVm
    {
        public InsuranceArithmeticAverageVm(int quantity, decimal total)
        {
            Quantity = quantity;
            Total = total;
            Value = quantity == 0 || total == 0 ? 0 : total / quantity;
        }

        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal Value { get; set; }
    }
}