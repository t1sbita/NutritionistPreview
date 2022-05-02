using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Business.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetById(long id);
        Task<Client> SaveClient(Client client);
        Task<Client> GetByDocumentNumber(long documentNumber);
        Task<bool> Delete(long id);
    }
}
