using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InsuredService : IInsuredService, IDisposable
    {
        private bool _disposed = false;
        private readonly string uri;
        private readonly InsuredServiceModelValidator rules;
        private readonly HttpClient client;
        

        public InsuredService(string uri, InsuredServiceModelValidator rules)
        {
            this.uri = uri;
            this.rules = rules;

            client = new HttpClient()
            {
                BaseAddress = new Uri(uri),
                Timeout = TimeSpan.FromSeconds(10)
            };
        }

        public async Task<Insured> GetInsured(string cpf)
        {
            string responseHttp = string.Empty;

            try
            {
                var response = await client.GetAsync($"Insured?cpf={cpf}");

                if (!response.IsSuccessStatusCode)
                    return null;

                responseHttp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                //log on database
            }

            if (responseHttp == string.Empty)
                return null;

            InsuredServiceModel model = JsonConvert.DeserializeObject<List<InsuredServiceModel>>(responseHttp).FirstOrDefault();

            if (model == null || !rules.Validate(model).IsValid)
                return null;

            return new Insured(model.Name, model.Cpf, DateTime.Parse(model.Birthday));
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                client?.Dispose();

            _disposed = true;
        }
    }

    public class InsuredServiceModel
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }

    public class InsuredServiceModelValidator : AbstractValidator<InsuredServiceModel>
    {
        public InsuredServiceModelValidator()
        {
            RuleFor(e => e.Cpf)
                .NotEmpty().WithMessage($"Cpf não pode ser vazio");

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage($"Nome não pode ser vazio");

            RuleFor(e => e.Birthday)
                .NotEmpty().WithMessage($"Data de Nascimento não pode ser vazio")
                .Must(BeValidDateTime).WithMessage($"Data de Nascimento não é uma data valida");
        }

        private bool BeValidDateTime(string arg)
        {
            return DateTime.TryParse(arg, out DateTime _);
        }
    }
}
