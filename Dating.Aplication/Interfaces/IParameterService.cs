using Dating.Aplication.Models;

namespace Dating.Aplication.Interfaces
{
    public interface IParameterService<T>
    {
        Task<List<ParameterModel>> GetList();
    }
}
