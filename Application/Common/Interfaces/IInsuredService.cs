using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IInsuredService
    {
        Task<Insured> GetInsured(string cpf);
    }
}
