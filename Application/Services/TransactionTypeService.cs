using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;
using Infrasctructure.Repositories;

namespace Application.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly ITransactionTypeRepository _typeRepository;

        public TransactionTypeService(ITransactionTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<TransactionType> Create(TransactionType type)
        {
            var (newType, error) = TransactionType.Create(
                Guid.NewGuid(),
                type.Name, 
                type.Color
                );

            if(!string.IsNullOrEmpty(error))
                throw new TransactionTypeBadRequestException(error);

            Guid typeId = await _typeRepository.Create(newType);
            var createdType = await _typeRepository.Get(typeId);

            return createdType;
        }

        public async Task<TransactionType> Delete(Guid id)
        {
            var typeToDelete = await _typeRepository.Get(id);
            await _typeRepository.Delete(id);

            return typeToDelete;
        }

        public async Task<TransactionType> Get(Guid id)
        {
            var type = await _typeRepository.Get(id);
            return type;
        }

        public async Task<List<TransactionType>> GetAll()
        {
            var type = await _typeRepository.GetAll();
            return type;
        }

        public async Task<TransactionType> Update(TransactionType type)
        {
            var (Type, error) = TransactionType.Create(
                Guid.NewGuid(),
                type.Name,
                type.Color
                );

            if (!string.IsNullOrEmpty(error))
                throw new TransactionTypeBadRequestException(error);

            var typeId = await _typeRepository.Update(Type.Id, Type.Name, Type.Color);

            var updatedType = await _typeRepository.Get(typeId);

            return updatedType;
        }
    }
}
