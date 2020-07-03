using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IInsuranceFactory
    {
        Task<Insurance> Create(decimal value, Vehicle vehicle, Insured insured);
    }
}
