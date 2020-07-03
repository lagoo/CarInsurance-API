using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Insurance> Insurances { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Insured> Insureds{ get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
