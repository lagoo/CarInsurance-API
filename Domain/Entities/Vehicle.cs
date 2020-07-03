using System.Collections.Generic;

namespace Domain.Entities
{
    public class Vehicle
    {
        protected Vehicle()
        {
            _insurances = new List<Insurance>();
        }

        public Vehicle(decimal value, string model, string manufacture) : this()
        {
            Value = value;
            Model = model;
            Manufacture = manufacture;
        }

        public int Id { get; private set; }

        public decimal Value { get; private set; }
        public string Model { get; private set; }
        public string Manufacture { get; private set; }


        private readonly List<Insurance> _insurances;
        public IEnumerable<Insurance> Insurances => _insurances;
    }
}
