using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Dating.Aplication.Utilities;
using Dating.Domain.Interfaces;
using Dating.Domain.Models;

namespace Dating.Aplication.Services
{
    public class ParameterService<T>: IParameterService<T> where T : BaseParameter
    {
        private readonly IRepository<T> _repository;

        public ParameterService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<ParameterModel>> GetList()
        {
            return _repository.GetAll().ToModel().ToList();
        }
    }
}
