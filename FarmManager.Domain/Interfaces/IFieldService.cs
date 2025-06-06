using System.Threading.Tasks;
using FarmManager.Domain.Entities;

namespace FarmManager.Domain.Interfaces
{
    public interface IFieldService
    {
        Task<Field> CreateFieldAsync(double areaInHectares);
    }
}
