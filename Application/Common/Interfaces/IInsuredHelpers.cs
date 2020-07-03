using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IInsuredHelpers
    {
        Task<Insured> GetInsured(string cpf); 
    }
}
