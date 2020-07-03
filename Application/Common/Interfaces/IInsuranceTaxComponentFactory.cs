using Domain.Interfaces;

namespace Application.Common.Interfaces
{
    public interface IInsuranceTaxComponentFactory
    {
        IInsuranceTaxComponent Decorate(IInsuranceTaxComponent component);
    }
}
