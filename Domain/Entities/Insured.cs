using System;
using System.Collections.Generic;
using Shared.Support.ClassExtensions;

namespace Domain.Entities
{
    public class Insured
    {
        protected Insured()
        {
            _insurances = new List<Insurance>();
        }

        public Insured(string name, string cPF, DateTime birthday) : this()
        {
            Name = name;
            CPF = cPF;
            Birthday = birthday;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
        public string CPF { get; private set; }
        private DateTime Birthday { get; set; }
        public int Age => Birthday.CalculateBirthDate();



        private readonly List<Insurance> _insurances;
        public IEnumerable<Insurance> Insurances => _insurances;
    }
}
